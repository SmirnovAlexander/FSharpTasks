module Logic

    // Returnes 2 lists cutted from 1 list in the center.
    let cutTheList list = 
        let rec loop (list: 'a list) (rightList: 'a list) (leftList:'a list) : ('a list * 'a list) = 
            match list with
            | [] -> (rightList, leftList)
            | [x] -> (x::rightList, leftList)
            | firstElement::secondElement::tail -> loop tail (firstElement::rightList) (secondElement::leftList)
        loop list [] []

    // Merges two sorted lists in one sorted list. 
    let rec merge (list1: 'a list) (list2:'a list) : 'a list =
        match list1, list2 with
        | [], list -> list
        | list, [] -> list
        | firstElemInFirstList::tailOfFirstList, firstElemInSecondList::tailfOfSecondList when 
            firstElemInFirstList < firstElemInSecondList -> 
                firstElemInFirstList::(merge tailOfFirstList (firstElemInSecondList::tailfOfSecondList))
        | firstList, firstElemInSecondList::tailfOfSecondList -> 
            firstElemInSecondList::(merge firstList tailfOfSecondList)

    // Merge sort algorythm.
    let rec mergeSort (listToSort:'a list) : 'a list =
        match listToSort with
        | [] -> []
        | [x] -> [x]
        | list ->
            let (firstHalf,secondHalf) = cutTheList(list)
            let firstHalfSorted = mergeSort(firstHalf)
            let secondHalfSorted = mergeSort(secondHalf)
            merge firstHalfSorted secondHalfSorted