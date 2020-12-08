module Tests
open Expecto
open myString
open myList
open myTree

let genRandomList count =
    let rnd = System.Random()
    let nCount = if count = 0 then rnd.Next(1, 1000) else abs count
    List.init nCount (fun _ -> rnd.Next(1000))

[<Tests>]
let propTestsForMyList =
    testList "Property tests for myList"
        [
            testProperty "Length test" <| fun x ->
                let lst = genRandomList x
                Expect.equal (List.length lst) (lst |> toMyList |> length) ""
            testProperty "Sort test" <| fun x ->
                let lst = genRandomList x
                Expect.equal (List.sort lst |> toMyList) (sort (lst |> toMyList)) ""
            testProperty "Iter test" <| fun x ->
                let lst = genRandomList x
                let a1 = Array.zeroCreate lst.Length
                let a2 = Array.ofList lst
                let mutable a = 0
                iter (fun x ->
                    a1.[a] <- x
                    a <- a + 1) (toMyList lst)
                Expect.sequenceEqual a1 a2 ""
            testProperty "Map test" <| fun x ->
                let lst = genRandomList x
                Expect.equal (List.map (fun i -> i * 7) lst |> toMyList) (map (fun i -> i * 7) (toMyList lst)) ""
            testProperty "Concatenate test" <| fun (x, y) ->
                let lst1 = genRandomList x
                let lst2 = genRandomList y
                Expect.equal (lst1 @ lst2 |> toMyList) (concatenate (lst1 |> toMyList) (lst2 |> toMyList)) ""
        ]

[<Tests>]
let MyListTests =
    testList "MyListTests"
        [
            testCase "Length" <| fun _ ->
                Expect.equal 2 (length (Cons (5, Base 4))) ""
            testCase "Length second" <| fun _ ->
                Expect.equal 3 (length (Cons (12, Cons (5, Base 4)))) ""

            testCase "map" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (map ((+) 1) (Cons (5, Base 4))) ""
            testCase "map second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (map ((+) 1) (Cons (12, Cons (5, Base 4)))) ""

            testCase "transform system list to MyList" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (toMyList [6; 5]) ""
            testCase "transform system list to MyList second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (toMyList [13; 6; 5]) ""

            testCase "concatenate myLists" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (concatenate (Base 6) (Base 5)) ""
            testCase "concatenate myLists second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (concatenate (Cons(13, Base 6)) (Base 5)) ""

            testCase "sort myList" <| fun _ ->
                Expect.equal (Cons (5, Base 6)) (sort (Cons (6, Base 5))) ""
            testCase "sort myList second" <| fun _ ->
                Expect.equal (Cons (5, Cons (6, Base 13))) (sort (Cons (13, Cons (6, Base 5)))) ""
        ]

[<Tests>]
let MyStringTests =
    testList "MyStringTests"
        [
            testCase "transform system string to MyString" <| fun _ ->
                Expect.equal (Cons ('R', Base 'e')) (toMyString "Re") ""
            testCase "transform system string to MyString second" <| fun _ ->
                Expect.equal (Cons ('T', Cons (' ', Base 'E'))) (toMyString "T E") ""

            testCase "concatenate myStrings" <| fun _ ->
                Expect.equal (Cons ('R', Base 'e')) (concatenate (Base 'R') (Base 'e')) ""
            testCase "concatenate myStrings second" <| fun _ ->
                Expect.equal (Cons ('T', Cons (' ', Base 'E'))) (concatenate (Cons('T', Base ' ')) (Base 'E')) ""
        ]

[<Tests>]
let MyTreeTests =
    testList "MyTreeTests"
        [
            testCase "average myTree" <| fun _ ->
                Expect.equal (average (Node ((14), Cons ((Leaf (16)), Base (Leaf (18)))))) 16 "48 / 3 = 16"
            testCase "average myTree second" <| fun _ ->
                Expect.equal (average (Node ((10), Cons ((Leaf (12)), Base (Leaf (11)))))) 11 "33 / 3 = 11"

            testCase "maxElem myTree" <| fun _ ->
                Expect.equal (max (Node ((189), Cons ((Leaf (228)), Base (Leaf (189)))))) 228 ""
            testCase "maxElem myTree second" <| fun _ ->
                Expect.equal (max (Node ((-15), Cons ((Leaf (-1)), Base (Leaf (-10)))))) -1 ""

            testCase "Count nodes and leaves myTree" <| fun _ ->
                Expect.equal (countNodesAndLeaves (Node ((144), Cons ((Leaf (228)), Base (Leaf (11)))))) 3 ""
        ]

