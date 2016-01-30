using System;
using System.Collections.Generic;

using Windows.ApplicationModel;

namespace SKELETON.Model
{
    sealed class About : IAbout
    {
        public About()
        {
            Links = new List<Link>()
            {
                // TODO - add help links
                //new Link() { Text = "Help", Target = new Uri("https://github.com/dkackman", UriKind.Absolute) }
            };

            // TODO - set this to null to hide the Credits page in settings
            Credits = new List<Credit>()
            {
                // TODO - add credits
                //new Credit()
                //{
                //    Subject = "MVVM",
                //    ImageUri = new Uri("http://download-codeplex.sec.s-msft.com/Download?ProjectName=mvvmlight&amp;DownloadId=92227&amp;Build=21031")
                //}
            };
        }

        public string Name => Package.Current.DisplayName;

        public string Publisher => Package.Current.PublisherDisplayName;

        // TODO - set this to you privact statement or null to hide
        public Uri PrivacyStatement => new Uri("http://www.bing.com/search?q=privacy+statement+generator&FORM=AWRE");

        // TODO set this to non null to show a Terms of Use page 
        public Uri TermsOfUse => null;

        public string Version
        {
            get
            {
                var id = Package.Current.Id;
                return $"Version {id.Version.Major}.{id.Version.Minor}.{id.Version.Build}.{id.Version.Revision}";
            }
        }

        public string PackageFamilyName => Package.Current.Id.FamilyName;

        public string ProductId => Package.Current.Id.ProductId;

        public IEnumerable<Link> Links { get; private set; }

        public IEnumerable<Credit> Credits { get; private set; }
    }
}