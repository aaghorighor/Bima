namespace Suftnet.Co.Bima.Api.Models
{
    using System;

    public class QuestionDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public int? AnswerCount { get; set; }
        public Guid Id { get; set; }

    }

    public class CreateQuestionDto
    {
        public string Description { get; set; }
    }

}