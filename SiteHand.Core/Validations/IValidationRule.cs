using System;
using System.Collections.Generic;
using System.Text;

namespace SiteHand.Core.Validations
{
    public interface IValidationRule<T>
    {
        string Description { get; }
        bool Validate(T value);
    }
}
