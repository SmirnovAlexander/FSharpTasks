module Tests

    open NUnit.Framework
    open FsUnit
    open Logic    
    open MathNet.Numerics.LinearAlgebra

    // Initializing connections matrix
    let mutable connections = matrix [[0.0]]

    [<SetUp>]
    let ``run before test``() =
        connections <- matrix  [[0.0; 1.0; 0.0; 0.0; 0.0; 0.0]; 
                                [1.0; 0.0; 1.0; 0.0; 0.0; 0.0];
                                [0.0; 1.0; 0.0; 1.0; 0.0; 0.0];
                                [0.0; 0.0; 1.0; 0.0; 1.0; 0.0];
                                [0.0; 0.0; 0.0; 1.0; 0.0; 1.0];
                                [0.0; 0.0; 0.0; 0.0; 1.0; 0.0];
                               ] 

    (*
        Creating 6 computers, connected 1 by 1 from 1st to 6th.
        First computer infected, infect probability = 1 for each computer.
        Expecting to infect 1 computer each turn
    *)
    
    [<Test>]
    let ``Infect 1st computer`` () =
        // List of computers in network.   
        let computers = [
            Computer(0, OS("osX", 1.0), true); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game = GamePlay(computers, connections)
        game.MakeTurn
        game.Computers.[1].IsInfected |> should equal true
    
    [<Test>]
    let ``Infect 2nd computer`` () =
        // List of computers in network.   
        let computers = [
            Computer(0, OS("osX", 1.0), true); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game = GamePlay(computers, connections)
        game.MakeTurn
        game.MakeTurn       
        game.Computers.[2].IsInfected |> should equal true

    [<Test>]
    let ``Infect 3rd computer`` () =
        // List of computers in network.   
        let computers = [
            Computer(0, OS("osX", 1.0), true); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game = GamePlay(computers, connections)
        game.MakeTurn
        game.MakeTurn     
        game.MakeTurn     
        game.Computers.[3].IsInfected |> should equal true
    
    [<Test>]
    let ``Infect 4th computer`` () =
        // List of computers in network.   
        let computers = [
            Computer(0, OS("osX", 1.0), true); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game = GamePlay(computers, connections)
        game.MakeTurn
        game.MakeTurn
        game.MakeTurn
        game.MakeTurn
        game.Computers.[4].IsInfected |> should equal true
    
    [<Test>]
    let ``Infect 5th computer`` () =
        // List of computers in network.   
        let computers = [
            Computer(0, OS("osX", 1.0), true); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game = GamePlay(computers, connections)
        game.MakeTurn
        game.MakeTurn
        game.MakeTurn
        game.MakeTurn
        game.MakeTurn
        game.Computers.[5].IsInfected |> should equal true

    (*
        Creating 6 computers, connected 1 by 1 from 1st to 6th.
        No computers infected.
        Expecting game to end after 1 turn.
    *)

    [<Test>]
    let ``Game should ends after 1 turn`` () =
        // List of computers in network.   
        let computers'1 = [
            Computer(0, OS("osX", 1.0), false); 
            Computer(1, OS("Windows", 1.0), false);
            Computer(2, OS("osX", 1.0), false)
            Computer(3, OS("Linux", 1.0), false); 
            Computer(4, OS("osX", 1.0), false);
            Computer(5, OS("Windows", 1.0), false)]

        let game'1 = GamePlay(computers'1, connections)
        game'1.MakeTurn
        game'1.IsRunning |> should equal false