module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    let calculate = StringCalculationBuilder()

    [<Test>]
    let ``Sum of two string sumbers``() =
        let result = calculate {
            let! x = "1"
            let! y = "2"
            let z = x + y
            return z
        }
        result |> should equal (Some 3)

    [<Test>]
    let ``Sum of two string sumbers (2)``() =
        let result = calculate {
            let! x = "101"
            let! y = "20"
            let z = x + y
            return z
        }
        result |> should equal (Some 121)

    [<Test>]
    let ``Wrong input test``() =
        let result = calculate {
            let! x = "1"
            let! y = "ъ"
            let z = x + y
            return z
        }
        result |> should equal (None)