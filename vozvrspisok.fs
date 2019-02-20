// Exponentiation.
let rec pow x n =
    if n = 1 then x
    else x * pow x (n - 1)

// List reverse.
let rev list =
    let rec loop list acc=
        match list with
        | [] -> acc
        | head::tail -> loop tail (head::acc)
    loop list []

// Main function.
let func n m =
    let rec loop n m (acc:list<int>)=
        match acc.Length with
        | i when i = m + 1 -> rev acc
        | _ -> loop n m (pow 2 (acc.Length + n)::acc)
    loop n m []
        
// Result.
let n = 3
let m = 7
let result = func n m