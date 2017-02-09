namespace Amethyst.Input
{
    /// <summary>
    /// Structure representing a mouse state
    /// </summary>
    public struct MouseState
    {
        /// <summary>
        /// X coordinate of the mouse position
        /// </summary>
        public int X;
        /// <summary>
        /// Y coordinate of the mouse position
        /// </summary>
        public int Y;
        /// <summary>
        /// Movement value along X axis
        /// </summary>
        public int DeltaX;
        /// <summary>
        /// Movement value along Y axis
        /// </summary>
        public int DeltaY;
        /// <summary>
        /// Wheel value
        /// </summary>
        public int Wheel;
        /// <summary>
        /// Left button indicator
        /// </summary>
        public bool Left;
        /// <summary>
        /// Right button indicator
        /// </summary>
        public bool Right;
        /// <summary>
        /// Middle button indicator
        /// </summary>
        public bool Middle;
        /// <summary>
        /// XButton1 button indicator
        /// </summary>
        public bool XButton1;
        /// <summary>
        /// XButton2 button indicator
        /// </summary>
        public bool XButton2;

        /// <summary>
        /// Convert the MouseState to an explicit string
        /// </summary>
        /// <returns>A string representing the MouseState</returns>
        public override string ToString()
        {
            return string.Format("Mouse state : X={0}, Y={1}, DeltaX={2}, DeltaY={3}, Wheel={4}, Left={5}, Right={6}, Middle={7}, XButton1={8}, XButton2={9}", X, Y, DeltaX, DeltaY, Wheel, Left, Right, Middle, XButton1, XButton2);
        }
    }
}
