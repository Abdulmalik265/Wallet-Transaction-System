namespace MSC_Core.Entities;

public class Document : Base
{
    public string FileName { get; set; }
    public string ContentOrPath { get; set; }
    public string ContentType { get; set; }
    public string FileSize { get; set; }
    public string FileTimeSpan { get; set; }
    public string DocumentOwner { get; set; }
 
    public long? SettlementId { get; set; }

    public Settelement Settelements { get; set; }
}