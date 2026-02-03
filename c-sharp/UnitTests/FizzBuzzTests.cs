using Application;

namespace UnitTests;

#region [FizzBuzz TDD Instructions]
/*
    FIZZBUZZ KATA

    Write a program that converts a number to a string following these rules:

    1. If the number is divisible by 3, return "Fizz".
    2. If the number is divisible by 5, return "Buzz".
    3. If the number is divisible by both 3 and 5, return "FizzBuzz".
    4. Otherwise, return the number as a string (e.g., 1 -> "1").
*/
#endregion

public class FizzBuzzTests
{
  [Theory]
  [InlineData(1, "1")]  // Default case: not divisible evenly
  [InlineData(2, "2")]
  [InlineData(3, "Fizz")]
  [InlineData(5, "Buzz")]
  [InlineData(15, "FizzBuzz")]
  public void GetStatus_ReturnsCorrectStatus_PerDivisibility(int input, string returnStatus)
  {
    // Given
    var fizzBuzz = new FizzBuzz();

    // When
    var result = fizzBuzz.GetStatus(input);

    // Then
    Assert.Equal(returnStatus, result);
  }
}