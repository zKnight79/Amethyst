using Amethyst.Graphics;
using Amethyst.Math;
using System.Collections.Generic;

namespace Amethyst.Engine
{
    /// <summary>
    /// Base scene nodes class
    /// </summary>
    public abstract class SceneNode
    {
        #region BOX
        private Box m_Box;
        /// <summary>
        /// Get or set the Box of the Node
        /// </summary>
        public Box Box
        {
            get { return m_Box; }
            set { m_Box = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Position of the Box of the Node
        /// </summary>
        public Point BoxPosition
        {
            get { return m_Box.Position; }
            set { m_Box.Position = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Size of the Box of the Node
        /// </summary>
        public Size BoxSize
        {
            get { return m_Box.Size; }
            set { m_Box.Size = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the X property of the Box of the Node
        /// </summary>
        public float BoxX
        {
            get { return m_Box.X; }
            set { m_Box.X = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Y property of the Box of the Node
        /// </summary>
        public float BoxY
        {
            get { return m_Box.Y; }
            set { m_Box.Y = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Width of the Box of the Node
        /// </summary>
        public float BoxWidth
        {
            get { return m_Box.Width; }
            set { m_Box.Width = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Height of the Box of the Node
        /// </summary>
        public float BoxHeight
        {
            get { return m_Box.Height; }
            set { m_Box.Height = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Center of the Box of the Node
        /// </summary>
        public Point BoxCenter
        {
            get { return m_Box.Center; }
            set { m_Box.Center = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Left property of the Box of the Node
        /// </summary>
        public float BoxLeft
        {
            get { return m_Box.Left; }
            set { m_Box.Left = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Right property of the Box of the Node
        /// </summary>
        public float BoxRight
        {
            get { return m_Box.Right; }
            set { m_Box.Right = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Top property of the Box of the Node
        /// </summary>
        public float BoxTop
        {
            get { return m_Box.Top; }
            set { m_Box.Top = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get or set the Bottom property of the Box of the Node
        /// </summary>
        public float BoxBottom
        {
            get { return m_Box.Bottom; }
            set { m_Box.Bottom = value; BoxChanged?.Invoke(); }
        }
        /// <summary>
        /// Get Top-Left corner of the Box of the Node
        /// </summary>
        public Point BoxTopLeft => m_Box.TopLeft;
        /// <summary>
        /// Get Top-Right corner of the Box of the Node
        /// </summary>
        public Point BoxTopRight => m_Box.TopRight;
        /// <summary>
        /// Get Bottom-Left corner of the Box of the Node
        /// </summary>
        public Point BoxBottomLeft => m_Box.BottomLeft;
        /// <summary>
        /// Get Bottom-Right corner of the Box of the Node
        /// </summary>
        public Point BoxBottomRight => m_Box.BottomRight;
        /// <summary>
        /// Event fired when a box property is changed
        /// </summary>
        public event SceneNodeBoxChanged BoxChanged;
        #endregion

        #region ANGLE
        private float m_Angle = 0.0f;
        /// <summary>
        /// Get or set the rotation angle (in degrees) of the Node<br />
        /// After setting value, Angle is always between 0 (included) and 360 (excluded)
        /// </summary>
        public float Angle
        {
            get { return m_Angle; }
            set
            {
                m_Angle = value;
                while (m_Angle < 0.0f)
                {
                    m_Angle += 360.0f;
                }
                while (m_Angle >= 360.0f)
                {
                    m_Angle -= 360.0f;
                }
            }
        }
        #endregion

        #region COLOR
        private Color4 m_Color = Color4.Colors.White;
        /// <summary>
        /// Get or set the Color of the Node
        /// </summary>
        public Color4 Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        /// <summary>
        /// Get or set the Red component of the Color of the Node
        /// </summary>
        public float ColorRed
        {
            get { return m_Color.Red; }
            set { m_Color.Red = value; }
        }
        /// <summary>
        /// Get or set the Green component of the Color of the Node
        /// </summary>
        public float ColorGreen
        {
            get { return m_Color.Green; }
            set { m_Color.Green = value; }
        }
        /// <summary>
        /// Get or set the Blue component of the Color of the Node
        /// </summary>
        public float ColorBlue
        {
            get { return m_Color.Blue; }
            set { m_Color.Blue = value; }
        }
        /// <summary>
        /// Get or set the Alpha component of the Color of the Node
        /// </summary>
        public float ColorAlpha
        {
            get { return m_Color.Alpha; }
            set { m_Color.Alpha = value; }
        }
        #endregion

        /// <summary>
        /// Get or set if the Node is visible or not
        /// </summary>
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Get or set the Texture used by the Node
        /// </summary>
        public Texture Texture { get; set; } = null;

        /// <summary>
        /// Get or set the Texture region used by the node
        /// </summary>
        public Box? TextureRegion { get; set; } = null;

        /// <summary>
        /// Get or set the Flip effect to apply to the node if textured
        /// </summary>
        public FlipEffect FlipEffect { get; set; } = FlipEffect.None;

        /// <summary>
        /// Get or set the Z-Order of the Node<br />
        /// In specific cases, when you don't call SceneNode.Render yourself,<br />
        /// Using Z-Order helps you to control which Nodes are in front and which Nodes are behind.
        /// </summary>
        public int ZOrder { get; set; } = 0;

        /// <summary>
        /// Constructor for SceneNode. The Box must be provided
        /// </summary>
        /// <param name="box">The Box of the Node</param>
        public SceneNode(Box box)
        {
            Box = box;
        }

        #region RENDERING
        /// <summary>
        /// Render the Node
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to render the Node</param>
        public void Render(SpriteBatch spriteBatch)
        {
            if (Visible)
            {
                OnRender(spriteBatch);
            }
        }
        /// <summary>
        /// The SceneNode implementation can define its render logic<br />
        /// Default behavior is to render the Texture region of the texture in the Box, using Color and rotation angle
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to render the Node</param>
        protected virtual void OnRender(SpriteBatch spriteBatch)
        {
            if(Texture != null)
            {
                spriteBatch.DrawTexture(Texture, TextureRegion, m_Box, m_Color, m_Angle, FlipEffect);
            }
        }
        #endregion

        #region UPDATING
        /// <summary>
        /// Update the Node
        /// </summary>
        /// <param name="elapsedTime">Frame time in seconds</param>
        public void Update(float elapsedTime)
        {
            Animate(elapsedTime);
            OnUpdate(elapsedTime);
        }
        /// <summary>
        /// The SceneNode implementation can define its update logic
        /// </summary>
        /// <param name="elapsedTime">Frame time in seconds</param>
        protected virtual void OnUpdate(float elapsedTime) { }
        #endregion

        #region ANIMATING
        List<Animator> m_Animators = new List<Animator>();
        /// <summary>
        /// Get number of animators currently attached to the Node
        /// </summary>
        public int AnimatorCount => m_Animators.Count;

        private void Animate(float elapsedTime)
        {
            Animator[] animators = m_Animators.ToArray();
            foreach (Animator animator in animators)
            {
                animator.Update(this, elapsedTime);
            }
        }

        /// <summary>
        /// Add an animator to the Node
        /// </summary>
        /// <param name="animator">The animator to add to the Node</param>
        public void AddAnimator(Animator animator)
        {
            m_Animators.Add(animator);
            animator.Finished += (a) => { m_Animators.Remove(a); };
            animator.Start(this);
        }

        /// <summary>
        /// Remove all animators from the Node
        /// </summary>
        public void ClearAnimators()
        {
            m_Animators.Clear();
        }
        #endregion
    }

    /// <summary>
    /// Delegate for BoxChanged event of SceneNode
    /// </summary>
    public delegate void SceneNodeBoxChanged();
}
