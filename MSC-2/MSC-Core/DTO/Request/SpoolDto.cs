namespace MSC_Core.DTO.Request;

public class SpoolDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public int Count { get; set; }
    public int Sort { get; set; } = 1; // 1= ascending
}