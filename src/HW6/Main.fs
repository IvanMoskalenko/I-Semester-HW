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
        let matrix1 = hw6.readMatrix inputPath
        let matrix2 = hw6.readMatrix inputPath2
        System.IO.File.WriteAllLines ((outputPath), hw6.ourMatrixToArrayOfStrings (hw6.multiplyMatrix matrix1 matrix2))
        0

