namespace HW4

module hw4 =

    let arrayOfIntIntoArrayOfStrings (array: int array) =
        let resArray = Array.create array.Length ""
        for i in 0 .. array.Length - 1 do
            resArray.[i] <- array.[i] |> string
        resArray

    let readArray file =
        let a = System.IO.File.ReadAllLines file
        let intArr = [| for i in a -> int (i.Trim()) |]
        intArr

    let readList file =
        let a = System.IO.File.ReadAllLines file
        let intList = [ for i in a -> int (i.Trim()) ]
        intList

    let writeArray file array = System.IO.File.WriteAllLines ((file), arrayOfIntIntoArrayOfStrings array)
    let writeList file list = System.IO.File.WriteAllLines ((file), arrayOfIntIntoArrayOfStrings (List.toArray list))

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

    let arrayQuickSort (arr: array<int>) =
        let swap (arr: array<int>) i j =
            let c = arr.[i]
            arr.[i] <- arr.[j]
            arr.[j] <- c
        let partition (arr: array<int>) low high =
            let pivot = arr.[high]
            let mutable lowIndex = low - 1
            for i = low to (high - 1) do
                if arr.[i] <= pivot
                then
                    lowIndex <- lowIndex + 1
                    swap arr lowIndex i
            swap arr (lowIndex + 1) high
            lowIndex + 1
        let rec _go (arr: array<int>) low high =
            if low < high
            then
                let partIndex = partition arr low high
                if partIndex > 1 then _go arr low (partIndex - 1)
                if (partIndex + 1) < high then _go arr (partIndex + 1) high
        _go arr 0 (arr.Length - 1)
        arr

    let pack32bitInto64 (x: int32, y: int32) =
        if y >= 0
        then
            (x |> int64 <<< 32) + (y |> int64)
        else
            (x |> int64 <<< 32) + (2.0 ** 32.0 |> int64) + (y |> int64)

    let unpack64bitInto32 (transformed: int64) =
        (transformed >>> 32 |> int32, (transformed <<< 32) >>> 32 |> int32)

    let pack16bitInto32 (x: int16, y: int16) =
        if y >= 0s
        then
            (x |> int32 <<< 16) + (y |> int32)
        else
            (x |> int32 <<< 16) + (2.0 ** 16.0 |> int32) + (y |> int32)

    let pack16bitInto64 (x: int16, y: int16, z: int16, a: int16) =
        pack32bitInto64 (pack16bitInto32 (x, y), pack16bitInto32 (z, a))

    let unpack32bitInto16 (transformed: int) =
        (transformed >>> 16 |> int16, (transformed <<< 16) >>> 16 |> int16)

    let unpack64bitInto16 (transformed: int64) =
        let xy, za = unpack64bitInto32 transformed
        let x, y = unpack32bitInto16 xy
        let z, a = unpack32bitInto16 za
        (x, y, z, a)





