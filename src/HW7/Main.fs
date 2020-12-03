module Main
open System
open myList
open myString

[<EntryPoint>]
let main (argv: string array) =
    let x = "Test тест"
    let res = transformSystemStringToMyString x
    //let lst = [1; 4; 7; 14; -20; 144; -1; 12; 34; 1; 0; -1; 145; 2]
    //let ourLst = transformSystemListToMyList lst
    //let res = sortMyList ourLst
    printfn "%A" res
    0

