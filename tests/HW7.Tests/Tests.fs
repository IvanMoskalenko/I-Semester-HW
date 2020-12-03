module Tests
open Expecto
open myString
open myList
open myTree

[<Tests>]
let MyListTests =
    testList "MyListTests"
        [
            testCase "Length" <| fun _ ->
                Expect.equal 2 (myListLength (Cons (5, Base 4))) ""
            testCase "Length second" <| fun _ ->
                Expect.equal 3 (myListLength (Cons (12, Cons (5, Base 4)))) ""

            testCase "map" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (map ((+) 1) (Cons (5, Base 4))) ""
            testCase "map second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (map ((+) 1) (Cons (12, Cons (5, Base 4)))) ""

            testCase "transform system list to MyList" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (transformSystemListToMyList [6; 5]) ""
            testCase "transform system list to MyList second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (transformSystemListToMyList [13; 6; 5]) ""

            testCase "concatenate myLists" <| fun _ ->
                Expect.equal (Cons (6, Base 5)) (concatenateMyLists (Base 6) (Base 5)) ""
            testCase "concatenate myLists second" <| fun _ ->
                Expect.equal (Cons (13, Cons (6, Base 5))) (concatenateMyLists (Cons(13, Base 6)) (Base 5)) ""

            testCase "sort myList" <| fun _ ->
                Expect.equal (Cons (5, Base 6)) (sortMyList (Cons (6, Base 5))) ""
            testCase "sort myList second" <| fun _ ->
                Expect.equal (Cons (5, Cons (6, Base 13))) (sortMyList (Cons (13, Cons (6, Base 5)))) ""
        ]

[<Tests>]
let MyStringTests =
    testList "MyStringTests"
        [
            testCase "transform system string to MyString" <| fun _ ->
                Expect.equal (Cons ('R', Base 'e')) (transformSystemStringToMyString "Re") ""
            testCase "transform system string to MyString second" <| fun _ ->
                Expect.equal (Cons ('T', Cons (' ', Base 'E'))) (transformSystemStringToMyString "T E") ""

            testCase "concatenate myStrings" <| fun _ ->
                Expect.equal (Cons ('R', Base 'e')) (concatenateMyString (Base 'R') (Base 'e')) ""
            testCase "concatenate myStrings second" <| fun _ ->
                Expect.equal (Cons ('T', Cons (' ', Base 'E'))) (concatenateMyString (Cons('T', Base ' ')) (Base 'E')) ""
        ]

[<Tests>]
let MyTreeTests =
    testList "MyTreeTests"
        [
            testCase "average myTree" <| fun _ ->
                Expect.equal (averageMyTree (Node ((14), Cons ((Leaf (16)), Base (Leaf (18)))))) 16 "48 / 3 = 16"
            testCase "average myTree second" <| fun _ ->
                Expect.equal (averageMyTree (Node ((10), Cons ((Leaf (12)), Base (Leaf (11)))))) 11 "33 / 3 = 11"

            testCase "maxElem myTree" <| fun _ ->
                Expect.equal (maxElemMyTree (Node ((145), Cons ((Leaf (228)), Base (Leaf (11)))))) 228 ""
            testCase "maxElem myTree second" <| fun _ ->
                Expect.equal (maxElemMyTree (Node ((-15), Cons ((Leaf (-1)), Base (Leaf (-10)))))) -1 ""

            testCase "Count nodes and leaves myTree" <| fun _ ->
                Expect.equal (countNodesAndLeaves (Node ((145), Cons ((Leaf (228)), Base (Leaf (11)))))) 3 ""
        ]

