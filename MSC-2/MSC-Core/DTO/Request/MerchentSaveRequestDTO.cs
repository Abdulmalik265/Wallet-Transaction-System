using System.Text.Json.Serialization;

namespace MSC_Core.DTO.Request;

public class MerchentSaveRequestDTO
{
    public long Id { get; set; }
    public string MerchantCode { get; set; }
    public string MerchantName { get; set; }
    public string MerchantAccountNo { get; set; }
    public string MscFeeFixed { get; set; }
    public decimal MscFeePercent { get; set; }
    public decimal MscFeeCap { get; set; }
    public string DefaultWebNarration { get; set; }
    public string DefaultMigsNarration { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }
    public string BranchCode { get; set; }
    public string UserEmail { get; set; }
    public string AccountCurrency { get; set; }
    public string Channel { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public string SinglePosting { get; set; }




    [JsonIgnore]
    public string UserAction { get; set; }
    [JsonIgnore]
    public string UserName { get; set; }
}