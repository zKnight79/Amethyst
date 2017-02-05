namespace Amethyst.Graphics
{
    /// <summary>
    /// Specify the anti-aliasing level of the GL Context
    /// </summary>
    public enum AntiAliasingLevel
    {
        /// <summary>
        /// No anti-aliasing
        /// </summary>
        None = 0,
        /// <summary>
        /// 2x anti-aliasing
        /// </summary>
        MSAA_2X = 2,
        /// <summary>
        /// 4x anti-aliasing
        /// </summary>
        MSAA_4X = 4,
        /// <summary>
        /// 8x anti-aliasing
        /// </summary>
        MSAA_8X = 8,
        /// <summary>
        /// 16x anti-aliasing
        /// </summary>
        MSAA_16X = 16,
        /// <summary>
        /// 32x anti-aliasing
        /// </summary>
        MSAA_32X = 32
    }
}
