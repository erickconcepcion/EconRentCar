using EconRentCar.DataModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconRentCar.Logics.Validators
{
    class AppUserValidator : AbstractValidator<AppUser>
    {
        private static AppUserValidator instance;
        public static AppUserValidator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppUserValidator();
                }
                return instance;
            }
        }
        private AppUserValidator()
        {
            RuleFor(x=>x.UserName)
                .NotEmpty()                
                .WithMessage("{PropertyName} es requerido.");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido.");

            RuleFor(p => p.UserName)
                .MaximumLength(30)
                .MinimumLength(2)
                .WithMessage("{PropertyName} solo de {MinLength} a {MaxLength} Caracteres Permitidos.");
            RuleFor(p => p.Password)
                .MaximumLength(30)
                .MinimumLength(7)
                .WithMessage("{PropertyName} solo de {MinLength} a {MaxLength} Caracteres Permitidos.");
        }
    }
}
