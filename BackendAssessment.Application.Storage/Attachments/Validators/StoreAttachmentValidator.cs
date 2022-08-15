using BackendAssessment.Application.Storage.Dtos;
using FluentValidation;

namespace BackendAssessment.Application.Storage.Validators
{
    public class StoreAttachmentValidator : AbstractValidator<AttachmentContentDto>
    {
        public StoreAttachmentValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(model => model.Content).NotEmpty();
            RuleFor(model => model.Attachment).NotEmpty();
            RuleFor(model => model.Attachment.Id).NotEmpty();
            RuleFor(model => model.Attachment.Name).NotEmpty();
            RuleFor(model => model.Attachment.Size).NotEmpty();
            RuleFor(model => model.Attachment.ContentType).NotEmpty();
        }
    }
}