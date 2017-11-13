using Line.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB10.Bot.Library.LINE
{
    public class Messaging
    {
        private string _accessToken;

        public Messaging(string accessToken)
        {
            _accessToken = accessToken;
        }

        public void Push(string targetUserID, string message)
        {
            LineMessagingClient lineMessagingClient = new LineMessagingClient(_accessToken);
            lineMessagingClient.PushMessageAsync(targetUserID, message);
        }
    }
}
