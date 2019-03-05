module tests

open NUnit.Framework
open FsUnit
open logic

[<Test>]
let ``Five primes after three primes skiped are [7; 11; 13; 17; 19]`` () =
    primes () |> Seq.skip 3 |> Seq.take 5 |> Seq.toArray |> should equal [7; 11; 13; 17; 19]

[<Test>]
let ``100th prime is 547`` () =
    primes () |> Seq.skip 100 |> Seq.take 1 |> Seq.toArray |> should equal [547]

[<Test>]
let ``First prime is 2`` () =
    primes () |> Seq.take 1 |> Seq.toArray |> should equal [2]