using System;
using System.ComponentModel.DataAnnotations;

namespace MSC_Core.Entities;

public class BaseCommon
{
    public long Id { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? CreatedDate { get; set; }

    public string CreatedBy { get; set; }
    public string CreatedByIp { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? LastModifiedDate { get; set; }

    public string LastModifiedBy { get; set; }
    public string LastModifiedByIp { get; set; }

    public string BranchCode { get; set; }
}