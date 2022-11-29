using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class UserValidator:AbstractValidator<AppUser>
    {
		public UserValidator()
		{
            RuleFor(x => x.FullName).MaximumLength(30).WithMessage("Max 30 char.");
            RuleFor(x => x.FullName).MinimumLength(5).WithMessage("Min 5 char.");
			RuleFor(x=>x.Address).NotEmpty().WithMessage("Can not empty.");
		}
    }
}