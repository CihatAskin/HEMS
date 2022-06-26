using HEMS.Shared.Dtos;

namespace HEMS.Shared.Response
{
    public abstract class BaseResponse
    {
        public bool IsSucceeded { get; set; }
        public List<string> ErrorMessages { get; set; }
        protected BaseResponse()
        {
            ErrorMessages = new List<string>();
        }
        public void SetSuccess()
        {
            IsSucceeded = true;
        }
    }

    public abstract class BaseResponse<T> : BaseResponse where T : BaseDto, new()
    {
        public T Item { get; set; }
        public List<T> Items { get; set; }


        protected BaseResponse()
        {
            Item = new T();
            Items = new List<T>();
        }

    }
}
