module tests

    open NUnit.Framework
    open FsUnit
    open logic
    open FsCheck.NUnit

    [<Test>]
    let ``Trivial test`` () =
        (|>) List.map ( (>>) (*) ) 2 [1;2;3] |> should equal [2;4;6]

    [<Property>]
    let ``Running tests with FsCheck``(x:int, l:list<int>) =        
        (|>) List.map ( (>>) (*) ) x l = (List.map (fun y -> y * x) l)