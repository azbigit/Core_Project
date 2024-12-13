using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator : AbstractValidator<Portfolio>
    {

        public PortfolioValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje adı boş olamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel-1  alanı boş olamaz");
            RuleFor(x => x.ImageUrl2).NotEmpty().WithMessage("Görsel-2  alanı boş olamaz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat  alanı boş olamaz");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer  alanı boş olamaz");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje adı en az 5 karakter olamalı");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Proje adı en fazla 100 karakter olamalı");


        } 
    }
}
