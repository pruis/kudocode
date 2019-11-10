using KudoCode.LogicLayer.Infrastructure.Dtos;
using KudoCode.LogicLayer.Infrastructure.Dtos.Requests.Interfaces;

namespace KudoCode.LogicLayer.Dtos.Emails
{
    public class SendEmailRequest : IApiRequestDto
    {
        public int ApplicationUserId { get; set; }
        public int LeadId { get; set; }
    }

    public class SendEmailResponse : IApiRequestDto
    {
        public int Id { get; set; }
    }
}