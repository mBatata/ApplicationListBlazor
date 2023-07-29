using FluentValidation;
using FluentValidation.Internal;

public class ApplicationValidator : AbstractValidator<ApplicationDto>
{
	public ApplicationValidator(TranslationService translationService, IValidator<LocationDto> locationValidator)
	{
		this.RuleFor(x => x.ApplicantName)
			.NotEmpty()
			.WithMessage(translationService.GetRequiredMessage(nameof(ApplicationDto.ApplicantName)));
			
		this.RuleFor(x => x.ApplicationStatus)
			.NotEmpty()
			.WithMessage(translationService.GetRequiredMessage(nameof(ApplicationDto.ApplicationStatus)));

		this.RuleFor(x => x.Location!)
			.SetValidator(locationValidator);
	}
}