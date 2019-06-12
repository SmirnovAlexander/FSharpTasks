module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``fibonacci 5 = 5``() =
        fibonacci 5 |> should equal 5

    [<Test>]
    let ``fibonacci 6 = 8``() =
        fibonacci 6 |> should equal 8

    [<Test>]
    let ``fibonacci 0 = 0``() =
        fibonacci 0 |> should equal 0

    [<Test>]
    let ``fibonacci 1 = 1``() =
        fibonacci 1 |> should equal 1

    [<Test>]
    let ``fibonacci 2 = 1``() =
        fibonacci 2 |> should equal 1

    [<Test>]
    let ``fibonacci 3 = 2``() =
        fibonacci 3 |> should equal 2

    [<Test>]
    let ``fibonacci -2 -----> WrongInputError``() =
        (fun () -> fibonacci -2 |> ignore) |> should throw typeof<WrongInputError>