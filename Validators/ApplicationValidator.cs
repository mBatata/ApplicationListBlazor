using FluentValidation;

public class ApplicationValidator : AbstractValidator<ApplicationDto>
{
	public ApplicationValidator(TranslationService translationService)
	{
		this.RuleFor(x => x.ApplicantName)
			.NotEmpty()
			.WithMessage(translationService.GetRequiredMessage(nameof(ApplicationDto.ApplicantName)));
			
		this.RuleFor(x => x.ApplicationStatus)
			.NotEmpty()
			.WithMessage(translationService.GetRequiredMessage(nameof(ApplicationDto.ApplicationStatus)));		
	}
}