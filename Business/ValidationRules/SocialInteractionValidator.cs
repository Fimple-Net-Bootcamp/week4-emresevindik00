using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class SocialInteractionValidator : AbstractValidator<SocialInteractionDto>
    {
        public SocialInteractionValidator()
        {
            RuleFor(s => s.InteractionName)
                .NotEmpty().WithMessage("Boş Olamaz")
                .MinimumLength(2).WithMessage("En az 2 harf olmalı")
                .MaximumLength(30).WithMessage("En fazla 30 harf olmalı");
        }
    }
}
