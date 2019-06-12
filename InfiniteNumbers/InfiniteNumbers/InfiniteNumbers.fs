module Logic

    // Infinite sequence of [1; -1; 1; -1 ...]
    let ones () = 
        Seq.initInfinite (fun x -> pown (-1) x)

    // Infinite sequence of [1; 2; 3; 4 ...]
    let numbers () =
        Seq.initInfinite (fun x -> x + 1)

    // Infinite sequence of [1, -2, 3, -4, 5, -6, ...]
    let series () =
        Seq.map2 (fun x y -> x * y) (ones ()) (numbers ())