// To make it work faster we will use accumulator argument.
let rev list =
    let rec loop list acc =
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

// Result.
let someList = [1..10]
let result = rev someList