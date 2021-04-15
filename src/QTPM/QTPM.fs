module QTPM
open QTSM
open AlgebraicStructures

let parallelMultiply x y structure deepness =
    let operation, neutral = getOperationAndNeutral structure true
    let rec _go x y c =
        match x, y with
        | Leaf a, Leaf b ->
            let res = operation a b
            if res = neutral then None else Leaf res
        | None, _ -> None
        | _, None -> None
        | Node (x1, x2, x3, x4), Node (y1, y2, y3, y4) ->
            if c < deepness
            then
                let NW = async {return sum (_go x1 y1 (c + 1)) (_go x2 y3 (c + 1)) structure}
                let NE = async {return sum (_go x1 y2 (c + 1)) (_go x2 y4 (c + 1)) structure}
                let SW = async {return sum (_go x3 y1 (c + 1)) (_go x4 y3 (c + 1)) structure}
                let SE = async {return sum (_go x3 y2 (c + 1)) (_go x4 y4 (c + 1)) structure}
                let res = [NW; NE; SW; SE] |> Async.Parallel |> Async.RunSynchronously
                if res.[0] = None && res.[1] = None && res.[2] = None && res.[3] = None then None
                else Node (res.[0], res.[1], res.[2], res.[3])
            else
                let NW = sum (_go x1 y1 c) (_go x2 y3 c) structure
                let NE = sum (_go x1 y2 c) (_go x2 y4 c) structure
                let SW = sum (_go x3 y1 c) (_go x4 y3 c) structure
                let SE = sum (_go x3 y2 c) (_go x4 y4 c) structure
                if NW = None && NE = None && SW = None && SE = None then None
                else Node (NW, NE, SW, SE)
        | _, _ -> failwith "It's impossible to multiply this"
    _go x y 1