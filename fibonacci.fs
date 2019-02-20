// Fibonacci recursion function with extra pointer.
let fibonacci n =
    let rec loop n a b =
        match n with
        | 0 -> a
        | _ ->
            let n1 = n-1
            let ab = a + b
            loop n1 b ab
    loop n 0 1

// What index to use.
let num = 35

// Printing result.
let result = fibonacci num
printfn "fibonacci element by index %d = %d" num result

// Freezing console.
System.Console.ReadKey(true) |> ignore  