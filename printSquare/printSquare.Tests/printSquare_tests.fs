module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Check for 3* square`` () =
        prepareString 3 |> should equal "***\n* *\n***\n"