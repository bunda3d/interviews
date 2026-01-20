module Domain

type GuessError =
| WrongLength

type GameState = {
    Guesses: string list
    GuessError: GuessError option
}

module GameState =
    let newGame : GameState = {
        Guesses = []
        GuessError = None
    }

let validateGuess (word:string) : Result<string, GuessError> = 
    if word |> String.length = 5
    then Ok word
    else Error GuessError.WrongLength



let guess (state: GameState) (word: string):  GameState = 
    match validateGuess word with
    | Ok guessedWord -> { state with Guesses = state.Guesses @ [guessedWord] }
    | Error error -> { state with GuessError = Some error } 
