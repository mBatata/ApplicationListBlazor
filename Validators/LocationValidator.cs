using FluentValidation;

public class LocationValidator : AbstractValidator<LocationDto>
{
	public LocationValidator(TranslationService translationService)
	{
		this.RuleFor(x => x.Address)
			.NotEmpty()
			.WithMessage(translationService.GetRequiredMessage(nameof(LocationDto.Address)));
	}
}