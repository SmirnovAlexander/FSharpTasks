// Catching input below zero.
exception WrongInputError of string

// Fibonacci recursion function with extra pointer.
let fibonacci index =
    let rec loop counter prev2 prev1 =
        match counter with
        | 0 -> prev2
        | x when x < 0 -> raise (WrongInputError("The given number is below zero."))
        | _ ->
            let decreasedCounter = counter - 1
            let sum = prev2 + prev1
            loop decreasedCounter prev1 sum
    loop index 0 1

// Result.
let index = 6
let result = fibonacci index