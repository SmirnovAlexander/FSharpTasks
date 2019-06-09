module Logic

    open System.Collections.Generic

    /// Clearing string from all symbols except brackets and return list of brackets.
    let leaveOnlyBrackets (str : string) =

        let brackets = ['('; '['; '{'; ')'; ']'; '}']

        // Making list of chars.
        let strList = str.ToCharArray() |> Array.toList

        // Filtering list.
        let onlyBracketsList = strList |> List.filter(fun x -> List.contains(x) brackets)

        onlyBracketsList  

    /// Checks for brackets correctness.
    let bracketsCheck (str : string) =

        let onlyBracketsList = leaveOnlyBrackets (str)
        let stack = Stack()

        let rec loop (brackets: list<char>, stack: Stack<char>) =
            match brackets with
            | [] -> stack.Count = 0
            | head::tail -> if ((head = '(') || (head = '[') || (head = '{')) then stack.Push(head)
                                                                                   loop (tail, stack)
                            else if (head = ')') then if ((stack.Count = 0) || (stack.Pop() <> '(')) then false
                                                      else loop (tail, stack)
                            else if (head = ']') then if ((stack.Count = 0) || (stack.Pop() <> '[')) then false
                                                      else loop (tail, stack)
                            else                      if ((stack.Count = 0) || (stack.Pop() <> '{')) then false
                                                      else loop (tail, stack)
                                                      
        loop (onlyBracketsList, stack)      