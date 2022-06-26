using FluentValidation;
using HEMS.Client.Validation;

namespace HEMS.Client.Models.ProductType
{
    public class ProductTypeEditModel : BaseModel
    {
        public string CategoryCode { get; set; }
        public int Id { get; set; }
    }

    public class ProductTypeEditModelValidator : CustomValidator<ProductTypeEditModel>
    {
        public ProductTypeEditModelValidator()
        {
            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);
        }
    }
}
