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