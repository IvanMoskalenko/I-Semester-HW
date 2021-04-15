module Generator
open System

let printMatrix (x: string [,]) path =
    let y = x.[*, 1]
    let z = x.[1, *]
    let mutable text = ""
    for i = 0 to y.Length - 1 do
        for j = 0 to z.Length - 1 do
            text <- text + x.[i, j] + " "
        text <- text + "\n"
    System.IO.File.AppendAllText (path, text)
                
let generator rows cols amt sparsity path bType =  
    for i = 0 to amt - 1 do
        let output = Array2D.zeroCreate rows cols
        for j = 0 to rows - 1 do
            for k = 0 to cols - 1 do
                let x = Random()
                let y = (x.Next(100) |> float) / 100.0
                if bType = "int" then
                    if y > sparsity   
                    then output.[j, k] <- string (x.Next())
                    else output.[j, k] <- "0"
                elif bType = "float" then
                    if y > sparsity   
                    then output.[j, k] <- string ((x.Next() |> float) / 10.0) 
                    else output.[j, k] <- "0"
                elif bType = "bool" then
                    if y > sparsity  
                    then output.[j, k] <- "1" 
                    else output.[j, k] <- "0"
                else failwith "Your type is unsupported"
        printMatrix output (path + "/Matrix" + string i + ".txt")
        
let first (x, _, _, _, _, _) = x
let second (_, x, _, _, _, _) = x
let third (_, _, x, _, _, _) = x
let fourth (_, _, _, x, _, _) = x
let fifth (_, _, _, _, x, _) = x
let sixth (_, _, _, _, _, x) = x
