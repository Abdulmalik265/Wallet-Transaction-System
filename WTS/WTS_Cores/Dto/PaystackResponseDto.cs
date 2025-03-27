namespace WTS_CORE.Dto;

public class PaystackResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public PaystackResponseData Data { get; set; }
}

public class PaystackResponseData
{
    public string AuthorizationUrl { get; set; }
    public string AccessCode { get; set; }
    public string Reference { get; set; }
}
