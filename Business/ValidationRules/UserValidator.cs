﻿using Entities.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            
        }
    }
}
