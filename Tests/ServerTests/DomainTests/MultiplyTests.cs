using Domain;

namespace DomainTests;

public class MultiplyTests
{
    private const decimal NUMBER1 = 123.123M;
    private const decimal NUMBER2 = 321.321M;
    private const decimal ZERO = 0M;
    private const decimal SIMPLE = 8M;
    private const decimal NEGATIVE_SIMPLE = -8M;
    private const decimal REVERSE_SIMPLE = 0.125M;
    private const decimal ONE = 1M;
    private const decimal NEGATIVE_ONE = -1M;
    private const decimal NEGATIVE_NUMBER1 = -123.123M;
    private const decimal NEGATIVE_NUMBER2 = -321.321M;

    [Fact]
    public void MuliplyPositiveOnReverseIsOne()
    {
        var result = Calculator.Multiply(SIMPLE, REVERSE_SIMPLE);
        Assert.Equal(ONE, result);
    }

    [Fact]
    public void MuliplyNegativeOnReverseIsOne()
    {
        var result = Calculator.Multiply(NEGATIVE_SIMPLE, REVERSE_SIMPLE);
        Assert.Equal(NEGATIVE_ONE, result);
    }

    [Fact]
    public void MultiplyPositiveOnItself()
    {
        var result = Calculator.Multiply(NUMBER1, NUMBER1);
        Assert.Equal(15159.273129M, result);
    }

    [Fact]
    public void MultiplyPositiveOnAbsGreaterNegative()
    {
        var result = Calculator.Multiply(NUMBER1, NEGATIVE_NUMBER2);
        Assert.Equal(-39562.005483M, result);
    }

    [Fact]
    public void MultiplyPositiveOnAbsLessNegative()
    {
        var result = Calculator.Multiply(NUMBER2, NEGATIVE_NUMBER1);
        Assert.Equal(-39562.005483M, result);
    }

    [Fact]
    public void MultiplyNegativeOnItself()
    {
        var result = Calculator.Multiply(NEGATIVE_NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(15159.273129M, result);
    }

    [Fact]
    public void MultiplyPositiveOnZero()
    {
        var result = Calculator.Multiply(ZERO, NUMBER1);
        Assert.Equal(ZERO, result);
    }

    [Fact]
    public void PlacesChangeSameResult()
    {
        var result1 = Calculator.Multiply(NUMBER1, NUMBER2);
        var result2 = Calculator.Multiply(NUMBER2, NUMBER1);
        Assert.Equal(result1, result2);
    }

    [Fact]
    public void MultiplySameNumbersWithDifferentSigns()
    {
        var result = Calculator.Multiply(NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(-15159.273129M, result);
    }

    [Fact]
    public void MultiplyPositiveOnMaxThrows()
    {
        Assert.Throws<OverflowException>(() => Calculator.Multiply(decimal.MaxValue, NUMBER1));
    }
}
