module Logic 

    // Method that reverses number
    let reverse (n: int) =
        let rec loop (n: int, partial: int) =
            if (n = 0) then partial
                       else loop(n / 10, partial * 10 + n % 10)
        loop (n, 0)

    // Checking number if it is palondrome.
    let checkForPalindrome number =    
        number = reverse number     

    // Iterating throw each pair of three digit numbers.
    let BiggestPalindrome () = 
        let rec loop (first:int, second:int, maxValue: int) = 
            match first with
            | 99 -> maxValue
            | _ when checkForPalindrome (first * second) ->
                if (first * second > maxValue) then loop (first, (second - 1), (first * second))
                                               else loop (first, (second - 1), maxValue)
            | _ when (second = 100) -> loop ((first - 1), 999, maxValue)
            | _ -> loop (first, (second - 1), maxValue)
        loop (999, 999, 0)