module Tests

    open NUnit.Framework
    open FsUnit
    open Logic

    // Testing numberOfEvenNumberInListMap.
    [<Test>]
    let ``numberOfEvenNumberInListMap given [] should return 0`` () =
        numberOfEvenNumberInListMap [] |> should equal 0

    [<Test>]
    let ``numberOfEvenNumberInListMap given [2] should return 1`` () =
        numberOfEvenNumberInListMap [2] |> should equal 1

    [<Test>]
    let ``numberOfEvenNumberInListMap given [1..10] should return 5`` () =
        numberOfEvenNumberInListMap [1..10] |> should equal 5

    [<Test>]
    let ``numberOfEvenNumberInListMap given [1; 2; 25; 5; 6] should return 2`` () =
        numberOfEvenNumberInListMap [1; 2; 25; 5; 6] |> should equal 2

    // Testing numberOfEvenNumberInListFilter.
    [<Test>]
    let ``numberOfEvenNumberInListFilter given [] should return 0`` () =
        numberOfEvenNumberInListFilter [] |> should equal 0

    [<Test>]
    let ``numberOfEvenNumberInListFilter given [2] should return 1`` () =
        numberOfEvenNumberInListFilter [2] |> should equal 1

    [<Test>]
    let ``numberOfEvenNumberInListFilter given [1..10] should return 5`` () =
        numberOfEvenNumberInListFilter [1..10] |> should equal 5

    [<Test>]
    let ``numberOfEvenNumberInListFilter given [1; 2; 25; 5; 6] should return 2`` () =
        numberOfEvenNumberInListFilter [1; 2; 25; 5; 6] |> should equal 2

    // Testing numberOfEvenNumberInListFilter.
    [<Test>]
    let ``numberOfEvenNumberInListFold given [] should return 0`` () =
        numberOfEvenNumberInListFold [] |> should equal 0

    [<Test>]
    let ``numberOfEvenNumberInListFold given [2] should return 1`` () =
        numberOfEvenNumberInListFold [2] |> should equal 1

    [<Test>]
    let ``numberOfEvenNumberInListFold given [1..10] should return 5`` () =
        numberOfEvenNumberInListFold [1..10] |> should equal 5

    [<Test>]
    let ``numberOfEvenNumberInListFold given [1; 2; 25; 5; 6] should return 2`` () =
        numberOfEvenNumberInListFold [1; 2; 25; 5; 6] |> should equal 2

