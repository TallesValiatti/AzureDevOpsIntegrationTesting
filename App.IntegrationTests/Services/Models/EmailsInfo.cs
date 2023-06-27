namespace App.IntegrationTests.Services.Models
{
	public class EmailsInfo
	{
        public int Total { get; set; }
        public IEnumerable<string> Subjects { get; set; } = default!;
    }
}