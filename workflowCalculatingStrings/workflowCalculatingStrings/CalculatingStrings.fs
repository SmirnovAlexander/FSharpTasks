module Logic
    
    type StringCalculationBuilder() =
        member this.Bind(x: string, f) = 
            try
                f (int x)
            with
                | :? System.FormatException -> printfn "Wrong input type!"; None
        member this.Return(x) =
            Some(x)