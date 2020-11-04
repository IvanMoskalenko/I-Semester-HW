namespace HW5
module sorts =

    let arrayBubbleSort (arrayForSort: int array) =
        for i = 0 to arrayForSort.Length - 1 do
            for j = i + 1 to arrayForSort.Length - 1 do
                if arrayForSort.[i] > arrayForSort.[j]
                then
                    let x = arrayForSort.[i]
                    arrayForSort.[i] <- arrayForSort.[j]
                    arrayForSort.[j] <- x
        arrayForSort

    let listBubbleSort (list: list<int>) =
        let mutable k = 0
        let rec _go (list: list<int>) =
            let res =
                match list with
                | [] -> []
                | x :: y :: tail ->
                    if x > y
                    then
                        y :: (_go (x :: tail))
                    else
                        x :: (_go (y :: tail))
                | x :: tail -> [x]
            if k < list.Length
            then
                k <- k + 1
                _go res
            else res
        _go list

    let listQuickSort list =
        let split opCompare list =
            let rec go lst part1 part2 =
                match lst with
                | [] -> part1, part2
                | hd :: tl ->
                    if opCompare hd
                    then go tl (hd :: part1) part2
                    else go tl part1 (hd :: part2)
            go list [] []

        let rec _go lst =
            match lst with
            | [] -> []
            | [x] -> [x]
            | hd :: tl ->
                let left, right = split ((>) hd) tl
                (_go left) @ hd :: (_go right)

        _go list

    let rec quickSortArrayForExperiments = function
        | [||] -> [||]
        | x when x.Length < 2 -> x
        | x ->
        let left, (right, pivot) = Array.partition (fun i -> i < x.[0]) x |> (fun (left, right) -> left, right |> Array.partition (fun n -> n <> x.[0]))
        Array.append (Array.append (left |> quickSortArrayForExperiments ) pivot) (right |> quickSortArrayForExperiments )

    let arrayQuickSortForExperiments (x: int array) =
        quickSortArrayForExperiments  x

    let rec arrayQuickSort (arr: array<int>) =
        if arr.Length <= 1
        then
            arr
        else
            let pivot = arr.[arr.Length / 2]
            let pivots, leftright = Array.partition(fun i -> i = pivot) arr
            let left, right = Array.partition(fun i -> i < pivot) leftright
            Array.append (Array.append (arrayQuickSort left) pivots) (arrayQuickSort right)
