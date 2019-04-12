module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Sum of all even fibonacci elements below 1000000 should be 1089154`` () =
        sumOfEvenFibonacciLessThenMillion ()|> should equal 1089154