﻿namespace Project.ForumService.Dtos.AnswersDtos
{
    public class UpdateAnswerDtos
    {
        public Guid AnswerID { get; set; }
        public string Content { get; set; }
        public List<string> Tag { get; set; }
    }
}
