using Bogus;
using FC.Codeflix.Catalog.Domain.Exceptions;
using FC.Codeflix.Catalog.Domain.Validation;
using FC.Codeflix.Catalog.UnitTests.Domain.Entity.Category;
using FluentAssertions;
using Xunit;

namespace FC.Codeflix.Catalog.UnitTests.Domain.Validation;
public class DomainValidationTest
{
    private Faker Faker { get; set; } = new Faker("pt_BR");

    [Fact(DisplayName = nameof(NotNullOK))]
    [Trait("Domain", "DomainValidation - Validation")]
    public void NotNullOK()
    {
        var value = Faker.Commerce.ProductName();

        Action action =
            () => DomainValidation.NotNull(value, "Value");
        action.Should().NotThrow();


    }

    [Fact(DisplayName = nameof(NotNullThrowWhenNull))]
    [Trait("Domain", "DomainValidation - Validation")]
    public void NotNullThrowWhenNull()
    {
        string? value = null;

        Action action =
            () => DomainValidation.NotNull(value, "FieldName");
        action.Should().Throw<EntityValidationException>()
            .WithMessage("FieldName should not be null");


    }

    [Theory(DisplayName = nameof(NotNullOrEmptyThrowWhenEmpty))]
    [Trait("Domain", "DomainValidation - Validation")]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void NotNullOrEmptyThrowWhenEmpty(string? target)
    {

        Action action =
            () => DomainValidation.NotNullOrEmpty(target, "FieldName");
        action.Should().Throw<EntityValidationException>()
            .WithMessage("FieldName should not be null or empty");


    }

    [Fact(DisplayName = nameof(NotNullOrEmptyOK))]
    [Trait("Domain", "DomainValidation - Validation")]
    public void NotNullOrEmptyOK()
    {
        string target = Faker.Commerce.ProductName();

        Action action =
            () => DomainValidation.NotNullOrEmpty(target, "FieldName");
        action.Should().NotThrow();


    }

    //[Theory(DisplayName = nameof(MinLengthThrowWhenLess))]
    //[Trait("Domain", "DomainValidation - Validation")]
    //[InlineData("")]
    //public void MinLengthThrowWhenLess(string target, int minLength)
    //{
    //    Action action =
    //        () => DomainValidation.MinLength(target, minLength, "FieldName");

    //    action.Should().Throw<EntityValidationException>()
    //        .WithMessage($"FieldName should not be less than {minLength} characters");


    //}

    public static IEnumerable<object[]> GetValuesSmallerThan(int numberOfTests)
    {
        var faker = new Faker("pt_BR");
        for (int i = 0; i < numberOfTests; i++)
        {
            var exemple = faker.Commerce.ProductName();
            var minLength = exemple.Length + (new Random().Next(0, 20));
            yield return new object[] { exemple, minLength };

        }
    }

}
