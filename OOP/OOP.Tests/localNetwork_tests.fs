module Tests

    open NUnit.Framework
    open FsUnit
    open Logic    
    open MathNet.Numerics.LinearAlgebra


    (*
        Creating 6 computers, connected 1 by 1 from 1st to 6th.
        First computer infected, infect probability = 1 for each computer.
        Expecting to infect 1 computer each turn
    *)

    // List of computers in network.   
    let computers = [
        Computer(0, OS("osX", 1.0), true); 
        Computer(1, OS("Windows", 1.0), false);
        Computer(2, OS("osX", 1.0), false)
        Computer(3, OS("Linux", 1.0), false); 
        Computer(4, OS("osX", 1.0), false);
        Computer(5, OS("Windows", 1.0), false)]

    // Connections matrix
    let connections = matrix [[0.0; 1.0; 0.0; 0.0; 0.0; 0.0]; 
                              [1.0; 0.0; 1.0; 0.0; 0.0; 0.0];
                              [0.0; 1.0; 0.0; 1.0; 0.0; 0.0];
                              [0.0; 0.0; 1.0; 0.0; 1.0; 0.0];
                              [0.0; 0.0; 0.0; 1.0; 0.0; 1.0];
                              [0.0; 0.0; 0.0; 0.0; 1.0; 0.0];
                             ] 

    let game = Game(computers, connections)

    [<Test>]
    let ``Infect 1st computer`` () =
        game.makeTurn
        game.computers.[1].isInfected |> should equal true
    
    [<Test>]
    let ``Infect 2nd computer`` () =
        game.makeTurn
        game.computers.[2].isInfected |> should equal true

    [<Test>]
    let ``Infect 3rd computer`` () =
        game.makeTurn
        game.computers.[3].isInfected |> should equal true
    
    [<Test>]
    let ``Infect 4th computer`` () =
        game.makeTurn
        game.computers.[4].isInfected |> should equal true
    
    [<Test>]
    let ``Infect 5th computer`` () =
        game.makeTurn
        game.computers.[5].isInfected |> should equal true

    (*
        Creating 6 computers, connected 1 by 1 from 1st to 6th.
        No computers infected.
        Expecting game to end after 1 turn.
    *)

    // List of computers in network.   
    let computers'1 = [
        Computer(0, OS("osX", 1.0), false); 
        Computer(1, OS("Windows", 1.0), false);
        Computer(2, OS("osX", 1.0), false)
        Computer(3, OS("Linux", 1.0), false); 
        Computer(4, OS("osX", 1.0), false);
        Computer(5, OS("Windows", 1.0), false)]

    // Connections matrix
    let connections'1 = matrix [[0.0; 1.0; 0.0; 0.0; 0.0; 0.0]; 
                                [1.0; 0.0; 1.0; 0.0; 0.0; 0.0];
                                [0.0; 1.0; 0.0; 1.0; 0.0; 0.0];
                                [0.0; 0.0; 1.0; 0.0; 1.0; 0.0];
                                [0.0; 0.0; 0.0; 1.0; 0.0; 1.0];
                                [0.0; 0.0; 0.0; 0.0; 1.0; 0.0];
                               ] 
 
    let game'1 = Game(computers'1, connections'1)

    [<Test>]
    let ``Game should ends after 1 turn`` () =
        game'1.makeTurn
        game'1.isRunning |> should equal false