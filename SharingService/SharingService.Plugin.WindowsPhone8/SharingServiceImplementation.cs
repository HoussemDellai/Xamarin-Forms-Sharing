using SharingService.Plugin.Abstractions;
using System;
using Microsoft.Phone.Tasks;


namespace SharingService.Plugin
{
    /// <summary>
    /// Platform implementation for ISharingService interface.
    /// </summary>
    public class SharingServiceImplementation : ISharingService
    {
        /// <summary>
        /// Shares a title and content text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void ShareText(string title, string content)
        {
            var shareStatusTask = new ShareStatusTask
            {
                Status = title + " : " + content
            };

            shareStatusTask.Show();
        }
    }
}