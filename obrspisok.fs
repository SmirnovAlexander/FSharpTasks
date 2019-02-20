// To make it work faster we will use accumulator argument.
let rev list =
    let rec loop list acc=
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

// Initialize a list to reverse.
let somelist = [1..10]

// Get the result.
let result = rev somelist 
printf "was: %A, result: %O" somelist result

// Removed readkey because started to use F# interactively.