module myList

type MyList<'t> =
    | Base of 't
    | Cons of 't * MyList<'t>

let myListLength lst =
    let rec _go lst acc =
        match lst with
        | Base _ -> acc + 1
        | Cons (_, tl) -> _go tl (acc + 1)
    _go lst 0

let rec iter f lst =
    match lst with
    | Base hd -> f hd
    | Cons (hd, tl) ->
        f hd
        iter f tl

let rec map f lst =
    match lst with
    | Base hd -> Base (f hd)
    | Cons (hd, tl) -> Cons (f hd, map f tl)

let rec transformSystemListToMyList lst =
    match lst with
    | [] -> failwith "List mustn't be empty"
    | [x] -> Base x
    | hd :: tl -> Cons (hd, transformSystemListToMyList tl)

let rec concatenateMyLists lst1 lst2 =
    match lst1 with
    | Base hd -> Cons (hd, lst2)
    | Cons (hd, tl) -> Cons (hd, concatenateMyLists tl lst2)

let sortMyList lst =
    let mutable k = 0
    let rec _go lst =
        let res =
            match lst with
            | Cons (fst, Cons(snd, tail)) ->
                if fst > snd
                then Cons (snd, _go (Cons (fst, tail)))
                else Cons (fst, _go (Cons (snd, tail)))
            | Base x -> Base x
            | Cons (fst, Base x) ->
                if fst > x
                then Cons (x, Base fst)
                else Cons (fst, Base x)
        if k < myListLength lst
        then
            k <- k + 1
            _go res
        else res
    _go lst

