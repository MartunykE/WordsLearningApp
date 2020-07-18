using System;

namespace WordsLearningApp.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public long ChatId { get; set; }
        public string Name { get; set; }
        public DateTime StartSendWordTime { get; set; }
        public DateTime FinishSendWordTime { get; set; }

    }


}
