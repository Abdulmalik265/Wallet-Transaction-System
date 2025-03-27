namespace MSC_Core.Entities;

public class History : Base
{
    public string Comment { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentBy { get; set; }

    public long? SettlementId { get; set; }
    public long? MerchantId { get; set; }
    public long? SysConfigId { get; set; }


    public StatusEntity Statuss { get; set; }
    public Settelement Settlements { get; set; }
    public Merchant Merchants { get; set; }
    public Config SysConfigEntity { get; set; }
}