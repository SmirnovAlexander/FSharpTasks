module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 

    let mutable stack = Stack()

    [<SetUp>]
    let ``run before test``() =
        stack <- Stack()

    [<Test>]
    let ``Push`` () =
        stack.Push(1)
        stack.Push(2)
        stack.Push(3)
        stack.GetStack() |> should equal [3; 2; 1]
    
    [<Test>]
    let ``Pop`` () =
        stack.Push(1)
        stack.Push(2)
        stack.Push(3)
        stack.Pop() |> should equal (3, [2; 1])

    [<Test>]
    let ``Pop from empty stack`` () =
        (fun () -> stack.Pop() |> ignore) |> should throw typeof<System.Exception>

    [<Test>]
    let ``IsEmpty (true)`` () =
        stack.IsEmpty |> should equal true

    [<Test>]
    let ``IsEmpty (false)`` () =
        stack.Push(1)
        stack.IsEmpty |> should equal false