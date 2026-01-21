---
date: 2026-01-20
---

## Motivation

Make Wordle to demonstrate that I can problem solve in code


## Requirements

REQ: If user does not guess the word in six tries, they lose
REQ: If they guess the word in less than six tries they win
REQ: Guesses must be 5 letters long, other lengths are rejected
REQ: Each guess should provide color-coded feedback to the user.
- green for a right letter in the right place
- yellow for a right letter in the wrong plance
- gray for a letter that hasn't been tried

NON-REQ: showing previous guesses


## Exploration

Q: What do I need to make this happen?
- I need a source of 5 letter words
- I need to validate input
- I need to track state/turns

Q: Can we focus on tests as the client instead of external input?
- A: yes

Q: Should numbers be allowed?

Q: Next easiest thing?
- limit them to 6 guesses


Q: what happens if the game ends?
- we stop taking input
- we reveal the secret word


PROBLEM: The game state is getting complicated. I want to add a secret word that belongs to the whole game, not the turn, but then I have another layer of nesting for the turn state
- OPT: Squish the turn state and game state together
  - CON: we can have invalid game state structures
  - CON: tests are required to specify data that isn't relevant to them
  - PRO: It's easy to imagine
- OPT: 

```fsharp

```


## Tasks

- [ ] 