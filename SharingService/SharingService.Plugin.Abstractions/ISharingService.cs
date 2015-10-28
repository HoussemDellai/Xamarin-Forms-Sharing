using System;

namespace SharingService.Plugin.Abstractions
{
    /// <summary>
    /// Interface for sharing text cross Android and Windows Phone.
    /// </summary>
    public interface ISharingService
    {
        /// <summary>
        /// Shares a title and content text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        void ShareText(string title, string content);
    }
}
