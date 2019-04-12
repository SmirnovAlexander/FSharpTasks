module Logic 

    open System

    // Get string of square with spaces in it.
    let rec stringWithSpace index (str : string) =
        match index with
            |2 -> "*" + str + "*" + "\n"
            |_ -> stringWithSpace (index - 1) (str.Insert(0," "))

    // Get string of square without spaces in it.
    let rec stringWithoutSpace index (str : string) =
            match index with
            |1 -> str + "*" + "\n"
            |_ -> stringWithoutSpace (index - 1) (str.Insert(0,"*"))

    // Preparing our string.
    let prepareString n =
        let rec loop counter accString=              
            match counter with
                |1 -> [accString; stringWithoutSpace n  ""] |> String.concat ""
                |_ when counter = n ->                
                    let accStringLocal =  [accString; stringWithoutSpace n ""] |> String.concat ""
                    loop (counter - 1) accStringLocal
                |_ ->
                    let accStringLocal =  [accString; stringWithSpace n ""] |> String.concat ""
                    loop (counter - 1) accStringLocal
        loop n ""
     
    // Printing string.
    let printSquare (str: string) = 
        Console.WriteLine(str)