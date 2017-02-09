namespace Amethyst.Engine.Animators
{
    /// <summary>
    /// An animator to make a node to spin around
    /// </summary>
    public class RotateAnimator : Animator
    {
        /// <summary>
        /// Get or set the Rotation speed (in degrees per second)
        /// </summary>
        public float RotationSpeed { get; set; }

        /// <summary>
        /// Creates an instance of RotationAnimator, with a rotation speed (in degrees per second), and a TTL (in seconds)
        /// </summary>
        /// <param name="rotationSpeed"></param>
        /// <param name="ttl"></param>
        public RotateAnimator(float rotationSpeed, float ttl = INFINITE_TTL) : base(ttl)
        {
            RotationSpeed = rotationSpeed;
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
        /// Update the angle of the node
        /// </summary>
        /// <param name="node">The node who calls the animator for an update</param>
        /// <param name="animDuration">The animation duration</param>
        protected override void UpdateNode(SceneNode node, float animDuration)
        {
            node.Angle += RotationSpeed * animDuration;
        }
    }
}
