namespace MSC_Core.Entities;

public class Validation : Base
{
    public string CompareFrom { get; set; }
    public string CompareTo { get; set; }
    public string CompareFromValue { get; set; }
    public string CompareToValue { get; set; }
    public string Status { get; set; }
    public string Type { get; set; }

    public long? SettlementId { get; set; }

    public Settelement Settlements { get; set; }
    
}