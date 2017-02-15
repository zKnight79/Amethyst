using Amethyst.Input;
using System.Collections.Generic;

namespace Amethyst.Engine
{
    /// <summary>
    /// The base Scene class
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// Get the Scene manager that hold this Scene
        /// </summary>
        public SceneManager SceneManager { get; internal set; }

        List<SceneNode> m_SceneNodes = new List<SceneNode>();

        /// <summary>
        /// Get the Scene's node count
        /// </summary>
        public int NodeCount => m_SceneNodes.Count;
        /// <summary>
        /// Remove all nodes from the Scene
        /// </summary>
        public void ClearNodes()
        {
            m_SceneNodes.Clear();
        }
        /// <summary>
        /// Add a Node to the Scene
        /// </summary>
        /// <param name="SceneNode">The Node to add</param>
        public void AddNode(SceneNode SceneNode)
        {
            m_SceneNodes.Add(SceneNode);
            m_SceneNodes.Sort((sn1, sn2) =>
            {
                if (sn1?.ZOrder == sn2?.ZOrder)
                {
                    return 0;
                } else
                {
                    return (sn1?.ZOrder > sn2?.ZOrder) ? 1 : -1;
                }
            });
        }
        /// <summary>
        /// Remove a Node from the Scene
        /// </summary>
        /// <param name="SceneNode">The Node to remove</param>
        public void RemoveNode(SceneNode SceneNode)
        {
            m_SceneNodes.Remove(SceneNode);
        }

        /// <summary>
        /// Render all the Nodes of the Scene
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used to render the Nodes</param>
        public virtual void Render(SpriteBatch spriteBatch)
        {
            foreach (SceneNode SceneNode in m_SceneNodes)
            {
                SceneNode.Render(spriteBatch);
            }
            OnRender(spriteBatch);
        }
        /// <summary>
        /// Update all the Nodes of the Scene
        /// </summary>
        /// <param name="elapsedTime">Frame time in seconds</param>
        public virtual void Update(float elapsedTime)
        {
            foreach (SceneNode SceneNode in m_SceneNodes)
            {
                SceneNode.Update(elapsedTime);
            }
            OnUpdate(elapsedTime);
        }

        /// <summary>
        /// Hook method called when the scene is pushed in a Scene manager
        /// </summary>
        public virtual void OnLoad() { }
        /// <summary>
        /// Hook method called when the scene is popped from a Scene manager
        /// </summary>
        public virtual void OnDispose() { }
        /// <summary>
        /// Hook method called when the scene become the current scene of a Scene manager
        /// </summary>
        public virtual void OnGetFocus() { }
        /// <summary>
        /// Hook method called when the scene stopped to be the current scene of a Scene manager
        /// </summary>
        public virtual void OnLoseFocus() { }
        /// <summary>
        /// Hook method called by Render(), for specific rendering tasks
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch used for rendering</param>
        public virtual void OnRender(SpriteBatch spriteBatch) { }
        /// <summary>
        /// Hook method called by Update(), for specific updating tasks
        /// </summary>
        /// <param name="elapsedTime"></param>
        public virtual void OnUpdate(float elapsedTime) { }

        /// <summary>
        /// Hook method called when a Keyboard key is pressed
        /// </summary>
        /// <param name="key">The key that is down</param>
        /// <param name="modifiers">The key modifiers</param>
        public virtual void OnKeyDown(Keys key, Keys modifiers) { }
        /// <summary>
        /// Hook method called when a Keyboard key is released
        /// </summary>
        /// <param name="key">The key that is up</param>
        /// <param name="modifiers">The key modifiers</param>
        public virtual void OnKeyUp(Keys key, Keys modifiers) { }
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
