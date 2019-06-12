module Tests

    open Logic
    open NUnit.Framework
    open FsUnit   
    
    [<Test>]
    let ``((\x.\y.x  \a.(a a))   \b.b)  -----> \a.(a a)``() =        
        (interpString(@"((\x.\y.x \a.(a a)) \b.b)")) |> should equal ("\\a.(a a)")

    [<Test>]
    let ``(\x.x \y.y) -----> \y.y``() =        
        (interpString(@"(\x.x \y.y)")) |> should equal ("\\y.y")

    [<Test>]
    let ``(\x.x -----> \x.x)``() =        
        (interpString(@"\x.x")) |> should equal ("\\x.x")

    [<Test>]
    let ``((\x.x \y.y) \z.(z z)) -----> \z.(z z)``() =        
        (interpString(@"((\x.x \y.y)\z.(z z))")) |> should equal ("\\z.(z z)")

    [<Test>]
    let ``((\x.\y.\z.(z z) \y.y) -----> \y.\z.(z z))``() =        
        (interpString(@"(\x.\y.\z.(z z) \y.y)")) |> should equal ("\\y.\\z.(z z)")  
        
    [<Test>]
    let capture() =
        (interpString(@"((\x.\y.(x y) \t.y) \y.y)")) |> should equal ("\\y.y")     