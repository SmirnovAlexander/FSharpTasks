module Logic

    open System.Threading

    /// Lazy calculations interface.
    type ILazy<'a> =

        /// First call of Get() method calls calculation and returns result.
        /// Repeats of Get() calls return same object, as a first call.
        /// In a single thread mode calculation should start only once, 
        /// in multithread — look below.
        abstract member Get: unit -> 'a

    /// Simple version with guarantee of correct work
    /// in a single thread mode (without synchronization).
    type LazySingleMode<'a> (supplier : unit -> 'a) = 
        
        let mutable result = None

        interface ILazy<'a> with
            member this.Get() = 
                match result with 
                | Some(x) -> x
                | None -> let result'1 = supplier()
                          result <- Some(result'1)
                          result'1

    /// Guarantee of correct work in a multithreaded mode.
    /// Calculation should not be made more than once.
    type LazyMultiMode<'a> (supplier : unit -> 'a) =
    
        let mutable result = None        
        let object = obj()
        
        interface ILazy<'a> with
            member this.Get() =
                match result with 
                | Some(x) -> x
                | None -> lock object (fun () -> 
                          match result with
                          | None -> let result'1 = supplier()
                                    result <- Some result'1
                                    result'1
                          | Some(x) -> x)

    /// Guarantee of correct work in a multithreaded mode but lock-free.
    /// Calculation may run more than once, 
    /// but Lazy.Get always should return same object.            
    type LazyMultiLockfreeMode<'a> (supplier : unit -> 'a) = 

        let mutable result = None

        interface ILazy<'a> with
            member this.Get() = 
                match result with
                | Some(x) -> x
                | None -> let result'1 = supplier()
                          Interlocked.CompareExchange(&result, Some result'1, None) |> ignore
                          Option.get result
