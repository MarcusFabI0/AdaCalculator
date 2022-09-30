

namespace AdaCalculator.Tests
{
    public class CalculatorTests
    {
        private readonly CalculatorMachine _calculatorMachine;
        private readonly Mock<ICalculator> _iCalculator;
        private readonly CalculatorMachine _calculatorMachineMock;
        public CalculatorTests()
        {
            _calculatorMachine = new CalculatorMachine();
            _iCalculator = new Mock<ICalculator>();
            _calculatorMachineMock = new CalculatorMachine(_iCalculator.Object);
        }

        #region TestsWithoutMock
        [Theory]
        [InlineData("sum",11,24.9,35.9)]
        [InlineData("sum", 11, -24.5, -13.5)]
        [InlineData("sum", 24, -24, 0)]
        [InlineData("sum", 22, 0, 22)]
        [InlineData("sum", 42, -41, 1)]

        public void Sum_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            //Arrange    
            
            //Act
            var res = _calculatorMachine.Calculate(operation, numOne, numTwo);

            //Assert
            Assert.Equal("sum",res.operation);
            Assert.Equal(result, res.result);
        }
        

        [Theory]
        [InlineData("subtract", 24, 11, 13)]
        [InlineData("subtract", 11, 24.5, -13.5)]
        [InlineData("subtract", 24, -24, 48)]
        [InlineData("subtract", 22, 0, 22)]
        [InlineData("subtract", 42, 41, 1)]

        public void Subtract_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            var res = _calculatorMachine.Calculate(operation, numOne, numTwo);

            Assert.Equal("subtract", res.operation);
            Assert.Equal(result, res.result);
        }

        [Theory]
        [InlineData("multiply", 24, 11, 264)]
        [InlineData("multiply", 11, -24.5, -269.5)]
        [InlineData("multiply", -24, -24, 576)]
        [InlineData("multiply", 22, 0, 0)]
        [InlineData("multiply", 42, 41, 1722)]

        public void Multiply_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            var res = _calculatorMachine.Calculate(operation, numOne, numTwo);

            Assert.Equal("multiply", res.operation);
            Assert.Equal(result, res.result);
            
        }

        [Theory]
        [InlineData("divide", 24, 2, 12)]
        [InlineData("divide", 10, -1, -10)]
        [InlineData("divide", -24, -24, 1)]
        [InlineData("divide", 22, 0, double.PositiveInfinity)]
        [InlineData("divide", -42, 4.2, -10)]

        public void Divide_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            var res = _calculatorMachine.Calculate(operation, numOne, numTwo);

            Assert.Equal("divide", res.operation);
            Assert.Equal(result, res.result);

        }
        #endregion

        #region TestsWithMock
        [Theory]
        [InlineData("sum", 11, 24.9, 35.9)]
        [InlineData("sum", 11, -24.5, -13.5)]
        [InlineData("sum", 24, -24, 0)]
        [InlineData("sum", 22, 0, 22)]
        [InlineData("sum", 42, -41, 1)]

        public void SumMock_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            //Arrange    
            _iCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((operation, result));

            //Act
            var res = _calculatorMachineMock.Calculate(operation, numOne, numTwo);

            //Assert
            _iCalculator.Verify(x => x.Calculate(operation, numOne, numTwo), Times.Once);
            Assert.Equal("sum", res.operation);
            Assert.Equal(result, res.result);
        }

        [Theory]
        [InlineData("subtract", 24, 11, 13)]
        [InlineData("subtract", 11, 24.5, -13.5)]
        [InlineData("subtract", 24, -24, 48)]
        [InlineData("subtract", 22, 0, 22)]
        [InlineData("subtract", 42, 41, 1)]
        public void SubtractMock_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            //Arrange    
            _iCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((operation, result));

            //Act
            var res = _calculatorMachineMock.Calculate(operation, numOne, numTwo);

            //Assert
            _iCalculator.Verify(x => x.Calculate(operation, numOne, numTwo), Times.Once);
            Assert.Equal("subtract", res.operation);
            Assert.Equal(result, res.result);
        }

        [Theory]
        [InlineData("multiply", 24, 11, 264)]
        [InlineData("multiply", 11, -24.5, -269.5)]
        [InlineData("multiply", -24, -24, 576)]
        [InlineData("multiply", 22, 0, 0)]
        [InlineData("multiply", 42, 41, 1722)]
        public void MultiplyMock_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            //Arrange    
            _iCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((operation, result));

            //Act
            var res = _calculatorMachineMock.Calculate(operation, numOne, numTwo);

            //Assert
            _iCalculator.Verify(x => x.Calculate(operation, numOne, numTwo), Times.Once);
            Assert.Equal("multiply", res.operation);
            Assert.Equal(result, res.result);
        }

        [Theory]
        [InlineData("divide", 24, 2, 12)]
        [InlineData("divide", 10, -1, -10)]
        [InlineData("divide", -24, -24, 1)]
        [InlineData("divide", 22, 0, double.PositiveInfinity)]
        [InlineData("divide", -42, 4.2, -10)]
        public void DivideMock_TwoNumbers_ShouldBeCorrect(string operation, double numOne, double numTwo, double result)
        {
            //Arrange    
            _iCalculator.Setup(x => x.Calculate(It.IsAny<string>(), It.IsAny<double>(), It.IsAny<double>())).Returns((operation, result));

            //Act
            var res = _calculatorMachineMock.Calculate(operation, numOne, numTwo);

            //Assert
            _iCalculator.Verify(x => x.Calculate(operation, numOne, numTwo), Times.Once);
            Assert.Equal("divide", res.operation);
            Assert.Equal(result, res.result);
        }
        #endregion
    }



} 