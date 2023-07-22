namespace Blazor.Helpers;

public static class EnumHelper
{
	public static IDictionary<string, string> GetApplicationStatuses()
	{
		var applicationStatuses = new Dictionary<string, string>();

		foreach (var applicationStatus in Enum.GetValues<ApplicationStatus>())
		{
			applicationStatuses.Add(applicationStatus.ToString(), GetEnumTranslation(applicationStatus!));
		}

		return applicationStatuses;
	}

	public static string GetEnumTranslation(object value)
	{
		var enumTranslation = value.ToString()!;

		if (value is ApplicationStatus applicationStatus)
		{
			return applicationStatus switch
			{
				ApplicationStatus.Processed => "Processed",
				ApplicationStatus.NotProcessed => "Not Processed",
				_ => enumTranslation
			};
		}

		return enumTranslation;
	}
}