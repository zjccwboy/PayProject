
namespace Pay.Base.Common
{
    public abstract class BaseDTO<TInputModel, TOutputModel> : IDTO where TInputModel : IRequestModel where TOutputModel : IResponseModel
    {
        public TInputModel Model { get; set; }
        public TOutputModel Result { get; set; }
    }
}

