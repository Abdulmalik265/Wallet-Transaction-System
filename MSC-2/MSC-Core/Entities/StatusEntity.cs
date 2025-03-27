namespace MSC_Core.Entities;

public class StatusEntity : Base
{
    public string Status { get; set; }
    public long HistoryId { get; set; }

    public History History { get; set; }
    
}