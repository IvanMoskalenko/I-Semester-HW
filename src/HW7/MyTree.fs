module myTree
open myList

type MyTree<'t> =
    | Leaf of 't
    | Node of 't * MyList<MyTree<'t>>

let rec countNodesAndLeaves x =
    let rec _go acc x =
        match x with
        | Leaf _ -> acc + 1
        | Node (_, tl) ->
            let rec _go1 acc2 tl =
                match tl with
                | Base t -> _go acc t + acc2
                | Cons (hd, tl) -> _go1 (acc2 + _go acc hd) tl
            _go1 1 tl
    _go 0 x

let averageMyTree x =
    let rec _go acc x =
        match x with
        | Leaf t -> acc + t
        | Node (hd, tl) ->
            let rec _go1 acc1 tl =
                match tl with
                | Base t -> _go acc t + acc1
                | Cons (hd, tl) -> _go1 (acc1 + _go acc hd)  tl
            _go1 hd tl
    _go 0 x / countNodesAndLeaves x

let maxElemMyTree x =
    let rec _go acc x =
        match x with
        | Leaf t -> if acc > t then acc else t
        | Node (hd, tl) ->
            let rec _go1 y tl =
                match tl with
                | Base t ->
                    if acc > y
                    then _go acc t
                    else _go y t
                | Cons (t, k) ->
                    if acc > y
                    then _go1 (_go acc t) k
                    else _go1 (_go y t) k
            _go1 hd tl
    _go -2147483648 x


