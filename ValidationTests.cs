using System;
using Triangle3;
using Xunit;

public class ValidationTests
{
    private readonly Validation _validation;

    public ValidationTests()
    {
        _validation = new Validation();
    }

    [Fact]
    public void ValidationParameters_NullParameters_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => _validation.ValidationParameters(null));
    }

    [Fact]
    public void ValidationParameters_EmptyFigureType_ThrowsArgumentException()
    {
        var parameters = new FigureDescriptionParameters
        {
            FigureType = "",
            BaseSide = 5,
            Height = 10,
            Name = "TestTriangle"
        };

        Assert.Throws<ArgumentException>(() => _validation.ValidationParameters(parameters));
    }

    [Fact]
    public void ValidationParameters_InvalidTriangleBase_ThrowsArgumentException()
    {
        var parameters = new FigureDescriptionParameters
        {
            FigureType = "triangle",
            BaseSide = -5,
            Height = 10,
            Name = "TestTriangle"
        };

        Assert.Throws<ArgumentException>(() => _validation.ValidationParameters(parameters));
    }

    [Fact]
    public void ValidationParameters_ValidTriangle_DoesNotThrowException()
    {
        var parameters = new FigureDescriptionParameters
        {
            FigureType = "triangle",
            BaseSide = 5,
            Height = 10,
            Name = "TestTriangle"
        };

        var exception = Record.Exception(() => _validation.ValidationParameters(parameters));
        Assert.Null(exception);
    }

    [Fact]
    public void ValidationParameters_InvalidSquareSide_ThrowsArgumentException()
    {
        var parameters = new FigureDescriptionParameters
        {
            FigureType = "square",
            Side = -5,
            Name = "TestSquare"
        };

        Assert.Throws<ArgumentException>(() => _validation.ValidationParameters(parameters));
    }

    [Fact]
    public void ValidationParameters_ValidSquare_DoesNotThrowException()
    {
        var parameters = new FigureDescriptionParameters
        {
            FigureType = "square",
            Side = 5,
            Name = "TestSquare"
        };

        var exception = Record.Exception(() => _validation.ValidationParameters(parameters));
        Assert.Null(exception);
    }
}
