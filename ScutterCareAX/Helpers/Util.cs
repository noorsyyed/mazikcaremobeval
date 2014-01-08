using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.UI.Popups;

namespace MazikCare.MobEval.Helpers
{
    public class Util
    {
        public static void HandleException(Exception ex, string defaultMsg)
        {
            ShowToast(defaultMsg);

        }

        public static void ShowToast(string msg)
        {
            var toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText01);
            var elements = toastXml.GetElementsByTagName("text");
            elements[0].AppendChild(toastXml.CreateTextNode(msg));
            var toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public static async void ShowDialog(string msg)
        {
            var dlg = new MessageDialog(msg);
            dlg.Commands.Add(new UICommand("Ok"));
            await dlg.ShowAsync();
        }

    }
}
