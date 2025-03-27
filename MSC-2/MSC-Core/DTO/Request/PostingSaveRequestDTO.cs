namespace MSC_Core.DTO.Request;

public class PostingSaveRequestDTO
{
    public long Id { get; set; }
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
    public int PostingLineType { get; set; }
    public int Posted { get; set; }
    public string FinacleRefNo { get; set; }
    public string PostedBy { get; set; }
    public string PostedDate { get; set; }
    public string PostedByIp { get; set; }

    public long? SettlementId { get; set; }
}