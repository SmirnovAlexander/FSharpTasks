module Logic

    // Find index of first element appearence in the list.
    let findElemInList list elementToFind =
        let rec loop list elementToFind counter =
            match list with
            | head :: tail -> if (head = elementToFind)
                                then Some(counter)
                                else loop tail elementToFind (counter + 1)
            | [] -> None
        loop list elementToFind 0
             
    // Result.
    let list = [7; 32; 4; 6; 4; 6]
    let elementToFind = 6
    let result = findElemInList list elementToFind