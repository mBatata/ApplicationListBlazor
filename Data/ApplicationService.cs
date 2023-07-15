namespace Blazor.Data;

public class ApplicationService
{
	public IEnumerable<ApplicationDto> GetApplications(SearchFilterDto? searchFilter = null)
	{
		var applications = new List<ApplicationDto>();
		
		for (var i = 0; i < 50; i++)
		{
			applications.Add(new ApplicationDto()
			{
				Id = Guid.NewGuid(),
				ApplicantName = $"Applicant No {i}",
				ApplicationStatus = i % 2 == 0 ? ApplicationStatus.Processed : ApplicationStatus.NotProcessed
			});
		}

		if (searchFilter != null)
		{
			if (!string.IsNullOrWhiteSpace(searchFilter.SearchApplicantName))
			{
				applications = applications.Where(x => x.ApplicantName!.Contains(searchFilter.SearchApplicantName)).ToList();
			}

			if (searchFilter.SearchApplicationStatus != null)
			{
				applications = applications.Where(x => x.ApplicationStatus == searchFilter.SearchApplicationStatus).ToList();
			}
		}

		return applications;
	}
}