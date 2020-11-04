namespace HW5
module Main =
    [<EntryPoint>]
    let main (argv: string array) =
        let config1 = new hw5.PerfConfig (10000, 10000, 2000 * 1000, false)
        hw5.perfTestsForLists config1 List.sort 20 "ListSort_debug_noGC.csv"
        hw5.perfTestsForLists config1 sorts.listQuickSort 20 "ListQuickSort_debug_noGC.csv"
        hw5.perfTestsForLists config1 sorts.listBubbleSort 20 "ListBubbleSort_debug_noGC.csv"
        hw5.perfTestsForArrays config1 Array.sort 20 "ArraySort_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayBubbleSort 20 "ArrayBubbleSort_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayQuickSortForExperiments 20 "ArrayQuickSortForExp_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayQuickSortForExperiments 20 "ArrayQuickSort_debug_noGC.csv"
        let config2 = new hw5.PerfConfig (100, 200, 1500, true)
        hw5.perfTestsForLists config2 List.sort 20 "ListSort_debug_GC.csv"
        hw5.perfTestsForLists config2 sorts.listQuickSort 20 "ListQuickSort_debug_GC.csv"
        hw5.perfTestsForLists config2 sorts.listBubbleSort 20 "ListBubbleSort_debug_GC.csv"
        hw5.perfTestsForArrays config2 Array.sort 20 "ArraySort_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayBubbleSort 20 "ArrayBubbleSort_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayQuickSortForExperiments 20 "ArrayQuickSortForExp_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayQuickSortForExperiments 20 "ArrayQuickSort_debug_GC.csv"
        0


