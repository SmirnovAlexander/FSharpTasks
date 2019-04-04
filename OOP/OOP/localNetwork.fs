module logic =

    open System

    // Computer class.
    type Computer(id: int, os: string, isInfected: bool) =
        
        let mutable IsInfected = isInfected
       
        member this.id = id
        member this.os = os
        member this.isInfected = IsInfected

        member this.changeState = 
            if (IsInfected = true) then IsInfected <- false
                                   else IsInfected <- true
        
    // Map of infection probability.
    let infectProbability =
        Map.empty.
            Add("osX", 0.25).
            Add("Windows", 0.75).            
            Add("Linux", 0.5)

    // List of computers in network.   
    let computers = [
        Computer(1, "osX", true); 
        Computer(2, "Windows", false);
        Computer(3, "Linux", false)
        Computer(4, "osX", false); 
        Computer(5, "Windows", false);
        Computer(6, "Linux", false)]

    let numberOfComputers = computers.Length
    let mutable numberOfInfectedComputers = 1
    
    // Connection between computer (comparing by id).
    let isConnected (computer1: Computer) (computer2: Computer) =
        if (computer1.id = computers.[0].id && computer2.id = computers.[1].id) then true
        else if (computer1.id = computers.[1].id && computer2.id = computers.[2].id) then true
        else if (computer1.id = computers.[2].id && computer2.id = computers.[3].id) then true
        else if (computer1.id = computers.[3].id && computer2.id = computers.[4].id) then true
        else if (computer1.id = computers.[4].id && computer2.id = computers.[5].id) then true
        else if (computer1.id = computers.[5].id && computer2.id = computers.[6].id) then true
        else false
        
    
    // Displaying network condition.
    let condition () =
        printfn"-------------"
        for computer in computers do
            printfn "id: %i, os: %s, infected: %b" computer.id computer.os computer.isInfected
        printfn"-------------"


    // Making pairs out of computers list.
    let rec pairs list =
        match list with
        | [] | [_] -> []
        | h :: t -> 
            [for x in t do
                yield h,x
             yield! pairs t]

    
    // Tries to infect a single computer according to its infection probability.
    let tryToInfect (computer: Computer) = 

         let os = computer.os 
         let probabity = Map.find os infectProbability
         let random = new Random()
         let randInt = random.Next(101)

         if (float (randInt) < probabity * 100.0) then 
           
            computer.changeState
            
            numberOfInfectedComputers <- numberOfInfectedComputers + 1
            Console.ForegroundColor<-ConsoleColor.Red
            printfn "Successfully infected computer %i" computer.id
            Console.ForegroundColor<-ConsoleColor.White



    // Iterating throw each pair and trying to infect.
    let infection () =

        // Making pairs.
        let computerPairs = pairs computers

        for pair in computerPairs do
            
            // If computers are connected.
            if (isConnected (fst pair) (snd pair)) then 

                // If first computer infected and second is not.
                if ((fst pair).isInfected = true && (snd pair).isInfected = false) then

                    Console.ForegroundColor<-ConsoleColor.Yellow
                    printfn "Trying to infect computer %i from computer %i" (snd pair).id (fst pair).id
                    tryToInfect (snd pair)
                    Console.ForegroundColor<-ConsoleColor.White

                // If second computer infected and first is not.
                else if ((fst pair).isInfected = false && (snd pair).isInfected = true) then
                    Console.ForegroundColor<-ConsoleColor.Yellow
                    printfn "Trying to infect computer %i from computer %i" (fst pair).id (snd pair).id
                    tryToInfect (fst pair)
                    Console.ForegroundColor<-ConsoleColor.White
    
    // Printing condotion before we start.
    condition ()
    
    // While not all computer are infected or we do not have a single one infected we keep running.
    while ((numberOfInfectedComputers <> numberOfComputers) && (numberOfInfectedComputers <> 0)) do
        infection()
        condition ()

    if (numberOfInfectedComputers = numberOfComputers) then printf "all computers are infected"
    else if (numberOfInfectedComputers = 0) then printf "No virus"

    Console.ReadKey() |> ignore