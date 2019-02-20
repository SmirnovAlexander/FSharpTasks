// Factorial function.
let rec factorial n =
    match n with
    | 0 | 1 -> 1
    | _ -> n * factorial(n-1)

// Variable to count factorial of.
let num = 5

// Printing.
printfn "%d! = %d"  num (factorial (num))

// Freezing console.
System.Console.ReadKey(true) |> ignore  