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
        let rec sort acc rev list =
            match list, rev with
            | [], true -> acc |> List.rev
            | [], false -> acc |> List.rev |> sort [] true
            | x :: y :: tail, _ when x > y -> sort (y :: acc) false (x :: tail)
            | head :: tail, _ -> sort (head :: acc) rev tail
        sort [] true list

    let thirdTask list =   //!
      let rec go lst cont =
        match lst with
        | [] -> cont []
        | head :: tail -> 
          let left, right = tail |> List.partition (fun i -> i < head)
          go left (fun accLeft -> 
          go right (fun accRight -> cont (accLeft @ head :: accRight)))
      go list (fun x -> x)

    let rec fourthTask (arr : 'a []) =
        match arr with
        | [||] | [| _ |] -> arr
        | _ -> let l, (r, pivots) = Array.partition (fun n -> n < arr.[0]) arr
                                    |> (fun (l, r) -> l, r |> Array.partition (fun n -> n <> arr.[0]))
               Array.concat <| seq { yield (fourthTask l); yield pivots; yield (fourthTask r) }

    let pack32bitinto64bit (x: int32) (y: int32) =
        let x = x |> int64
        let y = y |> int64
        let transform: int64 = (x <<< 32) ||| y
        transform

    let unpack64bitinto32bit (transform: int64) =
        let res1 = transform >>> 32 |> int32
        let res2 = (transform <<< 32) >>> 32 |> int32
        let result = [|res1; res2|]
        result

    let pack16bitinto64bit (x: int16) (y: int16) (z: int16) (a: int16) =
        let x = x |> int64
        let y = y |> int64
        let z = z |> int64
        let a = a |> int64
        let transform: int64 = (x <<< 48) ||| (y <<< 32) ||| (z <<< 16) ||| a
        transform

    let unpack64bitinto16bit (transform: int64) =
        let res1 = transform >>> 48 |> int16
        let res2 = (transform <<< 16) >>> 48 |> int16
        let res3 = (transform <<< 32) >>> 48 |> int16
        let res4 = (transform <<< 48) >>> 48 |> int16
        let result = [|res1; res2; res3; res4|]
        result
        


