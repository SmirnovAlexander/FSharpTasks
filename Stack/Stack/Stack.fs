module Logic

    // Stack type.
    type Stack() = 

        // Private mutable list.
        let mutable stack = []
        
        // Pushing one element.
        member this.Push element =
            stack <- element::stack

        // Popping element.
        // If there are elements in stack we return
        // top element and rest of a stack.
        member this.Pop = 
            match stack with 
            | top::rest -> 
                stack <- rest
                (top, stack)
            | [] -> failwith "Stack underflow"
        
        // If stack is empty.
        member this.IsEmpty = 
            match stack with 
            | [] -> 
                true
            | _ -> 
                false

        // Getting stack.
        member this.GetStack() =
            stack