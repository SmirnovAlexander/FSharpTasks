module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Check for single brackets`` () =
        bracketsCheck "{x}" |> should equal true

    [<Test>]
    let ``Wrong one`` () =
        bracketsCheck "(y)(x))" |> should equal false

    [<Test>]
    let ``Wrong order of brackets`` () =
        bracketsCheck "}[y]y{" |> should equal false

    [<Test>]
    let ``Correct one`` () =
        bracketsCheck "{}{}sdfsdf()" |> should equal true

    [<Test>]
    let ``Null input`` () =
        bracketsCheck ""  |> should equal true

    [<Test>]
    let ``Shuffled brackets`` () =
        bracketsCheck "{[}]"  |> should equal false