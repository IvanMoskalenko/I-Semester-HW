module Main
open Generator    

[<EntryPoint>]
    let main (argv: string array) =
        let bType =
            match argv.[5] with
                | "int" -> Int
                | "float" -> Float
                | "bool" -> Bool
                | _ -> AnotherType
        let x = generatorOptions
                    (argv.[0] |> int, argv.[1] |> int, argv.[2] |> int, argv.[3] |> float, argv.[4], bType)            
        generator x
        0    
  