
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

    Step-by-Step TDD Guide:
    - Test 1: Input 1 -> Returns "1"
    - Test 2: Input 2 -> Returns "2"
    - Test 3: Input 3 -> Returns "Fizz"
    - Test 4: Input 5 -> Returns "Buzz"
    - Test 5: Input 6 -> Returns "Fizz" (Test multiple of 3)
    - Test 6: Input 10 -> Returns "Buzz" (Test multiple of 5)
    - Test 7: Input 15 -> Returns "FizzBuzz"
    - Test 8: Input 30 -> Returns "FizzBuzz" (Test multiple of 3 & 5)
*/
#endregion

public class FizzBuzzTests
{
  [Theory]
  [InlineData(1, "1")]
  [InlineData(2, "2")]
  [InlineData(3, "Fizz")]
  public void GetStatus_ReturnsFizz_IfDivisibleBy3(int input, string returnStatus)
  {
    // Given
    var fizzBuzz = new FizzBuzz();

    // When
    var result = fizzBuzz.GetStatus(input);

    // Then
    Assert.Equal(returnStatus, result);
  }
}