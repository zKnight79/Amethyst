using Amethyst.Input;
using System.Collections.Generic;

namespace Amethyst.Engine
{
    /// <summary>
    /// Scene manager class
    /// </summary>
    public class SceneManager
    {
        Stack<Scene> m_Scenes = new Stack<Scene>();

        /// <summary>
        /// Get the Game bound to this SceneManager
        /// </summary>
        public Game Game { get; private set; }

        /// <summary>
        /// Get the current Scene
        /// </summary>
        public Scene CurrentScene => ((m_Scenes.Count < 1) ? null : m_Scenes.Peek());
        /// <summary>
        /// Get the scene count
        /// </summary>
        public int SceneCount => m_Scenes.Count;

        /// <summary>
        /// Creates a new instance of SceneManager
        /// </summary>
        /// <param name="game">Game instance to bind to the SceneManager, null to bind no Game (null by default)</param>
        public SceneManager(Game game = null)
        {
            Game = game;
        }

        /// <summary>
        /// Push a scene in the scene manager<br />
        /// Pushed scene become the Current Scene<br />
        /// Triggers :<br />
        /// - previous current scene's OnLoseFocus method<br />
        /// - new current scene's OnLoad method<br />
        /// - new current scene's OnGetFocus method
        /// </summary>
        /// <param name="scene">The Scene to push</param>
        public void PushScene(Scene scene)
        {
            CurrentScene?.OnLoseFocus();
            m_Scenes.Push(scene);
            scene.SceneManager = this;
            scene.OnLoad();
            scene.OnGetFocus();
        }
        /// <summary>
        /// Pop the current scene out of the SceneManager<br />
        /// Triggers :<br />
        /// - previous current scene's OnLoseFocus method<br />
        /// - previous current scene's OnDispose method<br />
        /// - new current scene's OnGetFocus method
        /// </summary>
        /// <returns>The popped scene or null if scene manager is empty</returns>
        public Scene PopScene()
        {
            if(m_Scenes.Count<1)
            {
                return null;
            }

            Scene s = m_Scenes.Pop();
            s.OnLoseFocus();
            s.SceneManager = null;
            s.OnDispose();

            CurrentScene?.OnGetFocus();

            return s;
        }

        /// <summary>
        /// Pop every Scene until Scene manager is empty
        /// </summary>
        public void Clear()
        {
            while (PopScene() != null) ;
        }

        /// <summary>
        /// Render the current scene
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch used to render scene's nodes</param>
        public void Render(SpriteBatch spriteBatch)
        {
            CurrentScene?.Render(spriteBatch);
        }
        /// <summary>
        /// Update the current scene
        /// </summary>
        /// <param name="elapsedTime">Frame time in seconds</param>
        public void Update(float elapsedTime)
        {
            CurrentScene?.Update(elapsedTime);
        }

        /// <summary>
        /// Triggers current scene OnKeyDown method
        /// </summary>
        /// <param name="key">The key that is down</param>
        /// <param name="modifiers">The key modifiers</param>
        public void OnKeyDown(Keys key, Keys modifiers)
        {
            CurrentScene?.OnKeyDown(key, modifiers);
        }
        /// <summary>
        /// Triggers current scene OnKeyUp method
        /// </summary>
        /// <param name="key">The key that is up</param>
        /// <param name="modifiers">The key modifiers</param>
        public void OnKeyUp(Keys key, Keys modifiers)
        {
            CurrentScene?.OnKeyUp(key, modifiers);
        }
        /// <summary>
        /// Triggers current scene OnMouseButtonDown method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseButtonDown(MouseState mouseState)
        {
            CurrentScene?.OnMouseButtonDown(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseButtonUp method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseButtonUp(MouseState mouseState)
        {
            CurrentScene?.OnMouseButtonUp(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseLeftClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseLeftClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseLeftClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseLeftDoubleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseLeftDoubleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseLeftDoubleClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseMiddleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseMiddleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseMiddleClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseMiddleDoubleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseMiddleDoubleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseMiddleDoubleClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseRightClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseRightClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseRightClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseRightDoubleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseRightDoubleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseRightDoubleClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseMove method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseMove(MouseState mouseState)
        {
            CurrentScene?.OnMouseMove(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseWheel method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseWheel(MouseState mouseState)
        {
            CurrentScene?.OnMouseWheel(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseXButton1Click method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseXButton1Click(MouseState mouseState)
        {
            CurrentScene?.OnMouseXButton1Click(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseXButton1DoubleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseXButton1DoubleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseXButton1DoubleClick(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseXButton2Click method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseXButton2Click(MouseState mouseState)
        {
            CurrentScene?.OnMouseXButton2Click(mouseState);
        }
        /// <summary>
        /// Triggers current scene OnMouseXButton2DoubleClick method
        /// </summary>
        /// <param name="mouseState">The current mouse state</param>
        public void OnMouseXButton2DoubleClick(MouseState mouseState)
        {
            CurrentScene?.OnMouseXButton2DoubleClick(mouseState);
        }
    }
}
