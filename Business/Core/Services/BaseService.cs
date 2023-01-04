using Business.Core.Models;
using FluentValidation;

namespace Business.Core.Services
{
    public abstract class BaseService
    {
        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);
            return validator.IsValid;
        }
    }
}
