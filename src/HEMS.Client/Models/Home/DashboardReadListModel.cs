using HEMS.Client.Models.Category;
using HEMS.Client.Models.Product;
using HEMS.Client.Models.ProductType;

namespace HEMS.Client.Models.Home
{
    public class DashboardReadListModel
    {
        public List<CategoryReadModel> Categories { get; set; }
        public List<ProductTypeReadModel> ProductTypes { get; set; }
        public List<ProductReadModel> Products { get; set; }

    }
}
