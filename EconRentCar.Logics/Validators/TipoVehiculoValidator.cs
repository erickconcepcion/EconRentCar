﻿using EconRentCar.DataModel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconRentCar.Logics.Validators
{
    public class TipoVehiculoValidator : AbstractValidator<TipoVehiculo>
    {
        private static TipoVehiculoValidator instance;
        public static TipoVehiculoValidator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TipoVehiculoValidator();
                }
                return instance;
            }
        }
        private TipoVehiculoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido.");
            RuleFor(p => p.Nombre)
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("{PropertyName} solo de {MinLength} a {MaxLength} Caracteres Permitidos.");
            RuleFor(x => x.Descripcion)
                .NotEmpty()
                .WithMessage("{PropertyName} es requerido.");
            RuleFor(p => p.Descripcion)
                .MaximumLength(50)
                .MinimumLength(2)
                .WithMessage("{PropertyName} solo de {MinLength} a {MaxLength} Caracteres Permitidos.");

        }
    }
}
