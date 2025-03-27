namespace WTS_CORE.Dto;

public class PayStackCallBackDto
{
    public string Event { get; set; }
    public PaystackWebhookDetails Data { get; set; }
}

public class PaystackWebhookDetails
{
    public int Amount { get; set; }
    public string Status { get; set; }
    public string Reference { get; set; }
    public PaystackCustomer Customer { get; set; }
}

public class PaystackCustomer
{
    public string Email { get; set; }
}
