using Amethyst.Graphics;
using Amethyst.Input;
using Amethyst.Math;

namespace Amethyst.Engine
{
    /// <summary>
    /// Base UI node class
    /// </summary>
    public abstract class UINode : SceneNode
    {
        /// <summary>
        /// Get or set the Text displayed by the UI Node
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Get or set the Font used to display the text
        /// </summary>
        public Font Font { get; set; }

        #region TEXT COLOR
        private Color4 m_TextColor = Color4.Colors.White;
        /// <summary>
        /// Get or set the color of the text
        /// </summary>
        public Color4 TextColor
        {
            get { return m_TextColor; }
            set { m_TextColor = value; }
        }
        /// <summary>
        /// Get or set the Red component of the TextColor of the UI Node
        /// </summary>
        public float TextColorRed
        {
            get { return m_TextColor.Red; }
            set { m_TextColor.Red = value; }
        }
        /// <summary>
        /// Get or set the Green component of the TextColor of the UI Node
        /// </summary>
        public float TextColorGreen
        {
            get { return m_TextColor.Green; }
            set { m_TextColor.Green = value; }
        }
        /// <summary>
        /// Get or set the Blue component of the TextColor of the UI Node
        /// </summary>
        public float TextColorBlue
        {
            get { return m_TextColor.Blue; }
            set { m_TextColor.Blue = value; }
        }
        /// <summary>
        /// Get or set the Alpha component of the TextColor of the UI Node
        /// </summary>
        public float TextColorAlpha
        {
            get { return m_TextColor.Alpha; }
            set { m_TextColor.Alpha = value; }
        }
        #endregion

        /// <summary>
        /// Get or set the Text render mode used to render the text
        /// </summary>
        public TextRenderMode TextRenderMode { get; set; } = TextRenderMode.Box;
        /// <summary>
        /// Get or set the Text alignement used to render the text
        /// </summary>
        public TextAlign TextAlign { get; set; } = TextAlign.MiddleCenter;

        /// <summary>
        /// Constructor for UINode. The Box and Font must be provided
        /// </summary>
        /// <param name="box">The Box of the UINode</param>
        /// <param name="font">The Font of the UINode</param>
        public UINode(Box box, Font font) : base(box)
        {
            Font = font;
        }

        /// <summary>
        /// The UINode implementation can define its render logic<br />
        /// Default behavior is to render the Texture region of the texture in the Box, using Color and rotation angle
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to render the UINode</param>
        protected override void OnRender(SpriteBatch spriteBatch)
        {
            base.OnRender(spriteBatch);
            if((Text ?? "") != "")
            {
                spriteBatch.DrawText(Text, Font, TextRenderMode, Box, TextColor, TextAlign, Angle);
            }
        }
    }
}
