using System;
using System.Collections.Generic;

namespace Sunlight.Model
{
    /// <summary>
    /// Interface the describes basic meta-data about an app
    /// </summary>
    public interface IAbout
    {
        /// <summary>
        /// The app's friendly name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The publisher name of the app
        /// </summary>
        string Publisher { get; }

        /// <summary>
        /// The app's non-friendly name
        /// </summary>
        string PackageFamilyName { get; }

        /// <summary>
        /// The app-x product id
        /// </summary>
        string ProductId { get; }

        /// <summary>
        /// The version of the app
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Link to a privacy statement
        /// </summary>
        Uri PrivacyStatement { get; }

        /// <summary>
        /// Link to a terms of use statement
        /// </summary>
        Uri TermsOfUse { get; }

        /// <summary>
        /// A collection of <see cref="Link"/>s to show on the about page
        /// </summary>
        IEnumerable<Link> Links { get; }

        /// <summary>
        /// A collection of <see cref="Credit"/>s to display opn the settings page
        /// </summary>
        IEnumerable<Credit> Credits { get; }
    }
}
