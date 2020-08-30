using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Make_Post
{
    public class Utils
    {

        public static void UserMessage(string message, Globals.MessageTypes messageType = Globals.MessageTypes.None, bool throwError = false, bool saveMessage = false, int errorCode = 0)
        {
            var msg = string.Empty;

            switch (messageType)
            {
                case Globals.MessageTypes.None:
                    break;
                case Globals.MessageTypes.Error:
                    msg = $"Error: {message}, Code = {errorCode}";
                    MessageBox.Show(msg);
                    break;
                case Globals.MessageTypes.Status:
                    msg = $"Status: {message}, Code = {errorCode}";
                    MessageBox.Show(msg);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null);
            }

            if (!throwError) return;
            throw new ApplicationException(msg);
        }
        public static bool ProcessMessageBoxYesNo(string msg, string title)
        {
            var dialogResult = MessageBox.Show(msg, title, MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }
    }
}
