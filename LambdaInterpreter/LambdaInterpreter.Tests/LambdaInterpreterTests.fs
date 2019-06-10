module Tests

    open Logic
    open NUnit.Framework
    open FsUnit   
    
    [<Test>]
    let ``((\x.\y.x  \a.(a a))   \b.b)  -----> \a.(a a)``() =        
        (interpString("((\\x.\\y.x  \\a.(a a))   \\b.b)")) |> should equal ("\\a.(a a)")

    [<Test>]
    let ``(\x.x \y.y) -----> \y.y``() =        
        (interpString("(\\x.x \\y.y)")) |> should equal ("\\y.y")