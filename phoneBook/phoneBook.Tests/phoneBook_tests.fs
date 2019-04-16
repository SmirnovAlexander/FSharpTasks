module Tests

    open NUnit.Framework
    open FsUnit
    open Logic    
    
    let book = phoneBook ()

    (*
        Add record tests.
    *)

    // Map with 3 elements to
    // compare our adding with.
    let mapToCompare = Map.empty
                              .Add("Sanya","+79119727982")
                              .Add("Fedos","+79312208944")
                              .Add("Taya","+79210938070")

    [<Test>]
    [<Order(1)>]
    let ``Adding some elements to fill book.``() =

        book.addToBook("Sanya","+79119727982") |> ignore
        book.addToBook("Fedos","+79312208944") |> ignore
        book.addToBook("Taya","+79210938070") |> ignore
                            
        book.book |> should equal mapToCompare

    // Adding an element to our comparing map.
    let mapToCompare'1 = mapToCompare
                              .Add("Ilya","+79633289584")
    
    [<Test>]
    [<Order(2)>]
    let ``Adding another element.``() =

        book.addToBook("Ilya","+79633289584") |> ignore
              
        book.book |> should equal mapToCompare'1

    [<Test>]
    [<Order(3)>]
    let ``Adding element with a name that already been in DB. Element should not be added.``() =

        book.addToBook("Sanya","88005553535") |> ignore
                            
        book.book |> should equal mapToCompare'1

    [<Test>]
    [<Order(4)>]
    let ``Adding element with a phone that already been in DB. Element should not be added.``() =

        book.addToBook("Egor","+79119727982") |> ignore
                            
        book.book |> should equal mapToCompare'1

    (*
        Find name and phone tests.
    *)

    [<Test>]
    [<Order(5)>]
    let ``Search for a Sanya number.``() =                            
        book.findPhoneByName "Sanya" |> should equal "+79119727982"

    [<Test>]
    [<Order(6)>]
    let ``Search for a number of a person who is not in DB.``() =                            
        book.findPhoneByName "Vaselisa" |> should equal "No phone matching this name."

    [<Test>]
    [<Order(7)>]
    let ``Searching for a name matching +79312208944 phone.``() =                            
        book.findNameByPhone "+79312208944" |> should equal "Fedos"
    
    [<Test>]
    [<Order(8)>]
    let ``Search for a name by phone which is not in DB.``() =                            
        book.findNameByPhone "88005553535" |> should equal "No name matching this phone."

    (*
        Test shows that database serealized and deserilized correctly.
    *)

    [<Test>]
    [<Order(9)>]
    let ``Comparing DB to its decerialized serealized version.``() = 
        book.serealize
        book.book |> should equal book.deserealize