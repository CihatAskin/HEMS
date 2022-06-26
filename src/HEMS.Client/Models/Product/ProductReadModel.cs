namespace HEMS.Client.Models.Product
{
    public class ProductReadModel : BaseModel
    {
        public string CategoryCode { get; set; }
        public string ProductTypeCode { get; set; }

        public int Id { get; set; }
    }
}
