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
let fillListWithPowersOfTwo powerToStart numberOfElementsMinusOne =
    let rec loop powerToStart numberOfElementsMinusOne (list:list<int>) acc=
        match list.Length with
        | i when i = numberOfElementsMinusOne + 1 -> rev list
        | 0 -> let p = pow 2 (list.Length + powerToStart) 
               loop powerToStart numberOfElementsMinusOne (p::list) p
        | _ -> let newElement = 2 * acc
               loop powerToStart numberOfElementsMinusOne (newElement::list) newElement
    loop powerToStart numberOfElementsMinusOne [] 2
        
// Result.
let powerToStart = 3
let numberOfElementsMinusOne = 7
let result = fillListWithPowersOfTwo powerToStart numberOfElementsMinusOne