using FluentValidation;

using HEMS.Client.Validation;
using HEMS.Shared.Requests.Product;
using HEMS.Application.Services.Contracts;

namespace HEMS.Client.Models.Product
{
    public class ProductCreateModel : BaseModel
    {
        public string CategoryCode { get; set; }
        public List<string> CategoryCodes { get; set; }

        public ProductCreateModel()
        {
            CategoryCodes = new List<string>();
        }

        public string ProductTypeCode { get; set; }
    }

    public class ProductCreateModelValidator : CustomValidator<ProductCreateModel>
    {

        public ProductCreateModelValidator(IProductService categoryService)
        {
            RuleFor(p => p.Code).MaximumLength(50).NotEmpty().Must(code => {
                var request = new ProductExistsRequest(code);
                var response = categoryService.IsExists(request).Result;
               
                return !response.IsSucceeded;

            }).WithMessage("This code already exists.");

            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);
            RuleFor(p => p.CategoryCode).NotEmpty();
            RuleFor(p => p.ProductTypeCode).NotEmpty();

        }

    }

}
