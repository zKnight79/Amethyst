using Amethyst.Graphics;
using Amethyst.Graphics.OpenGL;
using Amethyst.Math;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Amethyst.Engine
{
    /// <summary>
    /// The base Game class of Amethyst
    /// </summary>
    public class Game : IDisposable
    {
        /// <summary>
        /// Get or set the display settings for the Game
        /// </summary>
        public DisplaySettings DisplaySettings { get; set; } = new DisplaySettings();
        /// <summary>
        /// Get the Form used to display the Game
        /// </summary>
        public Form Form { get; private set; } = null;
        /// <summary>
        /// Get the OpenGL Context of the Game
        /// </summary>
        public GLContext GLContext { get; private set; } = null;
        /// <summary>
        /// Get or set the Background color (Default : Amethyst, of course)
        /// </summary>
        public Color4 BackgroundColor { get; set; } = Color4.Colors.Amethyst;
        /// <summary>
        /// Get of set the GLSL Program used by the Game
        /// </summary>
        public GLSLProgram Program2D { get; set; } = null;
        /// <summary>
        /// Get the Box corresponding to the client rectangle of the Game window
        /// </summary>
        public Box ViewPort { get; private set; }
        /// <summary>
        /// Get or set the Camera used by the Game
        /// </summary>
        public Camera Camera { get; set; } = null;
        /// <summary>
        /// Get the GameTime
        /// </summary>
        protected GameTime GameTime { get; private set; }
        /// <summary>
        /// Get or set the SpriteBatch used by the Game
        /// </summary>
        public SpriteBatch SpriteBatch { get; set; } = null;
        /// <summary>
        /// Get or set the system font used by the Game
        /// </summary>
        public Font SystemFont { get; set; } = null;

        /// <summary>
        /// Dispose all resources used by the Game
        /// </summary>
        public void Dispose()
        {
            if (Program2D != null)
            {
                Program2D.Dispose();
                Program2D = null;
            }

            if (GLContext != null)
            {
                GLContext.Dispose();
                GLContext = null;
            }

            if (DisplaySettings.Fullscreen)
            {
                Logger.WriteLine("Restoring display settings");
                Win32.ChangeDisplaySettings(null, 0);
            }

            if (Form != null && !Form.IsDisposed)
            {
                Logger.WriteLine("Disposing Game Window");
                Form.Dispose();
                Form = null;
            }
        }

        /// <summary>
        /// Run the Game
        /// </summary>
        public void Run()
        {
            if (!Init())
            {
                return;
            }

            Logger.WriteLine("Entering the Game Loop");
            GameTime = new GameTime();
            while (Form.Created)
            {
                Update();
                Render();

                Application.DoEvents();
            }
            Logger.WriteLine("Exiting the Game Loop");
            OnRelease();
        }
        /// <summary>
        /// Hook method called by Run(), just after exiting the Game loop<br />
        /// Use it to release game resources
        /// </summary>
        protected virtual void OnRelease() { }

        private bool Init()
        {
            Logger.WriteLine(DisplaySettings.ToString());
            
            #region INIT FORM
            Form = new Form();
            Form.ClientSize = new System.Drawing.Size(DisplaySettings.Width, DisplaySettings.Height);
            Form.StartPosition = FormStartPosition.CenterScreen;
            Form.Text = "Powered by Amethyst Game Library";
            if (DisplaySettings.Fullscreen)
            {
                #region CHANGE DISPLAY SETTINGS TO MATCH GAME WINDOW SIZE
                DEVMODE dmScreenSettings = new DEVMODE()
                {
                    dmSize = (short)Marshal.SizeOf(typeof(DEVMODE)),
                    dmPelsWidth = DisplaySettings.Width,
                    dmPelsHeight = DisplaySettings.Height,
                    dmBitsPerPel = DisplaySettings.ColorBits,
                    dmFields = Win32.DM_PELSWIDTH | Win32.DM_PELSHEIGHT | Win32.DM_BITSPERPEL
                };
                Logger.WriteLine("Changing display settings for Fullscreen");
                if (Win32.ChangeDisplaySettings(dmScreenSettings, Win32.CDS_FULLSCREEN) != 0)
                {
                    // Si on ne peut pas changer les paramètres d'affichage, on repasse en mode fenêtré
                    DisplaySettings.Fullscreen = false;
                    Logger.WriteLine(">> Failed");
                }
                else
                {
                    Form.FormBorderStyle = FormBorderStyle.None;
                    Logger.WriteLine(">> Success");
                }
                #endregion
            }
            if (!DisplaySettings.EnableResizing)
            {
                Form.MaximizeBox = false;
                Form.MinimumSize = Form.MaximumSize = Form.Size;
                Form.SizeGripStyle = SizeGripStyle.Hide;
                if (!DisplaySettings.Fullscreen)
                {
                    Form.FormBorderStyle = FormBorderStyle.FixedDialog;
                }
            }
            Form.Resize += (object sender, EventArgs e) => { OnResize(); };
            #endregion

            #region CREATING THE OPENGL CONTEXT
            try
            {
                GLContext = new GLContext(Form, DisplaySettings.ColorBits, DisplaySettings.DepthBits, DisplaySettings.StencilBits, DisplaySettings.AccumBits, DisplaySettings.MSAA);
            }
            catch (Exception ex)
            {
                Logger.WriteLine("Error during GL Context creation :" + Environment.NewLine + ex.Message);
                return false;
            }
            #endregion

            #region SHOW THE GAME WINDOW
            Logger.WriteLine("Show the Game Window");
            Form.Show();
            Form.Activate();
            #endregion

            #region DEFAULT AMETHYST OPENGL PREFERENCES
            Logger.WriteLine("Setting default Amethyst OpenGL preferences");
            GL.ClearColor(BackgroundColor);
            GL.Enable(EnableCap.GL_CULL_FACE);
            GL.Enable(EnableCap.GL_BLEND);
            GL.BlendFunc(BlendFactor.GL_SRC_ALPHA, BlendFactor.GL_ONE_MINUS_SRC_ALPHA);
            #endregion

            #region CREATE AMETYST PRESETS
            Program2D = GLSLProgram.CreateBuiltInProgram();
            SpriteBatch = new SpriteBatch();
            SystemFont = Font.FromXMLSrc(Fonts.SYSTEM_24, new Texture(Fonts.SYSTEM_24_TEX, System.Drawing.Color.Magenta));
            #endregion

            OnResize();
            OnInit();

            return true;
        }

        /// <summary>
        /// Method called when the Game window is resized.<br />
        /// Reset the viewport to the client area and recompute pre-computed 2D projection matrix.<br />
        /// Developper can extend it by calling base.OnResize() or just override it by handling viewport and projection matrix.
        /// </summary>
        protected virtual void OnResize()
        {
            #region VIEWPORT
            ViewPort = new Box(Form.ClientRectangle);
            Logger.WriteLine(string.Format("OnResize : Game Window new size = {0}x{1}", ViewPort.Width, ViewPort.Height));
            GL.Viewport(ViewPort);
            #endregion
            #region 2D PROJECTION MATRIX
            if (Camera == null)
            {
                Camera = new Camera(ViewPort);
            }
            else
            {
                Camera.ViewRectangle = ViewPort;
            }
            Matrix4 p = Camera.ProjectionMatrix;
            if (Program2D != null)
            {
                Program2D.ChangeMVPMatrix(ref p);
            }
            #endregion
        }

        /// <summary>
        /// Hook method called by Run(), just before entering the Game loop<br />
        /// Use it to load game resources, or override some Amethyst presets features
        /// </summary>
        protected virtual void OnInit() { }

        private void Update()
        {
            GameTime.Update();
            OnUpdate(GameTime.ElapsedTime);
        }
        /// <summary>
        /// Hook method called by Run(), during the Game loop<br />
        /// </summary>
        /// <param name="elapsedTime">Elapsed time since the last call to OnUpdate()</param>
        protected virtual void OnUpdate(float elapsedTime) { }

        private void Render()
        {
            GL.Clear(ClearMask.GL_COLOR_BUFFER_BIT);
            SpriteBatch.Begin(Program2D);
            OnRender();
            SpriteBatch.End();
            GLContext.SwapBuffers();
        }
        /// <summary>
        /// Hook method called by Run(), during the Game loop<br />
        /// </summary>
        protected virtual void OnRender() { }
    }
}
