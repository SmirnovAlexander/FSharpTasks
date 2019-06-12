module Logic

    // Reversing string using pipe forwars operator.
    let reverse (word: string): string = 
        word.ToCharArray() |> Array.rev |> System.String
    
    // Checking for palondrome.
    let checkForPalindrome word =    
        word = reverse word