module Logic

    open System

    // Workflow that makes math operations with given accuracy (as Builder argument).
    type RoundBuilder(accuracy: int) =
        member this.Bind(x: float, f) =
                f (Math.Round(x, accuracy))
        member this.Return(x: float) = 
            Math.Round(x, accuracy)