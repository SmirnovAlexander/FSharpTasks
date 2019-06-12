module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``Fill list with powers of two from power 3 with 2 elements = [8; 16]``() =
        fillListWithPowersOfTwo 3 2 |> should equal [8; 16]

    [<Test>]
    let ``Fill list with powers of two from power 5 with 3 elements = [32; 64; 128]``() =
        fillListWithPowersOfTwo 5 3 |> should equal [32; 64; 128]

    [<Test>]
    let ``Fill list with powers of two from power 0 with 3 elements = [1; 2; 4]``() =
        fillListWithPowersOfTwo 0 3 |> should equal [1; 2; 4]

    [<Test>]
    let ``Fill list with powers of two from power 1 with 4 elements =  [2; 4; 8; 16]``() =
        fillListWithPowersOfTwo 1 4 |> should equal [2; 4; 8; 16]

    [<Test>]
    let ``Fill list with powers of two from power 1 with 1 elements = [2]``() =
        fillListWithPowersOfTwo 1 1 |> should equal [2]