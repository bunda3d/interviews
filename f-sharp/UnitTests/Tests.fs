module Tests

open Xunit
open Domain

module GuessValidationTests =
    [<Fact>]
    let ``it should reject guesses that are empty`` () =
        let actual = Domain.validateGuess ""
        let expected = Error Domain.GuessError.WrongLength

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``it should reject guesses that are too short`` () =
        let actual = Domain.validateGuess "1234"
        let expected = Error Domain.GuessError.WrongLength

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``it should reject guesses that are too long`` () =
        let actual = Domain.validateGuess "123456"
        let expected = Error Domain.GuessError.WrongLength

        Assert.Equal(expected, actual)


    [<Fact>]
    let ``it should accept guesses that are exactly the expected length`` () =
        let guessedWord = "Hello"
        let expected = Ok guessedWord
        let actual = Domain.validateGuess guessedWord

        Assert.Equal(expected, actual)


module GameTests =
    
    [<Fact>]
    let ``it should reject guesses that are empty`` () =
        let startState = GameState.newGame
        let actual = guess startState ""
        let expected : GameState = { GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``it should reject guesses that are too short`` () =
        let startState = GameState.newGame
        let actual = guess startState "1234"
        let expected = { GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)


    [<Fact>]
    let ``it should reject guesses that are too long`` () =
        let startState = GameState.newGame
        let actual = guess startState "123456"
        let expected = { GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)



    [<Fact>]
    let ``it should accept guesses that are exactly the expected length`` () =
        let startState = GameState.newGame
        let actual = guess startState "12345"
        let expected = { GuessError = None } 

        Assert.Equal(expected, actual)
