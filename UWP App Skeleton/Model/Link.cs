using System;

namespace SKELETON.Model
{
    /// <summary>
    /// Used to describe hyper links that will be created on the about page
    /// </summary>
    public sealed class Link
    {
        /// <summary>
        /// The text of the link
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// The target of the link
        /// </summary>
        public Uri Target { get; internal set; }
    }
}
