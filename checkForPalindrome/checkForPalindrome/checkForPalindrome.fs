module logic

// Reversing string using pipe forwars operator.
let reverse (word: string): string = 
    word.ToCharArray() |> Array.rev |> System.String
    
// Checking for palondrome.
let checkForPalindrome word =    
    match word with
        | reversedWord when reversedWord = reverse word -> true
        | _ -> false
    
// Result.
let word = "madam"
let result = checkForPalindrome word