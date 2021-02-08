namespace Suftnet.Co.Bima.Api.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class AnswerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDt { get; set; }
        public string CreatedBy { get; set; }        
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    public class CreateAnswerDto
    {
        public Guid QuestionId { get; set; }
        public string Description { get; set; }
    }
}
