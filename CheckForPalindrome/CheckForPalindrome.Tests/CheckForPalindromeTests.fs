module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    [<Test>]
    let ``Check if madam is palindrome`` () =
        checkForPalindrome "madam" |> should equal true

    [<Test>]
    let ``Check if "" is palindrome`` () =
        checkForPalindrome "" |> should equal true

    [<Test>]
    let ``Check if math is palindrome`` () =
        checkForPalindrome "math" |> should equal false