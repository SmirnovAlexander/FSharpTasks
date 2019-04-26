module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``First 4 numbers of first sequence are [1; -1; 1; -1]`` () =
        ones () |> Seq.take 4 |> Seq.toArray |> should equal [1; -1; 1; -1]

    [<Test>]
    let ``First 4 numbers of second sequence are [1; 2; 3; 4]`` () =
        numbers () |> Seq.take 4 |> Seq.toArray |> should equal [1; 2; 3; 4]
    
    [<Test>]
    let ``First 4 numbers of final sequence are [1, -2, 3, -4]`` () =
        series () |> Seq.take 4 |> Seq.toArray |> should equal [1; -2; 3; -4]