using FC.Codeflix.Catalog.Domain.Exceptions;
using FC.Codeflix.Catalog.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FC.Codeflix.Catalog.Domain.Entity;
public class Category : AggregateRoot
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Category(string name, string description, bool isActive = true)
        : base()
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = isActive;
        CreatedAt = DateTime.Now;

        Validate();
    }

    public void Active()
    {
        IsActive = true;
        Validate();
    }

    public void Deactivete()
    {
        IsActive = false;
        Validate();
    }

    public void Update(string name, string? description = null)
    {
        Name = name;
        Description = description ?? Description;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new EntityValidationException($"{nameof(Name)} should not be empty or null");

        if (Name.Length < 3)
            throw new EntityValidationException($"{nameof(Name)} should be at least 3 characters");

        if (Name.Length > 255)
            throw new EntityValidationException($"{nameof(Name)} should be lass or equal 255 characters");

        if (Description == null)
            throw new EntityValidationException($"{nameof(Description)} should not be null");

        if (Description.Length > 10_000)
            throw new EntityValidationException($"{nameof(Description)} should be lass or equal 10.000 characters");
    }


}
