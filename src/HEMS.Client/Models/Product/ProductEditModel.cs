using FluentValidation;
using HEMS.Client.Validation;

namespace HEMS.Client.Models.Product
{
    public class ProductEditModel : BaseModel
    {
        public int Id { get; set; }

        public string CategoryCode { get; set; }
        public string ProductTypeCode { get; set; }

    }
    public class ProductEditModelValidator : CustomValidator<ProductEditModel>
    {
        public ProductEditModelValidator()
        {
            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);

        }
    }
  
}
