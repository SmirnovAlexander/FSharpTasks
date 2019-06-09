module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``Check for number of links on page``() =
        numberOfLettersOnInnerPages("http://hwproj.me/courses/31").Length |> should equal 17

    [<Test>]
    let ``Check for number of links on page (2)``() =
        numberOfLettersOnInnerPages("https://www.youtube.com").Length |> should equal 3