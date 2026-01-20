module Domain

type GuessError =
| WrongLength

type GameOutcome =
    | Win
    | Lose

type TurnState = {
    Guesses: string list
    GuessError: GuessError option
}
module TurnState = 
    let firstTurn = {
        Guesses = []
        GuessError = None
    }

type GameState = 
    | Active of TurnState
    | Ended of GameOutcome

module GameState =
    let newGame : GameState =  TurnState.firstTurn |> GameState.Active



let validateGuess (word:string) : Result<string, GuessError> = 
    if word |> String.length = 5
    then Ok word
    else Error GuessError.WrongLength



let guess (state: GameState) (word: string):  GameState = 
    match state with 
    | Ended _ -> state
    | Active turnState -> 
        match validateGuess word with
        | Ok guessedWord -> 
            let nextState = { turnState with Guesses = turnState.Guesses @ [guessedWord] } 
            if nextState.Guesses.Length > 5 then
                GameState.Ended GameOutcome.Lose
            else 
                GameState.Active nextState
        | Error error -> { turnState with GuessError = Some error } |> GameState.Active
