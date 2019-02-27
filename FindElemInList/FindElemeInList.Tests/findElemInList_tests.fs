module tests

open NUnit.Framework
open FsUnit
open logic

[<Test>]
let ``The index of element "6" in array [7;32;4;6;4;6] is Some(3)`` () =
    findElemInList [7;32;4;6;4;6] 6 |> should equal (Some(3))

[<Test>]
let ``The index of element "6" in array [for i in 1..10 -> i*i] is Some(4)`` () =
    findElemInList [for i in 1..10 -> i*i] 25 |> should equal (Some(5))

[<Test>]
let ``The index of element "3" in array [] is None`` () =
    findElemInList [] 3 |> should equal None
