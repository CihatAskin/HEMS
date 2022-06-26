
namespace HEMS.Shared.Requests.Category
{
    public class CategoryExistsRequest
    {
        public string Code { get; set; }

        public CategoryExistsRequest(string code)
        {
            Code = code;
        }
    }
}
