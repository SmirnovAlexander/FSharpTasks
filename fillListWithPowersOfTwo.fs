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
    let rec loop powerToStart numberOfElememtsMinusOne (acc:list<int>)=
        match acc.Length with
        | i when i = numberOfElememtsMinusOne + 1 -> rev acc
        | _ -> loop powerToStart numberOfElememtsMinusOne (pow 2 (acc.Length + powerToStart)::acc)
    loop powerToStart numberOfElememtsMinusOne []
        
// Result.
let powerToStart = 3
let numberOfElememtsMinusOne = 10
let result = fillListWithPowersOfTwo powerToStart numberOfElememtsMinusOne