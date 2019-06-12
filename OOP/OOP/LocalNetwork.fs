module Logic

    open System
    open System.Collections.Generic
    open MathNet.Numerics.LinearAlgebra

    /// Operation system class.
    type OS(name: string, infectProbability: float) =    
        member this.Name = name
        member this.InfectProbability = infectProbability

    /// Computer class.
    type Computer(id: int, os: OS, isInfected: bool) =
        
        let mutable isInfected = isInfected
       
        member this.Id = id
        member this.Os = os
        member this.IsInfected = isInfected

        member this.ChangeState = isInfected <- true
                       
    /// Game condition type.
    /// To have a condition of a game we need a list of computers
    /// and coonections between them.
    type GameCondition(computers: list<Computer>, connections: Matrix<float>) =

        (*
            Initializing class methods.
        *)

        // Method to make pairs out of computers list.
        let rec pairs list =
            match list with
            | [] | [_] -> []
            | h :: t -> 
                [for x in t do
                    yield h, x
                 yield! pairs t]

        // Counting number of infected computers.
        let countInfectedComputers (computers: list<Computer>) =
            Seq.fold (fun acc (elem: Computer) -> if (elem.IsInfected) then (acc + 1) else acc) 0 computers           

        
        (*
            Initializing class fields.
        *)

        // Initializing a counter for infected computers.
        let mutable numberOfInfectedComputers = countInfectedComputers computers

        // Initializing game running variable that shows if game is still running.
        let mutable isRunning = true

        // Initializing random variable.
        let random = new Random()
                 

        // Initializing computers and connections.
        member this.Computers = computers
        member this.Connections = connections

        // Total number of computers.
        member this.NumberOfComputers = computers.Length

        // Making class member of infected computers.
        member this.NumberOfInfectedComputers = numberOfInfectedComputers

        // Making class member of game running.
        member this.IsRunning = isRunning
        
        // Connection between computer (comparing by id).
        member this.IsConnected (computer1: Computer) (computer2: Computer) =
             connections.Item(computer1.Id, computer2.Id) > 0.5
        
        (*
            Initializing main class fields:
                - condition
                - infection
                - checkIsOver
        *)

        // Displaying network condition.
        member this.Condition () =
            printfn"-------------"
            for computer in computers do
                printfn "id: %i, os: %s, infected: %b" computer.Id computer.Os.Name computer.IsInfected
            printfn"-------------"



        // Iterating throw each pair and trying to infect.
        member this.Infection() =

            // List of computers which should be infected at the end of a turn.
            let whomToInfectAtTheEndOfATurn = new List<Computer>()

            // Tries to infect a single computer according to its infection probability.
            let tryToInfect (computer: Computer) = 

                 let os = computer.Os 
                 let probabity = os.InfectProbability
                 let randInt = random.Next(101)

                 if (float (randInt) < probabity * 101.0) then 
           
                    // If we got probability to infect computer we
                    // add it to the list.
                    whomToInfectAtTheEndOfATurn.Add(computer)
           
                    // Printing.
                    Console.ForegroundColor <- ConsoleColor.Red
                    printfn "Successfully infected computer %i" computer.Id
                    Console.ForegroundColor <- ConsoleColor.White

            // Making pairs.
            let computerPairs = pairs computers

            for pair in computerPairs do
            
                // If computers are connected.
                if (this.IsConnected (fst pair) (snd pair)) then 

                    // If first computer infected and second is not.
                    if ((fst pair).IsInfected && not (snd pair).IsInfected) then

                        Console.ForegroundColor <- ConsoleColor.Yellow
                        printfn "Trying to infect computer %i from computer %i" (snd pair).Id (fst pair).Id
                        tryToInfect (snd pair)
                        Console.ForegroundColor <- ConsoleColor.White

                    // If second computer infected and first is not.
                    else if (not (fst pair).IsInfected && (snd pair).IsInfected) then
                        Console.ForegroundColor <- ConsoleColor.Yellow
                        printfn "Trying to infect computer %i from computer %i" (fst pair).Id (snd pair).Id
                        tryToInfect (fst pair)
                        Console.ForegroundColor <- ConsoleColor.White

            for computer in whomToInfectAtTheEndOfATurn do
                computer.ChangeState
                numberOfInfectedComputers <- numberOfInfectedComputers + 1
            
            printfn "numberOfInfectedComputers = %i, numberOfComputers = %i" this.NumberOfInfectedComputers this.NumberOfComputers

        // Member to check if game is over.
        member this.CheckIsOver() =

             // If all computer are infected or not a single one infected game finishing.
            if ((this.NumberOfInfectedComputers = this.NumberOfComputers) || (this.NumberOfInfectedComputers = 0)) then
                isRunning <- false       

    /// Game play type.
    /// To start a game we need a list of computers
    /// and coonections between them.
    type GamePlay(computers: list<Computer>, connections: Matrix<float>) =

        // GameCondition instance.
        let gameCondition = GameCondition(computers, connections)

        // Link on computers list.
        member this.Computers =
            gameCondition.Computers 

        // Link on gamestate.
        member this.IsRunning =
            gameCondition.IsRunning

        // Turn member.
        member this.MakeTurn = 

            // If game running we make a turn.
            if (gameCondition.IsRunning) then
                gameCondition.Infection()
                gameCondition.Condition()
                gameCondition.CheckIsOver()                

        // Game member.
        member this.PlayGame = 

            // Printing condition before we start.
            gameCondition.Condition ()
    
            // While game is running we make turns.
            while (gameCondition.IsRunning) do
                this.MakeTurn

            if (gameCondition.NumberOfInfectedComputers = gameCondition.NumberOfComputers) then 
                                                                                 printf "all computers are infected"
                                                                         else if (gameCondition.NumberOfInfectedComputers = 0) then 
                                                                                 printf "No virus"
            
            Console.ReadKey() |> ignore