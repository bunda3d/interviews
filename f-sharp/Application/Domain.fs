module Domain

type GuessError =
| WrongLength

type GameOutcome =
    | Win
    | Lose

type GameState = {
    SecretWord: string
    Guesses: string list
    GuessError: GuessError option
    Outcome: GameOutcome option
}

module GameState =
    let newGame (secretWord: string) : GameState =  {
        SecretWord = secretWord
        Guesses = []
        GuessError = None
        Outcome = None
    }



let validateGuess (word:string) : Result<string, GuessError> = 
    if word |> String.length = 5
    then Ok word
    else Error GuessError.WrongLength



let guess (state: GameState) (word: string):  GameState = 
    match state.Outcome with 
    | Some _ -> state
    | None -> 
        match validateGuess word with
        | Ok guessedWord -> 
            let nextState = { state with Guesses = state.Guesses @ [guessedWord] } 
            if nextState.Guesses.Length > 5 then
                {nextState with Outcome = Some GameOutcome.Lose }
            else 
                nextState
        | Error error -> { state with GuessError = Some error }
