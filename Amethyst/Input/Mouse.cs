using System;
using System.Drawing;
using System.Windows.Forms;

namespace Amethyst.Input
{
    /// <summary>
    /// Class representing the Mouse
    /// </summary>
    public class Mouse
    {
        private MouseState m_MouseState;
        private bool m_MoveEventFiredSinceUpdated = false;
        private bool m_WheelEventFiredSinceUpdated = false;

        /// <summary>
        /// The control that is bounded by the mouse
        /// </summary>
        public Control Control { get; private set; }
        /// <summary>
        /// Get the current mouse state
        /// </summary>
        public MouseState MouseState => m_MouseState;

        /// <summary>
        /// Instantiate a new Mouse
        /// </summary>
        /// <param name="control">The control that is bounded by the mouse</param>
        public Mouse(Control control)
        {
            m_MouseState = new MouseState();
            Control = control;
            Point p = Control.PointToClient(Cursor.Position);
            m_MouseState.X = p.X;
            m_MouseState.Y = p.Y;
            m_MouseState.DeltaX = 0;
            m_MouseState.DeltaY = 0;
            m_MouseState.Wheel = 0;
            m_MouseState.Left = false;
            m_MouseState.Right = false;
            m_MouseState.Middle = false;
            m_MouseState.XButton1 = false;
            m_MouseState.XButton2 = false;

            Control.MouseMove += new MouseEventHandler(Control_MouseMove);
            Control.MouseDown += new MouseEventHandler(Control_MouseDown);
            Control.MouseUp += new MouseEventHandler(Control_MouseUp);
            Control.MouseWheel += new MouseEventHandler(Control_MouseWheel);
            Control.MouseClick += new MouseEventHandler(Control_MouseClick);
            Control.MouseDoubleClick += new MouseEventHandler(Control_MouseDoubleClick);
            Control.MouseEnter += new EventHandler(Control_MouseEnter);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if ((m_MouseState.X == e.X) && (m_MouseState.Y == e.Y))
            {
                return;
            }
            
            m_MoveEventFiredSinceUpdated = true;

            m_MouseState.DeltaX = e.X - m_MouseState.X;
            m_MouseState.DeltaY = e.Y - m_MouseState.Y;
            m_MouseState.X = e.X;
            m_MouseState.Y = e.Y;

            Move?.Invoke(m_MouseState);
        }
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    m_MouseState.Left = true;
                    break;
                case MouseButtons.Right:
                    m_MouseState.Right = true;
                    break;
                case MouseButtons.Middle:
                    m_MouseState.Middle = true;
                    break;
                case MouseButtons.XButton1:
                    m_MouseState.XButton1 = true;
                    break;
                case MouseButtons.XButton2:
                    m_MouseState.XButton2 = true;
                    break;
            }

