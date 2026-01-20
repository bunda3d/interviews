module Tests

open Xunit
open Domain
open Swensen.Unquote

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
        let previousTurn = TurnState.firstTurn 
        let actual = guess (GameState.Active previousTurn) ""
        let expected : GameState = GameState.Active { previousTurn with GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``it should reject guesses that are too short`` () =
        let previousTurn = TurnState.firstTurn 
        let actual = guess (GameState.Active previousTurn) "1234"
        let expected = GameState.Active { previousTurn with GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)


    [<Fact>]
    let ``it should reject guesses that are too long`` () =
        let previousTurn= TurnState.firstTurn 
        let actual = guess (GameState.Active previousTurn) "123456"
        let expected = GameState.Active { previousTurn with GuessError = Some GuessError.WrongLength} 

        Assert.Equal(expected, actual)


    [<Fact>]
    let ``If the game is ended, further guesses are rejects / state doesn't change`` () = 
        let previousTurn = GameState.Ended GameOutcome.Lose
        let actual = guess previousTurn "123456"
        let expected = previousTurn

        Assert.Equal(expected, actual)

    [<Fact>]
    let ``it should accept guesses that are exactly the expected length`` () =
        let previousTurn = TurnState.firstTurn 
        let guessedWord = "12345"
        let actual = guess (GameState.Active previousTurn) guessedWord
        let expected = GameState.Active { Guesses = [guessedWord]; GuessError = None } 

        Assert.Equal(expected, actual)


    [<Fact>]
    let ``it should continue the game up to 6 guesses`` () =
        let previousTurn = TurnState.firstTurn 
        let guessedWord = "12345"

        let mutable previousState = GameState.Active previousTurn 
        let mutable turnAccumulator = ResizeArray()
        turnAccumulator.Add(previousState)
        for _ in [0..4] do
            let nextState = guess previousState guessedWord
            previousState <- nextState
            turnAccumulator.Add(nextState) |> ignore
        let actual = turnAccumulator |> List.ofSeq
        let expected = [0..5] |> List.map (fun turnNumber -> GameState.Active { Guesses = List.replicate turnNumber guessedWord ; GuessError = None } )

        expected =! actual

    [<Fact>]
    let ``The game should end after the 6th guess`` () =
        let previousTurn = TurnState.firstTurn 
        let guessedWord = "12345"

        let mutable previousState = GameState.Active previousTurn 
        let mutable turnAccumulator = ResizeArray()
        turnAccumulator.Add(previousState)
        for _ in [0..5] do
            let nextState = guess previousState guessedWord
            previousState <- nextState
            turnAccumulator.Add(nextState) |> ignore
        let actual = turnAccumulator |> List.ofSeq
        let expected = List.concat [
            [0..5] |> List.map (fun turnNumber -> GameState.Active { Guesses = List.replicate turnNumber guessedWord ; GuessError = None } )
            [GameState.Ended GameOutcome.Lose]
        ] 

        expected =! actual