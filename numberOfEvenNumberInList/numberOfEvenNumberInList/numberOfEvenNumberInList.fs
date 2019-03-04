module logic

    let numberOfEvenNumberInListMap list =
        let deuces = list |> List.map (fun x -> 
            match x with
            | two when two % 2 = 0 -> 2
            | _ -> 0)
        
        let sum = deuces |> List.sum
        (sum / 2)
        

    let numberOfEvenNumberInListFilter list =
        let deuces = list |> List.filter (fun x -> x % 2 = 0)
        deuces.Length

    let numberOfEvenNumberInListFold list =
        List.fold (fun acc x -> if (x % 2 = 0) then (acc + 1)
                                else acc) 0 list