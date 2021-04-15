module Tests
open QTPM
open QTSM
open AlgebraicStructures
open Expecto

let semiring = new Semiring<int>(new Monoid<int>((+), 0), (*))
let structure = Semiring semiring
let rand = new System.Random()

let genRandomTree h =
    let rec go h =
        if h = 1
        then Leaf (rand.Next())
        else Node (go (h - 1), go (h - 1), go (h - 1), go (h - 1))
    go h

[<Tests>]
let tests =
    testList "Test for QuadTree Parallel Multiply" [
        testProperty "Multiply" <| fun _ ->
            let x = genRandomTree 7
            let y = genRandomTree 7
            let res1 = multiply x y structure
            let res2 = parallelMultiply x y structure 3
            Expect.equal res1 res2 ""]