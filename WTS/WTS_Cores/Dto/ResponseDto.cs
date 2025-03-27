using WTS_CORE.Entities;

namespace WTS_CORE.Dto;

public class ResponseDto<T>
{
    public T Data { get; set; }
    public  string ResponseMessage { get; set; }
    public int ResponseCode { get; set; }
}