            ButtonDown?.Invoke(m_MouseState);
        }
        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    m_MouseState.Left = false;
                    break;
                case MouseButtons.Right:
                    m_MouseState.Right = false;
                    break;
                case MouseButtons.Middle:
                    m_MouseState.Middle = false;
                    break;
                case MouseButtons.XButton1:
                    m_MouseState.XButton1 = false;
                    break;
                case MouseButtons.XButton2:
                    m_MouseState.XButton2 = false;
                    break;
            }

            ButtonUp?.Invoke(m_MouseState);
        }
        private void Control_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta == 0)
            {
                return;
            }
            
            m_WheelEventFiredSinceUpdated = true;

            m_MouseState.Wheel += e.Delta;

            Wheel?.Invoke(m_MouseState);
        }
        private void Control_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    LeftClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.Right:
                    RightClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.Middle:
                    MiddleClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.XButton1:
                    XButton1Click?.Invoke(m_MouseState);
                    break;
                case MouseButtons.XButton2:
                    XButton2Click?.Invoke(m_MouseState);
                    break;
            }
        }
        private void Control_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    LeftDoubleClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.Right:
                    RightDoubleClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.Middle:
                    MiddleDoubleClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.XButton1:
                    XButton1DoubleClick?.Invoke(m_MouseState);
                    break;
                case MouseButtons.XButton2:
                    XButton2DoubleClick?.Invoke(m_MouseState);
                    break;
            }
        }
        private void Control_MouseEnter(object sender, EventArgs e)
        {
            Point p = Control.PointToClient(Cursor.Position);
            m_MouseState.X = p.X;
            m_MouseState.Y = p.Y;
            m_MouseState.DeltaX = 0;
            m_MouseState.DeltaY = 0;
        }

        /// <summary>
        /// Update the current mouse state
        /// </summary>
        public void Update()
        {
            #region ZERO MOVE DELTA IF NO MOVE EVENT FIRED
            if (!m_MoveEventFiredSinceUpdated)
            {
                m_MouseState.DeltaX = 0;
                m_MouseState.DeltaY = 0;
            }
            else
            {
                m_MoveEventFiredSinceUpdated = false;
            }
            #endregion
            #region ZERO MOVE WHEEL IF NO MOVE EVENT FIRED
            if (!m_WheelEventFiredSinceUpdated)
            {
                m_MouseState.Wheel = 0;
            }
            else
            {
                m_WheelEventFiredSinceUpdated = false;
            }
            #endregion
        }

        /// <summary>
        /// Force a new position for the mouse
        /// </summary>
        /// <param name="x">The new X coordinate</param>
        /// <param name="y">The new Y coordinate</param>
        public void SetPosition(int x, int y)
        {
            m_MouseState.X = x;
            m_MouseState.Y = y;
            Cursor.Position = Control.PointToScreen(new Point(m_MouseState.X, m_MouseState.Y));
            m_MouseState.DeltaX = 0;
            m_MouseState.DeltaY = 0;
        }
        /// <summary>
        /// Force a new position for the mouse
        /// </summary>
        /// <param name="p">The new coordinates</param>
        public void SetPosition(Math.Point p)
        {
            SetPosition((int)p.X, (int)p.Y);
        }

        /// <summary>
        /// Make the mouse invisible
        /// </summary>
        public void Hide()
        {
            Cursor.Hide();
        }
        /// <summary>
        /// Make the mouse visible
        /// </summary>
        public void Show()
        {
            Cursor.Show();
        }

        /// <summary>
        /// An event that is fired when the mouse moves
        /// </summary>
        public event MouseEvent Move;
        /// <summary>
        /// An event that is fired when a mouse button is just down
        /// </summary>
        public event MouseEvent ButtonDown;
        /// <summary>
        /// An event that is fired when a mouse button is just released
        /// </summary>
        public event MouseEvent ButtonUp;
        /// <summary>
        /// An event that is fired when the mouse wheel is rolled
        /// </summary>
        public event MouseEvent Wheel;
        /// <summary>
        /// An event that is fired when a left click occurs
        /// </summary>
        public event MouseEvent LeftClick;
        /// <summary>
        /// An event that is fired when a left double click occurs
        /// </summary>
        public event MouseEvent LeftDoubleClick;
        /// <summary>
        /// An event that is fired when a right click occurs
        /// </summary>
        public event MouseEvent RightClick;
        /// <summary>
        /// An event that is fired when a right double click occurs
        /// </summary>
        public event MouseEvent RightDoubleClick;
        /// <summary>
        /// An event that is fired when a middle click occurs
        /// </summary>
        public event MouseEvent MiddleClick;
        /// <summary>
        /// An event that is fired when a middle double click occurs
        /// </summary>
        public event MouseEvent MiddleDoubleClick;
        /// <summary>
        /// An event that is fired when a XButton1 click occurs
        /// </summary>
        public event MouseEvent XButton1Click;
        /// <summary>
        /// An event that is fired when a XButton1 double click occurs
        /// </summary>
        public event MouseEvent XButton1DoubleClick;
        /// <summary>
        /// An event that is fired when a XButton2 click occurs
        /// </summary>
        public event MouseEvent XButton2Click;
        /// <summary>
        /// An event that is fired when a XButton2 double click occurs
        /// </summary>
        public event MouseEvent XButton2DoubleClick;
    }

    /// <summary>
    /// Represent the method that will handle an event that has a mouse state for parameter
    /// </summary>
    /// <param name="mouseState">The mouse state when the event was triggered</param>
    public delegate void MouseEvent(MouseState mouseState);
}
