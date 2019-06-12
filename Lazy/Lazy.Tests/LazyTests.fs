module Tests
        
    open Logic
    open NUnit.Framework
    open FsUnit
    open LazyFactory
    open System.Threading
    open System.Threading.Tasks
    
    [<Test>]
    let ``CreateSingleThreadedLazy``() =
        let lazyObj = LazyFactory.CreateSingleThreadedLazy(fun () -> 1)
        (lazyObj :> ILazy<int>).Get() |> should equal 1

    [<Test>]
    let ``CreateSingleThreadedLazy(calculating value once)``() =
        let mutable counter = (int64) 0
        let lazyObj = LazyFactory.CreateSingleThreadedLazy(fun () -> 
            Interlocked.Increment &counter |> ignore 
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..10 do
            Task.Run(fun () -> (lazyObj :> ILazy<unit>).Get()) |> ignore

    [<Test>]
    let ``CreateMultiThreadedLazy(all values match)``() =
        let lazyObj = LazyFactory.CreateMultiThreadedLazy(fun () -> new obj())
        let expression = (lazyObj :> ILazy<obj>).Get()
        Seq.map(fun obj -> expression |> ((lazyObj :> ILazy<obj>).Get ()).Equals |> should be True) [|1..10|] |> ignore

    [<Test>]
    let ``CreateMultiThreadedLazy(calculating value once)``() =
        let mutable counter = (int64) 0
        let lazyObj = LazyFactory.CreateMultiThreadedLazy(fun () -> 
            Interlocked.Increment &counter |> ignore 
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..10 do
            Task.Run(fun () -> (lazyObj :> ILazy<unit>).Get()) |> ignore

    [<Test>]
    let ``CreateMultiLockfreeThreadedLazy``() =
        let lazyObj = LazyFactory.CreateMultiLockfreeThreadedLazy(fun () -> 1)
        (lazyObj :> ILazy<int>).Get () |> should equal 1

    [<Test>]
    let ``CreateMultiLockfreeThreadedLazy(all values match)``() =
        let lazyObj = LazyFactory.CreateMultiLockfreeThreadedLazy(fun () -> new obj())
        let expression = (lazyObj :> ILazy<obj>).Get()
        Seq.map(fun obj -> expression |> ((lazyObj :> ILazy<obj>).Get ()).Equals |> should be True) [|1..10|] |> ignore

    [<Test>]
    let ``CreateMultiLockfreeThreadedLazy(calculating value once)``() =
        let mutable counter = (int64) 0
        let lazyObj = LazyFactory.CreateMultiLockfreeThreadedLazy(fun () -> 
            Interlocked.Increment &counter |> ignore 
            (Interlocked.Read &counter) |> should equal 1)             
        for i in 1..10 do
            Task.Run(fun () -> (lazyObj :> ILazy<unit>).Get()) |> ignore        