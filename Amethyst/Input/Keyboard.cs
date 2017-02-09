using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Amethyst.Input
{
    /// <summary>
    /// Class representing the Keyboard
    /// </summary>
    public class Keyboard
    {
        private Dictionary<Keys, bool> m_KeyStates = new Dictionary<Keys, bool>();

        /// <summary>
        /// The control that is bounded by the keyboard
        /// </summary>
        public Control Control { get; private set; }
        /// <summary>
        /// Get the state of a key
        /// </summary>
        /// <param name="key">The key we want to know the state</param>
        /// <returns>true if the key is being pressed, false otherwise</returns>
        public bool this[Keys key]
        {
            get { return m_KeyStates[key]; }
            set { m_KeyStates[key] = value; }
        }

        /// <summary>
        /// Instantiates a new Keyboard
        /// </summary>
        /// <param name="control">The control that is bounded by the keyboard</param>
        public Keyboard(Control control)
        {
            Control = control;
            Control.KeyDown += new KeyEventHandler(Control_KeyDown);
            Control.KeyUp += new KeyEventHandler(Control_KeyUp);
            
            foreach (Keys key in Enum.GetValues(typeof(Keys)))
            {
                m_KeyStates[key] = false;
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            Keys key = (Keys)e.KeyCode;
            m_KeyStates[key] = true;
            KeyDown?.Invoke(key, (Keys)e.Modifiers);
        }
        private void Control_KeyUp(object sender, KeyEventArgs e)
        {
            Keys key = (Keys)e.KeyCode;
            m_KeyStates[key] = false;
            KeyUp?.Invoke(key, (Keys)e.Modifiers);
        }

        /// <summary>
        /// An event that is fired when a key is just pressed down
        /// </summary>
        public event KeyboardEvent KeyDown;
        /// <summary>
        /// An event that is fired when a key is just released
        /// </summary>
        public event KeyboardEvent KeyUp;
    }

    /// <summary>
    /// Represent the method that will handle an event that has a key and key modifiers for parameters
    /// </summary>
    /// <param name="key">The key that triggered the event</param>
    /// <param name="modifiers">The modifiers associated to the key</param>
    public delegate void KeyboardEvent(Keys key, Keys modifiers);
}
