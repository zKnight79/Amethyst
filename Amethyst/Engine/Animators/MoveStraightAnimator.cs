using Amethyst.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Amethyst.Engine.Animators
{
    public class MoveStraightAnimator : Animator
    {
        private Point m_Speed;
        public Point Speed
        {
            get { return m_Speed; }
            set { m_Speed = value; }
        }
        public float SpeedX
        {
            get { return m_Speed.X; }
            set { m_Speed.X = value; }
        }
        public float SpeedY
        {
            get { return m_Speed.Y; }
            set { m_Speed.Y = value; }
        }

        public MoveStraightAnimator(Point speed, float ttl = INFINITE_TTL) : base(ttl)
        {
            Speed = speed;
        }

        public override void Start(SceneNode node)
        {
            // Nothing to do here
        }

        protected override void UpdateNode(SceneNode node, float elapsedTime)
        {
            node.BoxPosition += Speed * elapsedTime;
        }
    }
}
