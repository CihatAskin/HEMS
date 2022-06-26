
namespace HEMS.Shared.Requests.Category
{
    public class CategoryDeleteRequest
    {
        public string Code { get; set; }

        public CategoryDeleteRequest(string code)
        {
            Code = code;
        }
    }
}
