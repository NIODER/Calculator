using Domain;

namespace DomainTests;

public class AddTests
{
    private const decimal NUMBER1 = 123.123M;
    private const decimal NUMBER2 = 321.321M;
    private const decimal ZERO = 0M;
    private const decimal NEGATIVE_NUMBER1 = -123.123M;
    private const decimal NEGATIVE_NUMBER2 = -321.321M;

    [Fact]
    public void AddPositiveToItself()
    {
        var result = Calculator.Add(NUMBER1, NUMBER1);
        Assert.Equal(246.246M, result);
    }

    [Fact]
    public void AddPositiveToAbsGreaterNegative()
    {
        var result = Calculator.Add(NUMBER1, NEGATIVE_NUMBER2);
        Assert.Equal(-198.198M, result);
    }

    [Fact]
    public void AddPositiveToAbsLessNegative()
    {
        var result = Calculator.Add(NUMBER2, NEGATIVE_NUMBER1);
        Assert.Equal(198.198M, result);
    }

    [Fact]
    public void AddNegativeToItself()
    {
        var result = Calculator.Add(NEGATIVE_NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(-246.246M, result);
    }

    [Fact]
    public void AddPositiveToZero()
    {
        var result = Calculator.Add(ZERO, NUMBER1);
        Assert.Equal(NUMBER1, result);
    }

    [Fact]
    public void PlacesChangeSameResult()
    {
        var result1 = Calculator.Add(NUMBER1, NUMBER2);
        var result2 = Calculator.Add(NUMBER2, NUMBER1);
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void AddSameNumbersWithDifferentSignsIsZero()
    {
        var result = Calculator.Add(NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(ZERO, result);
    }

    [Fact]
    public void AddToDoubleMaxThrows()
    {
        Assert.Throws<OverflowException>(() => Calculator.Add(decimal.MaxValue, NUMBER1));
    }

    [Fact]
    public void AddNegativeToDoubleMinThrows()
    {
        Assert.Throws<OverflowException>(() => Calculator.Add(decimal.MinValue, NEGATIVE_NUMBER1));
    }
}