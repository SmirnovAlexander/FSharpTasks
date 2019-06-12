module Tests

    open Logic
    open NUnit.Framework
    open FsUnit

    [<Test>]
    let ``reverse [1; 2; 3] = [3; 2; 1]``() =
        reverse [1; 2; 3] |> should equal [3; 2; 1]

    [<Test>]
    let ``reverse [] = []``() =
        reverse [] |> should equal []

    [<Test>]
    let ``reverse [1] = [1]``() =
        reverse [1] |> should equal [1]

    [<Test>]
    let ``reverse ['a'; 'b'; 'c'] = ['c'; 'b'; 'a']``() =
        reverse ['a'; 'b'; 'c'] |> should equal ['c'; 'b'; 'a']