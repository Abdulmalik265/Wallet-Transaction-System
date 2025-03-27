namespace MSC_Core.DTO.Request;

public class FinacleRequestDTO
{
    public string transactionReferenceId { get; set; }
    public List<TransactionDetail> creditTransactionDetails { get; set; }
    public List<TransactionDetail> debitTransactionDetails { get; set; }
    public string transactionCurrency { get; set; }
    public string transactionNarration2 { get; set; }
    public string transactionType { get; set; }
    public string isTransactionCustomerInduced { get; set; }
    public string transactionDateTime { get; set; }
    public string transactionInstrumentType { get; set; }
    public string transactionInstrumentAlphaCode { get; set; }
    public string transactionInstrumentId { get; set; }
    public string transactionInstrumentDate { get; set; }
    public string channelIdCode { get; set; }
}

public class TransactionDetail
{
    public string accountNumber { get; set; }
    public string transactionAmount { get; set; }
    public string transactionNarration { get; set; }
    public string transactionRemark { get; set; }
    public string transactionValueDate { get; set; }
}

public class PostToFinacleRequestDTO
{
    public long Id { get; set; }
    public string LastModifiedBy { get; set; }
    public string UserEmail { get; set; }
    public string BranchCode { get; set; }
    public string LastModifiedByIp { get; set; }
    public string Comment { get; set; }
    public int FundGL { get; set; }
    public string TransCur { get; set; }
    public string Channel { get; set; }
}

public class FinacleTransferDTO
{
    public string TransactionReferenceId { get; set; }
    public string TransactionCurrency { get; set; }
    public string TransactionValueDate { get; set; }
    public string TransactionInstrumentDate { get; set; }
    public string ChannelIdCode { get; set; }
    public string RateCode { get; set; }
    public string ChannelId { get; set; }
    public string TransactionNarration2 { get; set; }

    public List<DrCrDTO> DebitTransactionDetails { get; set; }
    public List<DrCrDTO> CreditTransactionDetails { get; set; }
}

public class DrCrDTO
{
    public string AccountNumber { get; set; }
    public string TransactionAmount { get; set; }
    public string TransactionNarration { get; set; }
    public string TransactionRemark { get; set; }
    public string TransactionValueDate { get; set; }
}

public class UpdateFinacleRefDTO
{
    public long Id { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }
    public string FinacleRefNo { get; set; }
    public DateTime? PostedDate { get; set; }
    public string PostedBy { get; set; }
    public string PostedByIp { get; set; }
    public string PaymentRefNo { get; set; }
}