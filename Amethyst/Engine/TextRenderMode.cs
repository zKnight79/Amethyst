namespace Amethyst.Engine
{
    /// <summary>
    /// Enumerate Text rendering modes
    /// </summary>
    public enum TextRenderMode
    {
        /// <summary>
        /// Text must be rendered on an unique line
        /// </summary>
        Inline,
        /// <summary>
        /// Text must be rendered in a Box, using line break when no more space is available in the current line
        /// </summary>
        Box
    }
}
