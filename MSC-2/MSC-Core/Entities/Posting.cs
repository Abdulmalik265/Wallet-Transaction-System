namespace MSC_Core.Entities;

public class Posting : Base
{
    public decimal? Amount { get; set; }
    public string DebitAccount { get; set; }
    public string TransCurrencyCode { get; set; }
    public string InstrumentType { get; set; }
    public string InstrumentNumber { get; set; }
    public string TransactionType { get; set; } // cr/dr
    public string ToFromBankCode { get; set; }
    public string BeneficiaryAccount { get; set; }
    public string TransactionNarration { get; set; }
    public string Remark1 { get; set; }
    public string Remark2 { get; set; }
    public string AccountName { get; set; }
    public string PostingCategory { get; set; } //merchnat/account
    public string MerchantCode { get; set; }
    public int LineNumber { get; set; }

    public long? SettlementId { get; set; }

    public Settelement Settlements { get; set; }
    
}