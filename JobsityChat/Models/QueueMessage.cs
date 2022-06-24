using System;

namespace JobsityChat.Models
{
    public class QueueMessage
    {
        public QueueMessage(string senderUser, string text, string roomName)
        {
            datetime = DateTime.Now;
            SenderUser = senderUser;
            Text = text;
            RoomName = roomName;
        }

        public string SenderUser { get; set; }

        public string Text { get; set; }

        public DateTime datetime { get; set; }

        public string RoomName { get; set; }

    }
}
