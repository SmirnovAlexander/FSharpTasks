module Logic

    type Tree<'a> = 
      | Empty
      | Node of value: 'a * left: Tree<'a> * right: Tree<'a>

    let rec applyFuncToAllElements (tree : Tree<'a>) someFunction =
      match tree with
      | Empty -> tree
      | Node (value, left, right) ->       
        let value' = someFunction value
        let left' = applyFuncToAllElements left someFunction
        let right' = applyFuncToAllElements right someFunction
        Node (value', left', right')