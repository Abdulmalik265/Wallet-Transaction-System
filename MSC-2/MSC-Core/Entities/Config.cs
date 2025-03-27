namespace MSC_Core.Entities;

public class Config : BaseCommon 
{
    public string VatAccountNo { get; set; }
    public string IncomeAccountNo { get; set; }
    public string ExpenseAccountNo { get; set; }
    public string InterswitchDebitAcctNo { get; set; }
    public string StanbicWebPayNarration { get; set; }
    public string InterswitchWebPayNarration { get; set; }
    public string Status { get; set; }
    public string ToFromBankCode { get; set; }
    public string PostingBenefActName { get; set; }
    public string PostingDebitActName { get; set; }
    public string PostingRemark1 { get; set; }
    public string PostingRemark2 { get; set; }
    public string WebSettlementAccount { get; set; }
    public string Vat { get; set; }
    public string MscGenericFee { get; set; }
    public string MscGenericFeeCap { get; set; }

    public string WebSetlDisctActName { get; set; }
    public string WebSetlDisctNarration { get; set; }
    public string WebSetlMerchantNarration { get; set; }
    public string WebSetlCIPGNarration { get; set; }
    public string WebSetlVatNarration { get; set; }
    public string WebSetlVatName { get; set; }


    public ICollection<History> Histories { get; set; }
    
}