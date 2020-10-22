namespace HW4

module hw4 =

    let readArray file =
        let a = System.IO.File.ReadAllLines file
        let intArr = Array.zeroCreate a.Length
        let mutable j = 0
        for i in a do
            intArr.[j] <- int (i.Trim())
            j <- j + 1
        intArr

    let readList file =
        let a = System.IO.File.ReadAllLines file
        let intList = [ for i in a -> int (i.Trim()) ]
        intList

    let arrayOfIntIntoArrayOfStrings (array: int array) =
        let resArray = Array.create array.Length ""
        for i in 0 .. array.Length - 1 do
            resArray.[i] <- array.[i] |> string
        resArray

    let firstTask (arrayForSort: int array) =
        for i = 0 to arrayForSort.Length - 1 do
            for j = i + 1 to arrayForSort.Length - 1 do
                if arrayForSort.[i] > arrayForSort.[j]
                then
                    arrayForSort.[i] <- arrayForSort.[i] + arrayForSort.[j]
                    arrayForSort.[j] <- arrayForSort.[i] - arrayForSort.[j]
                    arrayForSort.[i] <- arrayForSort.[i] - arrayForSort.[j]
        arrayForSort

    let secondTask list =
        let rec sort acc reverse list =
            match list, reverse with
            | [], true -> acc |> List.rev
            | [], false -> acc |> List.rev |> sort [] true
            | x :: y :: tail, _ when x > y -> sort (y :: acc) false (x :: tail)
            | head :: tail, _ -> sort (head :: acc) reverse tail
        sort [] true list

    let thirdTask list =
        let split opCompare list =
            let rec go lst part1 part2 =
                match lst with
                | [] -> part1, part2
                | hd :: tl ->
                    if opCompare hd
                    then go tl (hd :: part1) part2
                    else go tl part1 (hd :: part2)
            go list [] []

        let rec go lst =
            match lst with
            | [] -> []
            | [x] -> [x]
            | hd :: tl ->
                let left, right = split ((>) hd) tl
                (go left) @ hd :: (go right)

        go list

    let rec quickSortArray = function
        | [||] -> [||]
        | x when x.Length < 2 -> x
        | x ->
        let left, (right, pivot) = Array.partition (fun i -> i < x.[0]) x |> (fun (left, right) -> left, right |> Array.partition (fun n -> n <> x.[0]))
        Array.append (Array.append (left |> quickSortArray ) pivot) (right |> quickSortArray )

    let fourthTask (x: int array) =
        quickSortArray  x

    let fifthTask (x: int32) (y: int32) =
        let x2 = abs (x) |> int64
        let y2 = abs (y) |> int64
        let transform: int64 = (x2 <<< 32) ||| y2
        let res1 = transform >>> 32 |> int32
        let res2 = transform |> int32
        let result1 x = if x < 0 then -res1 else res1
        let result2 y = if y < 0 then -res2 else res2
        let result = [|result1 x; result2 y|]
        result

    let sixthTask (x: int16) (y: int16) (z: int16) (a: int16) =
        let x2 = abs (x) |> int64
        let y2 = abs (y) |> int64
        let z2 = abs (z) |> int64
        let a2 = abs (a) |> int64
        let transform: int64 = (x2 <<< 48) ||| (y2 <<< 32) ||| (z2 <<< 16) ||| a2
        let res1 = transform >>> 48 |> int16
        let res2 = (transform <<< 16) >>> 48 |> int16
        let res3 = (transform <<< 32) >>> 48 |> int16
        let res4 = (transform <<< 48) >>> 48 |> int16
        let result1 (x: int16) = if x < 0s then -res1 else res1
        let result2 (y: int16) = if y < 0s then -res2 else res2
        let result3 (z: int16) = if z < 0s then -res3 else res3
        let result4 (a: int16) = if a < 0s then -res4 else res4
        let result = [|result1 x; result2 y; result3 z; result4 a|]
        result



