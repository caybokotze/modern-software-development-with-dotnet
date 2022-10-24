using NExpect;
using NSubstitute;
using NUnit.Framework;

namespace DWD.UnitTesting;


/// <summary>
/// A commonly accepted TDD practice is to follow a test naming convention following Given, When, Then...
/// </summary>
[TestFixture]
public class MathServiceTests
{
    // (Given)
    [TestFixture]
    public class GetMeanValueTests
    {
        // (When)
        [TestFixture]
        public class WhenASingleParameterIsProvided
        {
            // (Then)
            [Test]
            public void ShouldReturnTheProvidedValue()
            {
                // arrange
                var sumService = new SumService();
                var multiplicationService = new MultiplicationService();
                // sut => System Under Test || Service Under Test.
                var sut = CreateMathService(sumService, multiplicationService);
                // act
                var actual = sut.GetMeanValue(2);
                const int expected = 2;
                // assert
                Expectations.Expect(actual).To.Equal(expected);
            }
        }

        [TestFixture]
        public class WhenTwoParametersAreProvided
        {
            [Test]
            public void ShouldReturnHalfOfThatValue()
            {
                // arrange
                var sumService = new SumService();
                var multiplicationService = new MultiplicationService();
                var sut = CreateMathService(sumService, multiplicationService);
                // act
                var actual = sut.GetMeanValue(2, 4);
                const int expected = 3;
                // assert
                Expectations.Expect(actual).To.Equal(expected);
            }
        }

        [TestFixture]
        public class WhenThreeParametersAreProvided
        {
            [Test]
            public void ShouldReturnAThirdOfThatValue()
            {
                // arrange
                var sumService = new SumService();
                var multiplicationService = new MultiplicationService();
                var sut = CreateMathService(sumService, multiplicationService);
                // act
                var actual = sut.GetMeanValue(2, 4, 3);
                const int expected = 3;
                // assert
                Expectations.Expect(actual).To.Equal(expected);
            }
        }
    }

    public static MathService CreateMathService(
        ISumService? sumService = null, 
        IMultiplicationService? multiplicationService = null)
    {
        // ternary conditional operator (a short if-else statement)
        // this could be written more succinctly as null-coalescing conditional operator
        // like this: sumService = sumService ?? Substitute.For<ISumService>()
        sumService = sumService is null ? Substitute.For<ISumService>() : sumService;
        // the most succinct solution is the null-coalescing compound assignment operator
        multiplicationService ??= Substitute.For<IMultiplicationService>();
        return new MathService(sumService, multiplicationService);
    }
}