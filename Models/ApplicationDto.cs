public class ApplicationDto
{
	public Guid  Id { get; set; }
	
	public string? ApplicantName { get; set; }
	
	public ApplicationStatus? ApplicationStatus { get; set; }
}