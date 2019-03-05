module logic 

    let isPrime n =
        match n with
        | x when x = 0 || x = 1 -> false
        | _ -> let rec check i =
                         i > n/2 || (n % i <> 0 && check (i + 1))
               check 2
       
    let primes () = 
        Seq.initInfinite (fun i -> i) |> Seq.filter (fun x -> isPrime x)