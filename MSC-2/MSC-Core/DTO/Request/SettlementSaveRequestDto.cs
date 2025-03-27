using System.Text.Json.Serialization;
using MSC_Core.Entities;

namespace MSC_Core.DTO.Request;

public class SettlementSaveRequestDto
{
    public long Id { get; set; }
    public DateTime SettlementDate { get; set; }
    public string Channel { get; set; }
    public string BranchCode { get; set; }
    public string UserEmail { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }
    public DateTime? LastModifiedDate { get; set; }
    public string Comment { get; set; }
    public string Status { get; set; }
    public long ReworkedId { get; set; }
    public string FinacleRefNo { get; set; }
    public DateTime? PostedDate { get; set; }
    public string PostedBy { get; set; }
    public string PostedByIp { get; set; }
    public string PaymentRefNo { get; set; }


    public List<Document> Documents { get; set; }
    public List<Posting> Postings { get; set; }
    public List<Validation> Validations { get; set; }



    [JsonIgnore]
    public string UserAction { get; set; }
    [JsonIgnore]
    public string UserName { get; set; }
}