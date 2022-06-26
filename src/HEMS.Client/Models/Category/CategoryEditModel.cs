using FluentValidation;
using HEMS.Client.Validation;

namespace HEMS.Client.Models.Category
{
    public class CategoryEditModel : BaseModel
    {
        public int Id { get; set; }
    }
    public class CategoryEditModelValidator : CustomValidator<CategoryEditModel>
    {
        public CategoryEditModelValidator()
        {
            RuleFor(p => p.Name).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Status).MaximumLength(50).NotEmpty();
            RuleFor(p => p.Description).MaximumLength(50);

        }
    }
  
}
