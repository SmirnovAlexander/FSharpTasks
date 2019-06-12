module Logic

    // Exponentiation.
    let rec power number pow =
        if pow = 0 then 1
        else if pow = 1 then number
        else number * power number (pow - 1)

    // List reverse.
    let reverse list =
        let rec loop list acc=
            match list with
            | [] -> acc
            | head::tail -> loop tail (head::acc)
        loop list []

    // Returns list filled with powers of 2.
    let fillListWithPowersOfTwo powerToStart numberOfElements =
        let numberOfElementsMinusOne = numberOfElements - 1
        let rec loop powerToStart numberOfElementsMinusOne (list:list<int>) acc=
            match list.Length with
            | i when i = numberOfElementsMinusOne + 1 -> reverse list
            | 0 -> let p = power 2 (list.Length + powerToStart) 
                   loop powerToStart numberOfElementsMinusOne (p::list) p
            | _ -> let newElement = 2 * acc
                   loop powerToStart numberOfElementsMinusOne (newElement::list) newElement
        loop powerToStart numberOfElementsMinusOne [] 2