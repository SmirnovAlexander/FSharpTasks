module Logic 

    // Fibonacci recursion function with extra pointer.
    let sumOfEvenFibonacciLessThenMillion () =
        let rec loop counter prev2 prev1 summary =
            match counter with
            | _ ->
                let decreasedCounter = counter - 1
                let sum = prev2 + prev1
                if ( prev2 < 1000000 ) then
                    if ( (prev2 % 2) = 0 ) then
                        let summaryIncreased = summary + prev2
                        loop decreasedCounter prev1 sum summaryIncreased                    
                    else 
                        loop decreasedCounter prev1 sum summary
                else summary
                
        loop 123456 0 1 0