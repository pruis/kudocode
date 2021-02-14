using System;
using KudoCode.Helpers;
using KudoCode.LogicLayer.Dtos.Leads;
using KudoCode.LogicLayer.Dtos.LeadScheduledActivities;
using FluentValidation;

namespace KudoCode.LogicLayer.Domain.Logic.LeadScheduledActivities.Update
{
    public class
        UpdateLeadScheduledActivityDtoValidationHandler : LeadScheduledActivityDtoValidator<
            UpdateGetLeadScheduledActivityRequest>
    {
        public UpdateLeadScheduledActivityDtoValidationHandler() : base()
        {
        }
    }


    public class LeadScheduledActivityDtoValidator<T> : AbstractValidator<T>
        where T : ILeadScheduledActivityDto
    {
        protected LeadScheduledActivityDtoValidator()
        {
            RuleFor(x => x.Address).NotNull();
            RuleFor(x => x.Address.Complex).NotEmpty();
            RuleFor(x => x.Address.AddressTypeId).NotNull().GreaterThan(0).WithMessage("Address type required");
            RuleFor(x => x.AppointmentDateTime.ToDate())
                .NotNull()
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                .WithName("Appointment Date Time");
        }
    }
}