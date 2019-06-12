module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``3! = 6``() =
        factorial 3 |> should equal 6

    [<Test>]
    let ``1! = 1``() =
        factorial 1 |> should equal 1

    [<Test>]
    let ``0! = 1``() =
        factorial 0 |> should equal 1

    [<Test>]
    let ``5! = 120``() =
        factorial 5 |> should equal 120
    
    [<Test>]
    let ``-2! -----> WrongInputError``() =
        (fun () -> factorial -2 |> ignore) |> should throw typeof<WrongInputError>