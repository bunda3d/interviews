# F# Technical Interview

We're excited to pair with you on a coding kata!

You will use this solution to write your code and tests to solve the problem of the kata below. We will gradually add requirements as we move through the problem and get a feel of what it's like to work with you in a real-world situation. Take your time, explain your thinking, and have fun with us! Show off your skills and ask any questions you have and we'll do the same.

## Tech Stack
- .NET with F#
- xUnit

## Common Commands
- `make init`
    - build the project
- `make verify`
    - run tests
- `make run`
    - run the application

## Kata

This section of the README is used to describe the kata and outline the requirements. We'll leave it blank in the public repository to keep the mystery alive, but just know that the kata we have planned is really fun!

### Introduction

## Requirements: Wordle Engine Kata

Let’s build an engine for the game **Wordle**. The engine should provide the core functionality to play the game.

---

### Core Requirements

1. **Guess the Word**
   - The user has **six attempts** to guess the secret 5-letter word.

2. **Input Validation**
   - Each guess must be **exactly 5 letters long**.
   - If the input is invalid (e.g., not 5 letters):
     - Do not count it as an attempt.
     - Inform the user the input is invalid.

3. **Feedback on Guesses**
   - After each guess, the engine should provide feedback for each letter:
     - `G` (Green): Letter is correct and in the correct position.
     - `Y` (Yellow): Letter is in the word but in the wrong position.
     - `-` (Gray): Letter is not in the word.

4. **End of Game**
   - If the user guesses the word correctly within six attempts:
     - Declare victory and end the game.
   - If the user fails to guess the word after six attempts:
     - Reveal the solution.

---

## Examples of Feedback

If the secret word is `PLANE`:
- Guessing `WORLD` returns: `---Y-`  
- Guessing `PANEL` returns: `GYYYY`  
- Guessing `PLANE` returns: `GGGGG`

---

## Possible Enhancements

1. **Tracking Guesses**
   - Track all previous guesses and their feedback so the user can review them.

2. **Game Statistics**
   - Track and display statistics at the end of each game:
     - Total number of games played.
     - Win percentage.
     - Current win streak.
     - Longest win streak.

3. **Allow Custom Word Lengths**
   - Add support for words longer or shorter than 5 letters (e.g., 6-letter or 4-letter games).

4. **Hard Mode**
   - Introduce a stricter "hard mode" where:
     - Players must use all `G` (Green) and `Y` (Yellow) letters from previous guesses in all subsequent guesses.

5. **Randomized Target Word**
   - Allow the engine to generate a random word for the target (can be a placeholder for now, such as picking a word from a pre-defined list).
