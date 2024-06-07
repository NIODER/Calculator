using Domain;

namespace DomainTests;

public class SubtractTests
{
    private const decimal NUMBER1 = 123.123M;
    private const decimal NUMBER2 = 321.321M;
    private const decimal ZERO = 0M;
    private const decimal NEGATIVE_NUMBER1 = -123.123M;
    private const decimal NEGATIVE_NUMBER2 = -321.321M;

    [Fact]
    public void SubtractPositiveFromItself()
    {
        var result = Calculator.Subtract(NUMBER1, NUMBER1);
        Assert.Equal(ZERO, result);
    }

    [Fact]
    public void SubtractAbsGreaterNegativeFromPositive()
    {
        var result = Calculator.Subtract(NUMBER1, NEGATIVE_NUMBER2);
        Assert.Equal(444.444M, result);
    }

    [Fact]
    public void SubtractAbsLessNegativeFromPositive()
    {
        var result = Calculator.Subtract(NUMBER2, NEGATIVE_NUMBER1);
        Assert.Equal(444.444M, result);
    }

    [Fact]
    public void SubtractNegativeFromItself()
    {
        var result = Calculator.Subtract(NEGATIVE_NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(ZERO, result);
    }

    [Fact]
    public void SubtractPositiveFromZero()
    {
        var result = Calculator.Subtract(ZERO, NUMBER1);
        Assert.Equal(NEGATIVE_NUMBER1, result);
    }

    [Fact]
    public void SubtractNegativeFromItselfPositive()
    {
        var result = Calculator.Subtract(NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(246.246M, result);
    }

    [Fact]
    public void SubtractFromDoubleMaxThrows()
    {
        Assert.Throws<OverflowException>(() => Calculator.Subtract(decimal.MinValue, NUMBER1));
    }

    [Fact]
    public void SubtractNegativeFromDoubleMinThrows()
    {
        Assert.Throws<OverflowException>(() => Calculator.Subtract(decimal.MaxValue, NEGATIVE_NUMBER1));
    }
}
