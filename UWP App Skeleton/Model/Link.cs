using System;

namespace Sunlight.Model
{
    public sealed class Link
    {
        public string Text { get; internal set; }
        public Uri Target { get; internal set; }
    }
}
