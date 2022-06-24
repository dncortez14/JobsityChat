using JobsityChat.Models;
using System.Collections.Generic;

namespace JobsityChat.ViewModels
{
    public class ConversationVM
    {
        public string RoomName { get; set; }

        public int RoomId { get; set;}

        public IEnumerable<Message> Messages { get; set; }
    }
}
