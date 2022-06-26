using FluentValidation;

using HEMS.Client.Validation;
using HEMS.Shared.Requests.ProductType;
using HEMS.Application.Services.Contracts;

namespace HEMS.Client.Models.ProductType
{
    public class ProductTypeCreateModel:BaseModel
    {
        public string CategoryCode { get; set; }
        public List<string> CategoryCodes { get; set; }
        public ProductTypeCreateModel()
        {
            CategoryCodes = new List<string>();
        }
    }
    public class ProductTypeCreateModelValidator : CustomValidator<ProductTypeCreateModel>
    {

        public ProductTypeCreateModelValidator(IProductTypeService productTypeService)
        {
            RuleFor(p => p.Code).MaximumLength(50).NotEmpty().Must(code => {
                var request = new ProductTypeExistsRequest(code);
                var response = productTypeService.IsExists(request).Result;

                return !response.IsSucceeded;

            }).WithMessage("This code already exists.");

            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);
            RuleFor(p => p.CategoryCode).NotEmpty();
        }

    }
}
