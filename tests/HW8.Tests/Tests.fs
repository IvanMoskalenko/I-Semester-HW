module Tests
open System
open Expecto
open HW2_3
open QTSM
open hw3

let generateSparseMatrix rows cols =
    let x = Array2D.init rows cols (fun _ _ -> Random().Next(0, 2))
    SparseMatrix (rows, cols,
                            [for i in 0..rows - 1 do
                                 for j in 0..cols - 1 do
                                     if x.[i, j] = 1 then (i, j, Random().Next(1, 100))])    
let genArrayBySparseMatrix (matrix: SparseMatrix<int>) =
    let output = Array2D.zeroCreate matrix.numOfRows matrix.numOfCols
    for x in matrix.notEmptyCells do
        output.[first x, second x] <- third x
    output

let standartSum (x: int[,]) (y: int[,]) =
    let a = Array2D.copy x
    if Array2D.length1 x <> Array2D.length1 y || Array2D.length2 x <> Array2D.length2 y then failwith "Dimensions of matrices should be equal"
    else
        for i in 0 .. Array2D.length1 x - 1 do
            for j in 0 .. Array2D.length2 x - 1 do
                a.[i, j] <- a.[i, j] + y.[i, j]
    a

let standartMultiplyByScalar scalar (x: int[,]) =
    let y = Array2D.copy x
    for i in 0 .. Array2D.length1 x - 1 do
        for j in 0 .. Array2D.length2 x - 1 do
            y.[i, j] <- scalar * y.[i, j]
    y
let standartTensorMultiply (x: int[,]) (y: int[,]) =
    let mutable a, b = 0, 0
    let output = Array2D.create (Array2D.length1 x * Array2D.length2 y) (Array2D.length1 x * Array2D.length2 y) 1
    for i in 0 .. Array2D.length1 x - 1 do
        for j in 0 .. Array2D.length2 x - 1 do
            a <- i * (Array2D.length1 y) 
            b <- j * (Array2D.length2 y)
            Array2D.blit (standartMultiplyByScalar x.[i,j] y) 0 0 output a b (Array2D.length1 x) (Array2D.length2 y)
    output
    
let arrayToSparseMatrix (x: int[,]) =
    let y = Array.create (Array2D.length1 x * Array2D.length2 x) (0, 0, 0)
    let mutable z = 0
    for i in 0 .. Array2D.length1 x - 1 do
        for j in 0 .. Array2D.length2 x - 1 do
            y.[z] <- i, j, x.[i,j]
            z <- z + 1
    SparseMatrix(Array2D.length1 x, Array2D.length2 x, y |> Array.filter (fun x -> (x |> third) <> 0) |> Array.toList)

[<Tests>]
let tests =
    testList "Tests for QuadTree" [    
        testProperty "Sum" <| fun _ ->
                    let dim = Random().Next(0, 32)
                    let sm1 = generateSparseMatrix dim dim
                    let sm2 = generateSparseMatrix dim dim
                    let m1 = genArrayBySparseMatrix sm1
                    let m2 = genArrayBySparseMatrix sm2
                    let sum1 = standartSum m1 m2 |> arrayToSparseMatrix |> toTree
                    let sum2 = sum (sm1 |> toTree) (sm2 |> toTree)
                    Expect.equal sum1 sum2 ""
                    
        testProperty "Mul" <| fun _ ->
                    let dim = Random().Next(0, 32)
                    let sm1 = generateSparseMatrix dim dim
                    let sm2 = generateSparseMatrix dim dim
                    let m1 = genArrayBySparseMatrix sm1
                    let m2 = genArrayBySparseMatrix sm2
                    let mul1 = matrixMultiply m1 m2 |> arrayToSparseMatrix |> toTree
                    let mul2 = multiply (sm1 |> toTree) (sm2 |> toTree)
                    Expect.equal mul1 mul2 ""
                    
        testProperty "Tensor mul" <| fun _ ->
                    let dim = Random().Next(0, 32) |> toPowerOf2
                    let sm1 = generateSparseMatrix dim dim
                    let sm2 = generateSparseMatrix dim dim
                    let m1 = genArrayBySparseMatrix sm1
                    let m2 = genArrayBySparseMatrix sm2
                    let tmul1 = standartTensorMultiply m1 m2 |> arrayToSparseMatrix |> toTree
                    let tmul2 = tensorMultiply (sm1 |> toTree) (sm2 |> toTree)
                    Expect.equal tmul1 tmul2 ""]