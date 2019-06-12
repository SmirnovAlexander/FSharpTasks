module Logic 
    
    // Check if number is prime.
    let isPrime n =
        match n with
            | 0 | 1 -> false
            | _ -> let rec check i =
                             (i > int (sqrt (float n))) || (n % i <> 0 && check (i + 1))
                   check 2
    // Initializing infinite sequence.
    let primes () = 
        Seq.initInfinite (id) |> Seq.filter (isPrime)