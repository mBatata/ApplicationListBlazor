namespace Blazor.Data;

public class ApplicationService
{
	List<ApplicationDto>? Applications { get; set; }

	public IEnumerable<ApplicationDto> GetApplications(SearchFilterDto? searchFilter = null)
	{
		if (Applications == null)
		{
			Applications = new List<ApplicationDto>();

			for (var i = 0; i < 50; i++)
			{
				Applications.Add(
					new ApplicationDto()
					{
						Id = Guid.NewGuid(),
						ApplicantName = $"Applicant No {i}",
						ApplicationStatus =
							i % 2 == 0
								? ApplicationStatus.Processed
								: ApplicationStatus.NotProcessed
					}
				);
			}
		}

		var applications = Applications;

		if (searchFilter != null)
		{
			if (!string.IsNullOrWhiteSpace(searchFilter.SearchApplicantName))
			{
				applications = applications
					.Where(x => x.ApplicantName!.Contains(searchFilter.SearchApplicantName))
					.ToList();
			}

			if (searchFilter.SearchApplicationStatus != null)
			{
				applications = applications
					.Where(x => x.ApplicationStatus == searchFilter.SearchApplicationStatus)
					.ToList();
			}
		}

		return applications;
	}
	
	public ApplicationDto UpdateApplication(ApplicationDto newApplication)
	{
		var application = Applications?.FirstOrDefault(x => x.Id == newApplication.Id);

		if (application == null)
		{
			throw new NullReferenceException(nameof(application));
		}

		application.ApplicantName = newApplication.ApplicantName;
		application.ApplicationStatus = newApplication.ApplicationStatus;
		
		return application;
	}
}
