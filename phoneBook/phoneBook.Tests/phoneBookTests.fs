module Tests

    open NUnit.Framework
    open FsUnit
    open Logic    
    
    // Initializing comparing maps.
    let book = PhoneBook ()
    let mutable mapToCompare = Map.empty
    let mutable mapToFill = Map.empty
    let mutable mapToFill'1 = Map.empty
    let mutable mapToFill'2 = Map.empty
    let mutable mapToFill'3 = Map.empty

    [<SetUp>]
    let ``run before test``() =
        mapToFill'1 <- book.AddToBook(mapToFill, "Sanya", "+79119727982")
        mapToFill'2 <- book.AddToBook(mapToFill'1, "Fedos", "+79312208944")
        mapToFill'3 <- book.AddToBook(mapToFill'2, "Taya", "+79210938070")
        mapToCompare <- Map.empty
                                  .Add("Sanya", "+79119727982")
                                  .Add("Fedos", "+79312208944")
                                  .Add("Taya", "+79210938070")
    (*
        Add record tests.
    *)

    [<Test>]
    let ``Adding some elements to fill book.``() =        
        mapToFill'3 |> should equal mapToCompare

    [<Test>]
    let ``Adding element with a name that already been in DB. Value should be overriden.``() =
        let mapToCompare = book.AddToBook(mapToFill'2, "Taya", "+79210938071")
        let mapToFill'4 = book.AddToBook(mapToFill'3, "Taya", "+79210938071")                            
        mapToFill'4 |> should equal mapToCompare

    (*
        Find name and phone tests.
    *)

    [<Test>]
    let ``Search for a Sanya number.``() =          
        let mapToCompare = Map.empty
                            .Add("Sanya","+79119727982")
        book.FindPhoneByName (mapToFill'3, "Sanya") |> should equal mapToCompare

    [<Test>]
    let ``Searching for a name matching +79312208944 phone.``() =                            
        let mapToCompare = Map.empty
                            .Add("Fedos","+79312208944")
        book.FindNameByPhone (mapToFill'3, "+79312208944") |> should equal mapToCompare
    
    (*
        Test shows that database serealized and deserilized correctly.
    *)

    [<Test>]
    let ``Comparing DB to its decerialized serealized version.``() = 
        book.Serialize(mapToFill'3)
        mapToFill'3 |> should equal (book.Deserialize(mapToFill'3))