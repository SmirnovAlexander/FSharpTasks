module Logic
    
    open System

    // Workflow that make math operations with numbers
    // given in strings.
    type StringCalculationBuilder() =
        member this.Bind(x: string, f) =                         
            let res = Int32.TryParse(x)
            if  (fst res) then f (snd res)
            else None                             
        member this.Return(x) =
            Some(x)