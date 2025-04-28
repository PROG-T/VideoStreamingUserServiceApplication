namespace VideoStreamingUserServiceApplication.Domain.ViewModels
{
    public class BaseResponse<T>
    {
        public bool Status {  get; set; }
        public string Message {  get; set; } = string.Empty;
        public T? Data { get; set; }

        public BaseResponse()
        {
            
        }

        public BaseResponse(bool Status)
        {
            this.Status = Status;
        }

        public BaseResponse(bool Status, string Message)
        {
            this.Status=Status;
            this.Message = Message;
        }

        public BaseResponse(bool Status, T? Data )
        {
            this.Status = Status;
            this.Data = Data;
        }
        public BaseResponse(bool Status, String Message,T? Data)
        {
            this.Status = Status;
            this.Message = Message;
            this.Data = Data;
        }
    }
}
