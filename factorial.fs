// Factorial function.
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | x when x < 0 -> 0
    | _ -> n * factorial (n - 1)

// Result.
let num = -10
let result = factorial (num)