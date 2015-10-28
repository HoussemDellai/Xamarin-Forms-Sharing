using SharingService.Plugin.Abstractions;
using Android.App;
using Android.Content;


namespace SharingService.Plugin
{
    /// <summary>
    /// Platform implementation for ISharingService interface.
    /// Should be set to the MainActivity instance.
    /// </summary>
    public class SharingServiceImplementation : ISharingService
  {

        /// <summary>
        /// Should be set to the MainActivity instance.
        /// </summary>
        public static Activity MainActivityInstance;

        /// <summary>
        /// Shares a title and content text.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        public void ShareText(string title, string content)
        {

            var intent = new Intent(Intent.ActionSend);
            intent.SetType("text/plain");
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, content);

            var intentChooser = Intent.CreateChooser(intent, "Share via");

            if (MainActivityInstance != null)
            {
                MainActivityInstance.StartActivityForResult(intentChooser, 1000);
            }
        }
    }
}