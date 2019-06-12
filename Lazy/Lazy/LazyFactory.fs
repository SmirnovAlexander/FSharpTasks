module LazyFactory

    open Logic

    /// Class to create objects which are differs in calculation mode.
    type LazyFactory() =
        
        /// Simple single threaded object.
        static member CreateSingleThreadedLazy (supplier : unit -> 'a) = 
            LazySingleMode<'a>(supplier)

        /// Multithreading object.
        static member CreateMultiThreadedLazy (supplier : unit -> 'a) = 
            LazyMultiMode<'a>(supplier) 

        /// Multithreading lock-free object.
        static member CreateMultiLockfreeThreadedLazy (supplier : unit -> 'a) = 
            LazyMultiLockfreeMode<'a>(supplier)