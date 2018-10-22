
namespace Pay.Base.Common
{
    public class ResponseModel<TModel> : ResponseModel
    {
        public TModel Body { get; set; }
    }

    public class ResponseModel : IResponseModel
    {
        public int ResultCode { get; set; }
        public string Message { get; set; }
        public object DeveloperMessage { get; set; }
    }
}
