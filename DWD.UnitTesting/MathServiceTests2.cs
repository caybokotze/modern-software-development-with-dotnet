using System;
using NExpect;
using NSubstitute;
using NUnit.Framework;
using static NExpect.Expectations;

namespace DWD.UnitTesting;

[TestFixture]
public class MathServiceTests2
{
    // Given, When, Then
    [TestFixture]
    public class GetMeanValueTests
    {
        // when
        [TestFixture]
        public class WhenReceivingASingleValueOfOne
        {
            // then
            [Test]
            public void ShouldReturnOne()
            {
                // arrange
                // system under test || service under test
                var sut = CreateMathService(multiplicationService: new MultiplicationService());
                // act
                var actualValue = sut.GetMeanValue(1);
                var expectedValue = 1.0;
                // assert
                Expect(expectedValue).To.Equal(actualValue);
            }
        }

        [TestFixture]
        public class WhenReceivingTwoValuesOfOneAndOne
        {
            [Test]
            public void ShouldReturnOne()
            {
                // arrange
                // system under test || service under test
                var sumService = Substitute.For<SumService>();
                var multiplicationService = new MultiplicationService();
                var sut = new MathService(sumService, multiplicationService);
                // act
                var actualValue = sut.GetMeanValue(1, 1);
                var expectedValue = 1.0;
                // assert
                Expect(expectedValue).To.Equal(actualValue);
            }
        }

        [TestFixture]
        public class WhenReceivingThreeThreeAndThree
        {
            [Test]
            public void ShouldReturnThree()
            {
                // arrange
                var sumService = Substitute.For<SumService>();
                var multiplicationService = new MultiplicationService();
                var sut = new MathService(sumService, multiplicationService);
                // act
                var actual = sut.GetMeanValue(3, 3, 3);
                var expectedValue = 3;
                // assert
                Expect(actual).To.Equal(expectedValue);
            }
        }

        [TestFixture]
        public class WhenReceivingZero
        {
            [Test]
            public void ShouldReturnZero()
            {
                // arrange
                var sut = CreateMathService();
                // act
                var result = sut.GetMeanValue(0);
                // assert
                Expect(result).To.Equal(0);
            }
        }

        [TestFixture]
        public class WhenReceivingNumbersContainingZero
        {
            [Test]
            public void ShouldReturnExpectedMeanValue()
            {
                // arrange
                var sut = CreateMathService();
                // act
                var actual = sut.GetMeanValue(1, 5, 0, 4);
                // assert
                Expect(actual).To.Equal(2.5);
            }
        }

        [TestFixture]
        public class WhenReceivingNumbersContainingNegativeValues
        {
            [Test]
            public void ShouldReturnExpectedMeanValue()
            {
                // arrange
                var sut = CreateMathService();
                // act
                var actual = sut.GetMeanValue(-5, 2, 3);
                // assert
                Expect(actual).To.Equal(0);
            }
        }

        [TestFixture]
        public class WhenSubstitutingForSumService 
        {
            [Test]
            public void ShouldReturnExpectedValueFromMultiplicationService()
            {
                // arrange
                var sumService = Substitute.For<ISumService>();
                sumService.Add(Arg.Any<int[]>()).Returns(10);
                sumService.Add(3, 3, 3).Returns(9);
                sumService.Add().Returns(0);
                sumService.Add(1, 1).Returns(2);

                var multiplicationService = new MultiplicationService();

                var sut = CreateMathService(
                    sumService: sumService, 
                    multiplicationService: multiplicationService);
                
                // act
                Expect(() => sut.GetMeanValue())
                    .To.Throw<InvalidOperationException>().With.Message.Containing("Cannot divide by zero");

                var actual2 = sut.GetMeanValue(1, 1);
                var actual3 = sut.GetMeanValue(3, 3, 3);
                var actual4 = sut.GetMeanValue(3, 3, 3, 3);
                var actual5 = sut.GetMeanValue(3, 3, 3, 3, 4);
                var actual6 = sut.GetMeanValue(3, 3, 3, 3, 5, 6);
                
                // assert
                Expect(actual2).To.Equal(1);
                Expect(actual3).To.Equal(3);
                Expect(actual4).To.Equal(2.5);
                Expect(actual5).To.Equal(2);
                Expect(actual6).To.Equal(1.6666666666666665);
                
            }
        }

        public class WhenSubstitutingForSumServiceAndMultiplicationService
        {
            [Test]
            public void ShouldReturnExpectedValues()
            {
                // arrange
                var sumService = Substitute.For<ISumService>();
                var multiplicationService = Substitute.For<IMultiplicationService>();
                
                sumService.Add(Arg.Any<int[]>()).Returns(1);
                multiplicationService.Multiply(Arg.Any<int>(), Arg.Any<double>()).Returns(9);

                var sut = CreateMathService(sumService, multiplicationService);
                // act
                var actual = sut.GetMeanValue(1, 1, 1);
                // assert
                Expect(actual).To.Equal(9);
            }
        }
    }


    public static MathService CreateMathService(ISumService? sumService = null, IMultiplicationService? multiplicationService = null)
    {
        sumService ??= Substitute.For<SumService>();
        multiplicationService ??= new MultiplicationService();

        var i = 0;
        i += 1;
        
        // sumService = sumService is null ? new SumService() : sumService;
        
        // if (sumService is null)
        // {
        //     sumService = new SumService();
        // }
        // else
        // {
        //     sumService = sumService;
        // }

        return new MathService(sumService, multiplicationService);
    }
}