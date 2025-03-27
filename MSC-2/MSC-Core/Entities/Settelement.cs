using System.ComponentModel.DataAnnotations;

namespace MSC_Core.Entities;

public class Settelement : Base
{
    [Required]
    public DateTime? SettlementDate { get; set; }

    [Required]
    public string Channel { get; set; } 
    public string Status { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? PostedDate { get; set; }
    public string PostedBy { get; set; }
    public string PostedByIp { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? RaisedDate { get; set; }
    public string RaisedBy { get; set; }
    public string RaisedByIp { get; set; }
    public string BranchCode { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? LastModifiedDate { get; set; }
    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }
    public long ReworkedId { get; set; }


    //navigation property
    public ICollection<Document> Document { get; set; }
    public ICollection<History> Histories { get; set; }
    public ICollection<Posting> Postings { get; set; }
    public ICollection<Validation> Validations { get; set; }
}