module Domain

type GuessError =
| WrongLength

type GameState = {
    GuessError: GuessError option
}

module GameState =
    let newGame : GameState = {
        GuessError = None
    }

let validateGuess (word:string) : Result<string, GuessError> = 
    if word |> String.length = 5
    then Ok word
    else Error GuessError.WrongLength



let guess (state: GameState) (word: string):  GameState = 
    match validateGuess word with
    | Ok guessedWord -> state
    | Error error -> { state with GuessError = Some error } 
