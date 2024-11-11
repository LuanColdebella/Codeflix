using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Codeflix.Catalog.Domain.Exceptions;
public class EntityValidationException : ApplicationException
{
    public EntityValidationException(string? message) : base(message)
    {

    }

    public EntityValidationException() : base()
    {
    }

    public EntityValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
