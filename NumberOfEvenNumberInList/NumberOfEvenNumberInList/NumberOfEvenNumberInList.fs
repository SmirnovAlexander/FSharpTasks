module Logic

    // Number of even numbers using map.
    let numberOfEvenNumberInListMap list =
        let listWithOnesPlacedInsteadOfEvenNumbers = list 
                                                     |> List.map (fun x -> x + 1) 
                                                     |> List.map (fun x -> x % 2)         
        listWithOnesPlacedInsteadOfEvenNumbers |> List.sum
        
    // Number of even numbers using filter.
    let numberOfEvenNumberInListFilter list =
        let deuces = list |> List.filter (fun x -> x % 2 = 0)
        deuces.Length

    // Number of even numbers using fold.
    let numberOfEvenNumberInListFold list =
        List.fold (fun acc x -> if (x % 2 = 0) then (acc + 1)
                                else acc) 0 list