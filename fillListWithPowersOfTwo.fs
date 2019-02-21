// Exponentiation.
let rec pow number power =
    if power = 1 then number
    else number * pow number (power - 1)

// List reverse.
let rev list =
    let rec loop list acc=
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

// Returns list filled with powers of 2.
let fillListWithPowersOfTwo powerToStart numberOfElememtsMinusOne =
    let rec loop powerToStart numberOfElememtsMinusOne (list:list<int>) acc=
        match list.Length with
        | i when i = numberOfElememtsMinusOne + 1 -> rev list
        | 0 -> loop powerToStart numberOfElememtsMinusOne (pow 2 (list.Length + powerToStart)::list) (pow 2 (list.Length + powerToStart))
        | _ -> loop powerToStart numberOfElememtsMinusOne (2*acc::list) (2*acc)
    loop powerToStart numberOfElememtsMinusOne [] 2
        
// Result.
let powerToStart = 3
let numberOfElememtsMinusOne = 5
let result = fillListWithPowersOfTwo powerToStart numberOfElememtsMinusOne