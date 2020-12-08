module myTree
open myList

type MyTree<'t> =
    | Leaf of 't
    | Node of 't * MyList<MyTree<'t>>

let rec walk x f f1 f2 _goStart =
    let rec _go acc x =
        match x with
        | Leaf y1 -> f acc y1
        | Node (hd, tl) ->
            let rec _go1 acc1 tl =
                match tl with
                | Base t -> _go (f2 acc acc1) t + f1 acc1
                | Cons (hd, tl) -> _go1 (f1 acc1 + _go (f2 acc acc1) hd) tl
            _go1 (f _goStart hd) tl
    _go _goStart x

let rec countNodesAndLeaves x =
    let f acc _ = acc + 1
    let f1 acc1 = acc1
    let f2 acc _ = acc
    let _goStart = 0
    walk x f f1 f2 _goStart

let average x =
    let f acc y1 = acc + y1
    let f1 acc1 = acc1
    let f2 acc _ = acc
    let _goStart = 0
    walk x f f1 f2 _goStart / countNodesAndLeaves x

let max x =
    let f acc y1 = if y1 > acc then y1 else acc
    let f1 _ = 0
    let f2 _ acc1 = acc1
    let _goStart = System.Int32.MinValue
    walk x f f1 f2 _goStart
