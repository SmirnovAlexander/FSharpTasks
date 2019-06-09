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
    let ``CreateMultiThreadedLazy(calculating value once)``() =
        let mutable count = (int64) 0
        let lazyObj = LazyFactory.CreateMultiThreadedLazy(fun () -> 
            Interlocked.Increment &count |> ignore 
            (Interlocked.Read &count) |> should equal 1)             
        for i in 1..10 do
            Task.Run(fun () -> (lazyObj :> ILazy<unit>).Get()) |> ignore

    [<Test>]
    let ``CreateMultiLockfreeThreadedLazy``() =
        let lazyObj = LazyFactory.CreateMultiLockfreeThreadedLazy(fun () -> 1)
        (lazyObj :> ILazy<int>).Get () |> should equal 1

    