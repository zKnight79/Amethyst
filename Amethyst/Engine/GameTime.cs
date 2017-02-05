using System;

namespace Amethyst.Engine
{
    /// <summary>
    /// Represents the game time
    /// </summary>
    public class GameTime
    {
        DateTime m_LastFrame;
        DateTime m_CurrentFrame;
        int m_Counter = 0;
        float m_CounterTime = 0;
        /// <summary>
        /// Get the elapsed time since the last frame
        /// </summary>
        public float ElapsedTime { get; private set; }
        /// <summary>
        /// Get the total tunning time of the main loop
        /// </summary>
        public float TotalRunningTime { get; private set; }
        /// <summary>
        /// Get the total session time. Session time is user controled by ResetSession() method
        /// </summary>
        public float SessionTime { get; private set; }
        /// <summary>
        /// Get the number of frames for the last elapsed second
        /// </summary>
        public int FramesPerSecond { get; private set; }
        /// <summary>
        /// Get the last frame time
        /// </summary>
        public TimeSpan LastFrameTime { get; private set; }

        /// <summary>
        /// Creates a new GameTime
        /// </summary>
        public GameTime()
        {
            m_LastFrame = DateTime.Now;
            m_CurrentFrame = m_LastFrame;
            LastFrameTime = m_CurrentFrame.Subtract(m_LastFrame);
            ElapsedTime = 0.0f;
            TotalRunningTime = 0.0f;
            SessionTime = 0.0f;
        }
        
        /// <summary>
        /// Update the GameTime, sould be called once and only once per frame
        /// </summary>
        public void Update()
        {
            m_LastFrame = m_CurrentFrame;
            m_CurrentFrame = DateTime.Now;
            LastFrameTime = m_CurrentFrame.Subtract(m_LastFrame);
            ElapsedTime = ((float)LastFrameTime.TotalMilliseconds) / 1000.0f;
            TotalRunningTime += ElapsedTime;
            SessionTime += ElapsedTime;

            m_Counter++;
            m_CounterTime += ElapsedTime;
            if (m_CounterTime >= 1)
            {
                FramesPerSecond = m_Counter;
                m_Counter = 0;
                m_CounterTime -= 1;
            }
        }
        /// <summary>
        /// Reset Session time
        /// </summary>
        public void ResetSession()
        {
            SessionTime = 0.0f;
        }
    }
}
