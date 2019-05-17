module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 

    [<Test>]
    let ``Push`` () =
        let stack = Stack()
        stack.Push(1)
        stack.Push(2)
        stack.Push(3)
        stack.GetStack() |> should equal [3; 2; 1]
    
    [<Test>]
    let ``Pop`` () =
        let stack = Stack()
        stack.Push(1)
        stack.Push(2)
        stack.Push(3)
        stack.Pop |> should equal (3, [2; 1])

    [<Test>]
    let ``Pop from empty stack`` () =
        let stack = Stack()
        (fun () -> stack.Pop |> ignore) |> should throw typeof<System.Exception>

    [<Test>]
    let ``IsEmpty (true)`` () =
        let stack = Stack()
        stack.IsEmpty |> should equal true

    [<Test>]
    let ``IsEmpty (false)`` () =
        let stack = Stack()
        stack.Push(1)
        stack.IsEmpty |> should equal false