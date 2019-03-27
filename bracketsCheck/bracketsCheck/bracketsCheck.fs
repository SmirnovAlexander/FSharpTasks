module logic 

    let bracketsCheck (string : string) =
        let listOfChars = Seq.toList string
        let rec loop list counter1 counter2 counter3 =
            match list with
                | head::tail -> if ((counter1 < 0) || (counter2 < 0) || (counter3 < 0)) then Some(false)
                                                                                        else match head with 
                                                                                             | '(' -> loop tail (counter1 + 1) counter2 counter3
                                                                                             | ')' -> loop tail (counter1 - 1) counter2 counter3
                                                                                             | '{' -> loop tail counter1 (counter2 + 1) counter3
                                                                                             | '}' -> loop tail counter1 (counter2 - 1) counter3
                                                                                             | '[' -> loop tail counter1 counter2 (counter3 + 1)
                                                                                             | ']' -> loop tail counter1 counter2 (counter3 - 1)
                                                                                             | _ -> loop tail counter1 counter2 counter3
                | [] -> if ((counter1 = 0) && (counter2 = 0) && (counter3 = 0)) then Some(true)
                                                                                else Some(false)
        loop listOfChars 0 0 0    