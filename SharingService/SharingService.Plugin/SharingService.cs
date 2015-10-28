using SharingService.Plugin.Abstractions;
using System;

namespace SharingService.Plugin
{
    /// <summary>
    /// Cross platform SharingService implemenations
    /// </summary>
    public class SharingService
    {
        static Lazy<ISharingService> Implementation = new Lazy<ISharingService>(() => CreateSharingService(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Current settings to use
        /// </summary>
        private static ISharingService Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        /// <summary>
        /// Shares a title and content text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void ShareText(string title, string content)
        {
            Current.ShareText(title, content);
        }

        static ISharingService CreateSharingService()
        {
#if PORTABLE
            return null;
#else
        return new SharingServiceImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}
