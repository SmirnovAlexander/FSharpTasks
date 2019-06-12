module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Check palindrome function works correctly (1)`` () =
        checkForPalindrome 1001 |> should equal true

    [<Test>]
    let ``Check palindrome function works correctly (2)`` () =
        checkForPalindrome 1021 |> should equal false

    [<Test>]
    let ``Final check`` () =
        biggestPalindrome () |> should equal 906609