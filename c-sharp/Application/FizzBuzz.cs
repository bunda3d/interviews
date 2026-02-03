namespace Application;

public class FizzBuzz
{
  public string GetStatus(int number)
  {
    if (number % 3 == 0) return "Fizz";

    return number.ToString();
  }
}