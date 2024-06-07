using Domain;

namespace DomainTests;

public class DivideTests
{
    private const decimal NUMBER1 = 123.123M;
    private const decimal ZERO = 0M;
    private const decimal ONE = 1M;
    private const decimal NEGATIVE_ONE = -1M;
    private const decimal SIMPLE = 8M;
    private const decimal NEGATIVE_SIMPLE = 8M;
    private const decimal REVERSE_SIMPLE = 0.125M;
    private const decimal SIMPLE_SQUARE = 64M;
    private const decimal NEGATIVE_SIMPLE_SQUARE = 64M;
    private const decimal NEGATIVE_NUMBER1 = -123.123M;

    [Fact]
    public void DividePositiveOnReverse()
    {
        var result = Calculator.Divide(SIMPLE, REVERSE_SIMPLE);
        Assert.Equal(SIMPLE_SQUARE, result);
    }

    [Fact]
    public void DivideNegativeOnReverse()
    {
        var result = Calculator.Divide(NEGATIVE_SIMPLE, REVERSE_SIMPLE);
        Assert.Equal(NEGATIVE_SIMPLE_SQUARE, result);
    }

    [Fact]
    public void DividePositiveOnItself()
    {
        var result = Calculator.Divide(NUMBER1, NUMBER1);
        Assert.Equal(ONE, result);
    }

    [Fact]
    public void DivideNegativeOnItself()
    {
        var result = Calculator.Divide(NEGATIVE_NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(ONE, result);
    }

    [Fact]
    public void DividePositiveOnZeroThrows()
    {
        Assert.Throws<DivideByZeroException>(() => Calculator.Divide(NUMBER1, ZERO));
    }

    [Fact]
    public void DivideSameNumbersWithDifferentSigns()
    {
        var result = Calculator.Divide(NUMBER1, NEGATIVE_NUMBER1);
        Assert.Equal(NEGATIVE_ONE, result);
    }
}
