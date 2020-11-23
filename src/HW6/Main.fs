module Main =
    open System
    open hw6

    [<EntryPoint>]
    let main (argv: string array) =
        printfn "Enter paths of two matrices: "
        let inputPath = Console.ReadLine()
        let inputPath2 = Console.ReadLine()
        printfn "Enter output path: "
        let outputPath = Console.ReadLine()
        let result = multiplyInputMatrices inputPath inputPath2
        writeMatrix result outputPath
        0

