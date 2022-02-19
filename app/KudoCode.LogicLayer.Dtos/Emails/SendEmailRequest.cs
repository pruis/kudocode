using KudoCode.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace KudoCode.LogicLayer.Dtos.Emails
{
	public class SendEmailRequest : IApiRequestDto
    {
        public int ApplicationUserId { get; set; }
        public int LeadId { get; set; }
    }

    public class SendEmailResponse : IApiResponseDto
    {
        [HiddenInput]
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; }
        //[MaxLength(5)]
        public string Address { get; set; }
        //[Range(typeof(DateTime), "1/2/2004", "3/4/2004",
        //  ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime Date { get; set; }// = new DateTime(2014, 4, 2);
    }
}