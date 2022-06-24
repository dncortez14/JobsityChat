using System;

namespace JobsityChat.Models
{
    public class Message
    {
        public Message(string senderUser, string text, int roomId )
        {
            datetime = DateTime.Now;
            SenderUser = senderUser;
            Text = text;
            RoomId = roomId;
        }

        public int Id { get; set; }

        public string SenderUser { get; set; }

        public string Text { get; set; }

        public int RoomId { get; set; }

        public DateTime datetime { get; set; }

    }
}
