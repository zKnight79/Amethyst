using Amethyst.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine.Animators
{
    /// <summary>
    /// An Animator to make a node move straight in a given direction
    /// </summary>
    public class MoveStraightAnimator : Animator
    {
        private Point m_Speed;
        /// <summary>
        /// Get or set the movement speed along X and Y axis
        /// </summary>
        public Point Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }
        /// <summary>
        /// Get or set the movement speed along the X axis
        /// </summary>
        public float SpeedX
        {
            get { return m_Speed.X; }
            set { m_Speed.X = value; }
        }
        /// <summary>
        /// Get or set the movement speed along the Y axis
        /// </summary>
        public float SpeedY
        {
            get { return m_Speed.Y; }
            set { m_Speed.Y = value; }
        }

        /// <summary>
        /// Creates an new MoveStraightAnimator instance giving an axis-based speed and an additional TTL (default infinite)
        /// </summary>
        /// <param name="speed"></param>
        /// <param name="ttl"></param>
        public MoveStraightAnimator(Point speed, float ttl = INFINITE_TTL) : base(ttl)
        {
            Speed = speed;
        }
        /// <summary>
        /// Creates an new MoveStraightAnimator instance giving an angle, a speed and a TTL (default infinite)<br />
        /// Angle and speed are converted into the "Point Speed" property
        /// </summary>
        /// <param name="directionAngle">The direction the node will follow</param>
        /// <param name="distancePerSecond">The speed the node will move</param>
        /// <param name="ttl"></param>
        public MoveStraightAnimator(float directionAngle, float distancePerSecond, float ttl = INFINITE_TTL)
            : this(new Point(Helper.Cos(directionAngle) * distancePerSecond, Helper.Sin(directionAngle) * distancePerSecond), ttl)
        {
        }

        /// <summary>
        /// Start method is called by the node at attaching time<br />
        /// Currently does nothing for this kind of animator
        /// </summary>
        /// <param name="node">The node who starts the animation</param>
        public override void Start(SceneNode node)
        {
            // Nothing to do here
        }

        /// <summary>
        /// Update the position of the node
        /// </summary>
        /// <param name="node">The node who calls the animator for an update</param>
        /// <param name="animDuration">The animation duration</param>
        protected override void UpdateNode(SceneNode node, float animDuration)
        {
            node.BoxPosition += Speed * animDuration;
        }
    }
}
