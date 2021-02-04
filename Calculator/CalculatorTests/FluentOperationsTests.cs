using Calculator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CalculatorTests
{
    public class FluentOperationsTests
    {
        [Fact]
        public void SomeComplexOperation_Decrement_Result()
        {
            //Arrange
            FluentOperations fluentOperations = new FluentOperations();

            //Act
            var result = fluentOperations.SomeComplexOperation(2);

            //Assert
            Assert.Equal(1, result);
        }
    }
}
