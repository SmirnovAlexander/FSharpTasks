module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    // -----

    let expression1 = 
        Multiplication(Addition(Number 2, Number 3) , Addition(Number 4, Number 5))

    [<Test>]
    let ``(2 + 3) * (4 + 5) = 45`` () =
        expression1 |> evaluation |> should equal 45

    // -----

    let expression2 = 
        Addition(Addition(Multiplication(Number 0, Number 3), Multiplication(Number 2, Addition(Number 3, Number 4))), Number 1)

    [<Test>]
    let ``0 * 3 + 2 * (3 + 4) + 1 = 15`` () =
        expression2 |> evaluation |> should equal 15

    // -----

    let expression3 = 
       Division(Number 5, Number 3)

    [<Test>]
    let ``5 / 3 = 1`` () =
        expression3 |> evaluation |> should equal 1