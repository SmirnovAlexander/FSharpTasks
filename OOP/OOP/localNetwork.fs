module Logic

    open System
    open System.Collections.Generic
    open MathNet.Numerics.LinearAlgebra

    // Operation system class.
    type OS(name: string, infectProbability: float) =    
        member this.name = name
        member this.infectProbability = infectProbability

    // Computer class.
    type Computer(id: int, os: OS, isInfected: bool) =
        
        let mutable IsInfected = isInfected
       
        member this.id = id
        member this.os = os
        member this.isInfected = IsInfected

        member this.changeState = IsInfected <- true
                       
    // Game type.
    // To start a game we need a list of computers
    // and coonections between them.
    type Game(computers: list<Computer>, connections: Matrix<float>) =

        (*
            Initializing class methods.
        *)

        // Method to make pairs out of computers list.
        let rec pairs list =
            match list with
            | [] | [_] -> []
            | h :: t -> 
                [for x in t do
                    yield h,x
                 yield! pairs t]

        // Counting number of infected computers.
        let countInfectedComputers (computers: list<Computer>) =
            let mutable counter = 0
            for computer in computers do
                if (computer.isInfected = true) then
                    counter <- counter + 1
            counter
        
        (*
            Initializing class fields.
        *)

        // Initializing a counter for infected computers.
        let mutable NumberOfInfectedComputers = countInfectedComputers computers

        // Initializing game running variable that shows if game is still running.
        let mutable IsRunning = true

        // Initializing computers and connections.
        member this.computers = computers
        member this.connections = connections

        // Total number of computers.
        member this.numberOfComputers = computers.Length

        // Making class member of infected computers.
        member this.numberOfInfectedComputers = NumberOfInfectedComputers

        // Making class member of game running.
        member this.isRunning = IsRunning
        
        // Connection between computer (comparing by id).
        member this.isConnected (computer1: Computer) (computer2: Computer) =
             connections.Item(computer1.id, computer2.id) > 0.5
        
        (*
            Initializing main class fields:
                - condition
                - infection
                - checkIsOver
        *)

        // Displaying network condition.
        member this.condition () =
            printfn"-------------"
            for computer in computers do
                printfn "id: %i, os: %s, infected: %b" computer.id computer.os.name computer.isInfected
            printfn"-------------"

        // Iterating throw each pair and trying to infect.
        member this.infection() =

            // List of computers which should be infected at the end of a turn.
            let WhomToInfectAtTheEndOfATurn = new List<Computer>()

            // Tries to infect a single computer according to its infection probability.
            let tryToInfect (computer: Computer) = 

                 let os = computer.os 
                 let probabity = os.infectProbability
                 let random = new Random()
                 let randInt = random.Next(101)

                 if (float (randInt) < probabity * 101.0) then 
           
                    // If we got probability to infect computer we
                    // add it to the list.
                    WhomToInfectAtTheEndOfATurn.Add(computer)
           
                    // Printing.
                    Console.ForegroundColor<-ConsoleColor.Red
                    printfn "Successfully infected computer %i" computer.id
                    Console.ForegroundColor<-ConsoleColor.White

            // Making pairs.
            let computerPairs = pairs computers

            for pair in computerPairs do
            
                // If computers are connected.
                if (this.isConnected (fst pair) (snd pair)) then 

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

            for computer in WhomToInfectAtTheEndOfATurn do
                computer.changeState
                NumberOfInfectedComputers <- NumberOfInfectedComputers + 1
            
            printfn "numberOfInfectedComputers = %i, numberOfComputers = %i" this.numberOfInfectedComputers this.numberOfComputers

        // Member to check if game is over.
        member this.checkIsOver() =

             // If all computer are infected or not a single one infected game finishing.
            if ((this.numberOfInfectedComputers = this.numberOfComputers) || (this.numberOfInfectedComputers = 0)) then
                IsRunning <- false
            
        (*
            Members to play game:
                - makeTurn
                - playGame
        *)
            
        // Turn member.
        member this.makeTurn = 

            // If game running we make a turn.
            if (this.isRunning) then
                this.infection()
                this.condition()
                this.checkIsOver()                

        // Game member.
        member this.playGame = 

            // Printing condition before we start.
            this.condition ()
    
            // While game is running we make turns.
            while (this.isRunning) do
                this.makeTurn

            if (this.numberOfInfectedComputers = this.numberOfComputers) then 
                                                                                 printf "all computers are infected"
                                                                         else if (this.numberOfInfectedComputers = 0) then 
                                                                                 printf "No virus"
            
            Console.ReadKey() |> ignore