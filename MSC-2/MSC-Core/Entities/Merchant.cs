using System.ComponentModel.DataAnnotations;

namespace MSC_Core.Entities;

public class Merchant : Base
{
    [Required]
    public string MerchantCode { get; set; }
    [Required]
    public string MerchantName { get; set; }
    public string MerchantAccountNo { get; set; }
    public string MscFeeFixed { get; set; }
    public decimal? MscFeePercent { get; set; }
    public decimal? MscFeeCap { get; set; }
    public string DefaultWebNarration { get; set; }
    public string DefaultMigsNarration { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }
    public string BranchCode { get; set; }
    public string AccountCurrency { get; set; }
    public string Channel { get; set; }
    public string Status { get; set; }
    public string SinglePosting { get; set; }


    
    public ICollection<History> Histories { get; set; }
    
}