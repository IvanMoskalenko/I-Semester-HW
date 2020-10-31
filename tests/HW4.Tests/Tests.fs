module Tests

open Expecto
open HW4

[<Tests>]
let fourthHomeworkTests =
    testList "fourthHW"
        [
            testProperty "First task is like system sort"
            <| fun (arr: array<int>) -> Expect.sequenceEqual (Array.sort arr) (hw4.arrayBubbleSort arr) "My sort should be equals to system sort."
            testProperty "Second task is like system sort"
            <| fun (lst: List<int>) -> Expect.sequenceEqual (List.sort lst) (hw4.listBubbleSort lst) "My sort should be equals to system sort."
            testProperty "Third task is like system sort"
            <| fun (lst: List<int>) -> Expect.sequenceEqual (List.sort lst) (hw4.listQuickSort lst) "My sort should be equals to system sort."
            testProperty "Fourth task is like system sort"
            <| fun (arr: array<int>) -> Expect.sequenceEqual (Array.sort arr) (hw4.arrayQuickSort arr) "My sort should be equals to system sort."

            testProperty "First task = Fourth task"
            <| fun (arr: array<int>) -> Expect.sequenceEqual (hw4.arrayBubbleSort arr) (hw4.arrayQuickSort arr) "First task must be equal to fourth task"
            testProperty "Second task = Third task"
            <| fun (lst: List<int>) -> Expect.sequenceEqual (hw4.listBubbleSort lst) (hw4.listQuickSort lst) "Second task must be equal to third task"

            testProperty "Pack + Unpack = Original (32-bit)"
            <| fun x y -> Expect.equal ([|x; y|]) (hw4.fifthTask x y) "Result must be equal to original"
            testProperty "Pack + Unpack = Original (16-bit)"
            <| fun x y z a -> Expect.equal ([|x; y; z; a|]) (hw4.sixthTask x y z a) "Result must be equal to original"
        ]
