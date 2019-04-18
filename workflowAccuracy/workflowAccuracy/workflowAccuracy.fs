module Logic

    open System

    type RoundBuilder(accuracy: int) =
        member this.Bind(x, f) =
            f x
        member this.Return(x: float) = 
            Math.Round(x, accuracy)