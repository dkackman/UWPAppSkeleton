using System;

namespace Sunlight.Model
{
    /// <summary>
    /// Describes a person or organization to be given credit on the setting page
    /// </summary>
    public sealed class Credit
    {
        /// <summary>
        /// A phrease describing what is being credited (i.e. Data provided by acme data services)
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The url to an image or logo for the dreditee
        /// </summary>
        public Uri ImageUri { get; set; }

        /// <summary>
        /// Text describing the creditee
        /// </summary>
        public string Text { get; set; }
    }
}
