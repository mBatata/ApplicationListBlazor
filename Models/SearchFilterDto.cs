public class SearchFilterDto
{
	public string? SearchApplicantName { get; set; }
	
	public ApplicationStatus? SearchApplicationStatus { get; set; }
	
	public SearchFilterDto() { }
	
	public SearchFilterDto(string? searchApplicantName, string? searchApplicationStatus)
	{
		this.SearchApplicantName = searchApplicantName;
		this.SearchApplicationStatus = Enum.TryParse(searchApplicationStatus, out ApplicationStatus applicationStatus) ? applicationStatus : null;
	}
}