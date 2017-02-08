namespace Amethyst.Engine
{
    /// <summary>
    /// Base animator class
    /// </summary>
    public abstract class Animator
    {
        /// <summary>
        /// Value to use for an infinite animation
        /// </summary>
        public const float INFINITE_TTL = -1;

        /// <summary>
        /// Get the "Time To Live" of the animator (in seconds)<br />
        /// Equals INFINITE_TTL for infinite animation
        /// </summary>
        protected float TTL { get; private set; }

        /// <summary>
        /// Constructor of an Animator
        /// </summary>
        /// <param name="ttl">The TTL (in seconds) of the animator. Default : INFINITE_TTL</param>
        public Animator(float ttl = INFINITE_TTL)
        {
            TTL = ttl;
        }

        private void UpdateTTL(float elapsedTime)
        {
            if (TTL != INFINITE_TTL)
            {
                TTL -= elapsedTime;
                if (TTL <= 0)
                {
                    Finish();
                }
            }
        }

        /// <summary>
        /// Start method is called by the node at attaching time
        /// </summary>
        /// <param name="node">The node which attach the animator</param>
        public abstract void Start(SceneNode node);
        /// <summary>
        /// UpdateNode is called every time the animator is updating
        /// </summary>
        /// <param name="node">The node to update</param>
        /// <param name="elapsedTime">The time elapsed since last call</param>
        protected abstract void UpdateNode(SceneNode node, float elapsedTime);
        /// <summary>
        /// Update is called every time the node needs to be updated by the animator
        /// </summary>
        /// <param name="node">The node to update</param>
        /// <param name="elapsedTime">The time elapsed since last call</param>
        public void Update(SceneNode node, float elapsedTime)
        {
            UpdateNode(node, elapsedTime);
            UpdateTTL(elapsedTime);
        }
        private void Finish()
        {
            Finished?.Invoke(this);
        }

        /// <summary>
        /// Event triggered when the TTL reaches zero
        /// </summary>
        public event AnimatorEventHandler Finished;
    }

    /// <summary>
    /// Event handler for animator
    /// </summary>
    /// <param name="animator">The animator that triggered the event</param>
    public delegate void AnimatorEventHandler(Animator animator);
}
