// Catching input below zero.
exception WrongInputError of string

// Factorial function.
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | x when x < 0 -> raise (WrongInputError("The given number is below zero."))
    | _ -> n * factorial (n - 1)

// Result.
let num = -10
let result = factorial (num)