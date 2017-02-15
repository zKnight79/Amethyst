using Amethyst.Graphics;
using Amethyst.Input;
using Amethyst.Math;

namespace Amethyst.Engine
{
    public abstract class UINode : SceneNode
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public Color4 TextColor { get; set; }
        public TextRenderMode TextRenderMode { get; set; } = TextRenderMode.Box;
        public TextAlign TextAlign { get; set; } = TextAlign.MiddleCenter;

        public UINode(Box box, string text, Font font, Color4 textColor) : base(box)
        {
            Text = text;
            Font = font;
            TextColor = textColor;
        }

        protected override void OnRender(SpriteBatch spriteBatch)
        {
            base.OnRender(spriteBatch);
            if((Text ?? "") != "")
            {
                spriteBatch.DrawText(Text, Font, TextRenderMode, Box, TextColor, TextAlign, Angle);
            }
        }

        /// <summary>
        /// Hook method called when a Mouse button is pressed
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseButtonDown(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when a Mouse button is released
        /// </summary>
        /// <param name="mouseState"></param>
        public virtual void OnMouseButtonUp(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse left button is clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseLeftClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse left button is double-clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseLeftDoubleClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse middle button is clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseMiddleClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse middle button is double-clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseMiddleDoubleClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse right button is clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseRightClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse right button is double-clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseRightDoubleClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse is moved
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseMove(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse wheel is used
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseWheel(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse XButton1 button is clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseXButton1Click(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse XButton1 button is double-clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseXButton1DoubleClick(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse XButton2 button is clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseXButton2Click(MouseState mouseState) { }
        /// <summary>
        /// Hook method called when Mouse XButton2 button is double-clicked
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public virtual void OnMouseXButton2DoubleClick(MouseState mouseState) { }
    }
}
