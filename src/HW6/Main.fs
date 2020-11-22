namespace HW6
module Main =
    open System

    [<EntryPoint>]
    let main (argv: string array) =
        printfn "Enter paths of two matrices: "
        let inputPath = Console.ReadLine()
        let inputPath2 = Console.ReadLine()
        printfn "Enter output path: "
        let outputPath = Console.ReadLine()
        hw6.writeMatrix inputPath inputPath2 outputPath
        0

