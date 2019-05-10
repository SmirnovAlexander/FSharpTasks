module Tests

    open NUnit.Framework
    open FsUnit
    open Logic 
    open System

    let comparator = StringComparer.CurrentCulture
    let hashTable = HashMap(comparator)

    [<Test>]
    let ``Add and count`` () =
        hashTable.Add("Bob","Msk")
        hashTable.Add("Mark","Spb")
        hashTable.Count |> should equal 2

    [<Test>]
    let ``Remove`` () =
        hashTable.Remove("Mark")
        hashTable.Count |> should equal 1