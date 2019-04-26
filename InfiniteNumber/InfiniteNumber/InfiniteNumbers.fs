module Logic

    let ones () = 
        Seq.initInfinite (fun x -> pown (-1) x)

    let numbers () =
        Seq.initInfinite (fun x -> x + 1)

    let series () =
        Seq.map2 (fun x y -> x * y) (ones ()) (numbers ())