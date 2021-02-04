using Calculator;
using System;
using Xunit;

namespace CalculatorTests
{
    public class BasicOperationsTests
    {
        //[Fact] // не принимает параметры
        [Theory] //принимает параметры
        [InlineData(4, 5, 9 )]
        [InlineData(1, 3, 4)]
        [InlineData(-1, 53, 52)]

        public void Add_AddTwoIntegers_ResultIsCorrect(int x, int y, int excpected)
        {
            //Arange
            BasicOperations basicOperations = new BasicOperations();

            //Act
            var result = basicOperations.Add(x,y);

            //Assert
            //var excpected = x + y;
            Assert.Equal(excpected, result);
        }
    }
}
