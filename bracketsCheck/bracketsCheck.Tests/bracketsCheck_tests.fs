module tests

open NUnit.Framework
open FsUnit
open logic

[<Test>]
let ``Check for single brackets`` () =
    bracketsCheck "{x}" |> should equal (Some true)

[<Test>]
let ``Wrong one`` () =
    bracketsCheck "(y)(x))" |> should equal (Some false)

[<Test>]
let ``Wrong order of brackets`` () =
    bracketsCheck "}[y]y{" |> should equal (Some false)

[<Test>]
let ``Correct one`` () =
    bracketsCheck "{}{}sdfsdf()" |> should equal (Some true)

[<Test>]
let ``Null input`` () =
    bracketsCheck ""  |> should equal (Some true);