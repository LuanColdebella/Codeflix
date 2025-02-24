﻿using FC.Codeflix.Catalog.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FC.Codeflix.Catalog.Domain.Validation;
public class DomainValidation
{
    //tetse
    //teste2

    //public static void NotNull(object? target, string fieldName)
    //{
    //    if (target == null)
    //        throw new EntityValidationException(
    //            $"{fieldName} should not be null");
    //}

    public static void NotNullOrEmpty(string? target, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(target))
            throw new EntityValidationException(
                $"{fieldName} should not be null or empty");
    }
}
