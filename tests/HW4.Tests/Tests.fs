module Tests

open Expecto
open HW4

[<Tests>]
let fourthHomeworkTests =
    testList "fourthHW"
        [
            testProperty "First task is like system sort"
            <| fun (arr: array<int>) -> Expect.sequenceEqual (Array.sort arr) (hw4.firstTask arr) "My sort should be equals to system sort."
            testProperty "Second task is like system sort"
            <| fun (lst: List<int>) -> Expect.sequenceEqual (List.sort lst) (hw4.secondTask lst) "My sort should be equals to system sort."
            testProperty "Third task is like system sort"
            <| fun (lst: List<int>) -> Expect.sequenceEqual (List.sort lst) (hw4.thirdTask lst) "My sort should be equals to system sort."
            testProperty "Fourth task is like system sort"
            <| fun (arr: array<int>) -> Expect.sequenceEqual (Array.sort arr) (hw4.fourthTask arr) "My sort should be equals to system sort."

            testProperty "First task = Fourth task" 
            <| fun (arr: array<int>) -> Expect.sequenceEqual (hw4.firstTask arr) (hw4.fourthTask arr) "First task must be equal to fourth task"
            testProperty "Second task = Third task" 
            <| fun (lst: List<int>) -> Expect.sequenceEqual (hw4.secondTask lst) (hw4.thirdTask lst) "Second task must be equal to third task"
        ]
