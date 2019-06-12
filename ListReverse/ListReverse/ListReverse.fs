module Logic

    // To make it work faster we will use accumulator argument.
    let reverse list =
        let rec loop list acc =
            match list with
            | [] -> acc
            | head::tail -> loop tail (head::acc)
        loop list []