module tests

open NUnit.Framework
open FsUnit
open logic

[<Test>]
let ``Sorting [7;32;4;6;4;6] should return [4;4;6;6;7;32]`` () =
    mergeSort [7;32;4;6;4;6] |> should equal [4;4;6;6;7;32]

[<Test>]
let ``Sorting [] should return []`` () =
    mergeSort [] |> should equal []

[<Test>]
let ``Sorting [2] should return [2]`` () =
    mergeSort [2] |> should equal [2]