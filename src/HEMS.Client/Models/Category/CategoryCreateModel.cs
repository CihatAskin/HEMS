using FluentValidation;

using HEMS.Client.Validation;
using HEMS.Shared.Requests.Category;
using HEMS.Application.Services.Contracts;

namespace HEMS.Client.Models.Category
{
    public class CategoryCreateModel : BaseModel
    {
    }

    public class CategoryCreateModelValidator : CustomValidator<CategoryCreateModel>
    {

        public CategoryCreateModelValidator(ICategoryService categoryService)
        {
            RuleFor(p => p.Code).MaximumLength(50).NotEmpty().Must(code => {
                var request = new CategoryExistsRequest(code);
                var response = categoryService.IsExists(request).Result;
               
                return !response.IsSucceeded;

            }).WithMessage("This code already exists.");

            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);
        }

    }

}
