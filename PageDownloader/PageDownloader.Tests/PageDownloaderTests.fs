module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``NumberOfLettersOnInnerPages``() =
        NumberOfLettersOnInnerPages("http://hwproj.me/courses/31") |> should equal null