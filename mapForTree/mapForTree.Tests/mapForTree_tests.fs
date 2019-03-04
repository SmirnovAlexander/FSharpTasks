module tests

open NUnit.Framework
open FsUnit
open logic

// -----

let tree1 = 
    Node (1, Empty, Empty)

let tree1_afterExecution = 
    Node (2, Empty, Empty)

[<Test>]
let ``Every element of tree1 should be doubled`` () =
    applyFuncToAllElements tree1 (fun x -> 2 * x) |> should equal tree1_afterExecution

// -----

let tree2 =
    Node (20, 
    Node (10, Empty, Empty), 
    Node (30, 
        Node (5, Empty, Empty), 
        Node (40, Empty, Empty)))

let tree2_afterExecution =
    Node (400, 
    Node (100, Empty, Empty), 
    Node (900, 
        Node (25, Empty, Empty), 
        Node (1600, Empty, Empty)))

[<Test>]
let ``Every element of tree2 should be squared`` () =
    applyFuncToAllElements tree2 (fun x -> x * x) |> should equal tree2_afterExecution

// -----

let tree3 =
    Node ("c", 
    Node ("b", Empty, Empty), 
    Node ("d", 
        Node ("a", Empty, Empty), 
        Node ("e", Empty, Empty)))

let tree3_afterExecution =
    Node ("ca", 
    Node ("ba", Empty, Empty), 
    Node ("da", 
        Node ("aa", Empty, Empty), 
        Node ("ea", Empty, Empty)))

[<Test>]
let ``Empty tree3 should stay empty`` () =
    applyFuncToAllElements tree3 (fun x -> x + "a") |> should equal tree3_afterExecution

// -----


