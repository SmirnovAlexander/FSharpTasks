module logic

    let pointFreeMap x l = List.map (fun y -> y * x) l
    
    let pointFreeMap'1 x l = List.map ( (*) x) l
  
    let pointFreeMap'2 x = List.map ( (*) x)
    
    let pointFreeMap'3 = fun x -> List.map ( (*) x)
    
    let pointFreeMap'4 = (|>) List.map ( (>>) (*) )