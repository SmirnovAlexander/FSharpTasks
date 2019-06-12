module Tests

    open NUnit.Framework
    open FsUnit
    open Logic
    open FsCheck.NUnit

    [<Test>]
    let ``Trivial test`` () =
        pointFreeMap'5 () 2 [1; 2; 3] |> should equal [2; 4; 6]

    [<Property>]
    let ``Running tests with FsCheck``(x:int, l:list<int>) =        
        pointFreeMap'5 () x l = (List.map (fun y -> y * x) l)