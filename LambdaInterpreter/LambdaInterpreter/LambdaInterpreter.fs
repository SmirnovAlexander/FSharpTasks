module Logic

    /// All symbols that may appear in lambda expression.
    type Token =
        | LeftBracket
        | RightBracket
        | Lambda
        | Dot
        | Variable of char

    /// List of input chars to list of tokens.
    let rec tokenize (text: char list) =
        match text with
        | [] -> []
        | '('::tail -> LeftBracket::(tokenize tail)
        | ')'::tail -> RightBracket::(tokenize tail)
        | '.'::tail -> Dot::(tokenize tail)
        | '\\'::tail -> Lambda::(tokenize tail)
        | head::tail -> (if List.contains head (List.ofSeq "abcdefghijklmnopqrstuvwxyz")
                        then [Variable head]
                        else []) @ tokenize tail
    
    /// All terms that we might have.
    /// VariableT is just a variable.
    /// LambdaT is an expression of lamda and a term (\x.\y.x).
    /// ApplicationT is a function applied to another function (\x.x \y.y).
    /// ClosureT is just the same as lambda but it knows about environment
    /// where it was defined.
    type Term =
        | VariableT of char
        | LambdaT of char*Term
        | ClosureT of char*Term*Env
        | ApplicationT of Term*Term

    /// Type that keeps information about already seen variables in lambdas.
    and Env = (char*Term) list

    /// Going throw token list and searches for term patterns.
    let rec parseSingle (tokens: Token list): (Term*Token list) =
        match tokens with

        // Searches for variable terms.
        | (Variable name::rest) -> VariableT name, rest

        // Searches for lambda terms.
        | (Lambda::Variable arg::Dot::bodyCode) -> let body, rest = parseSingle bodyCode
                                                   LambdaT (arg, body), rest

        // Searches for application terms.
        | LeftBracket::code -> let func, afterFirst = parseSingle code // Parsing first functon.
                               let value, afterValue = parseSingle afterFirst // Parsing second function.
                               match afterValue with
                               | RightBracket::rest -> ApplicationT (func, value), rest
                               | _ -> failwith "Expected )"
        | _ -> failwith "Bad parse"

    /// Parsing list of tokens to terms.  
    let parse (tokens: Token list) = 
        fst <| parseSingle tokens

    /// Evaluating our term in the environment.
    let rec evaluateInEnvironment (environment: Env) (term: Term): Term =
        match term with

        // Trying to find a term when spot a variable 
        // (we should fail if we given "x" for example).
        | VariableT name ->
            match List.tryFind (fun (aName, term) -> aName = name) environment with
            | Some (_, term) -> term
            | None -> failwith "Couldn't find a term by name"

        // Evaluating lambda to closure so it knows
        // environment where it was defined.
        | LambdaT (arg, body) -> ClosureT (arg, body, environment) 
        
        // Evaluating a function making a closure from it. 
        | ApplicationT (func, value) ->
            match evaluateInEnvironment environment func with
            | ClosureT (arg, body, closedEnv) ->
                let evaluatedValue = evaluateInEnvironment environment value
                let newEnv = (arg, evaluatedValue)::closedEnv @ environment
                evaluateInEnvironment newEnv body
            | _ -> failwith "Cannot apply something given"

        | closure -> closure
    
    /// Evaluating our term.
    let evaluate (term: Term): Term =
        evaluateInEnvironment [] term

    /// Given an evaluated term returns a char list.
    let rec termToCharList (term: Term): char list =
      match term with
        | VariableT name -> [name]
        | LambdaT (arg, body) -> ['\\'; arg; '.'] @ termToCharList body
        | ClosureT (arg, body, _) -> ['\\'; arg; '.'] @ termToCharList body
        | ApplicationT (func, value) -> ['('] @ termToCharList func @ [' '] @ termToCharList value @ [')']

    /// Gets a charlist of input and returns the charlist of output.
    let interpeter (charList: char list) =
        charList
            |> tokenize
            |> parse
            |> evaluate
            |> termToCharList

    /// Getting and preparing input string,
    /// getting and concatenating result.
    let interpString (str: string) =
        str
            |> List.ofSeq
            |> interpeter
            |> List.map string
            |> String.concat ""