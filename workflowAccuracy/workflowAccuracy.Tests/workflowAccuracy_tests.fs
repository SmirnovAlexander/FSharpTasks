module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``3 symbols after dot``() =
        let result = RoundBuilder 3 {
            let! a = 2.0 / 12.0
            let! b = 3.5
            return a / b
        }
        result |> should equal 0.048

    [<Test>]
    let ``5 symbols after dot``() =
        let result = RoundBuilder 5 {
            let! a = 8.0
            let! b = 13.0
            return a / b
        }
        result |> should equal 0.61538

    [<Test>]
    let ``7 symbols after dot``() =
        let result = RoundBuilder 7 {
            let! a = 8.0
            let! b = 7.0
            return a / b
        }
        result |> should equal 1.1428571