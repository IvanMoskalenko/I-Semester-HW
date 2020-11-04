namespace HW5
module Main =
    [<EntryPoint>]
    let main (argv: string array) =
        let config1 = new hw5.PerfConfig (100, 200, 1500, false)
        hw5.perfTestsForLists config1 List.sort 1  "timingsSystemListSortOut5_debug_noGC.csv"
        hw5.perfTestsForLists config1 sorts.listQuickSort 1 "timingsCustomListQuickSortOut5_debug_noGC.csv"
        hw5.perfTestsForLists config1 sorts.listBubbleSort 1 "timingsCustomListBubbleSortOut5_debug_noGC.csv"
        hw5.perfTestsForArrays config1 Array.sort 1  "timingsSystemArraySortOut5_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayBubbleSort 1  "timingsCustomArrayBubbleSortOut5_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayQuickSortForExperiments 1  "timingsCustomArrayQuickSortForExperimentsOut5_debug_noGC.csv"
        hw5.perfTestsForArrays config1 sorts.arrayQuickSortForExperiments 1  "timingsCustomArrayQuickSortOut5_debug_noGC.csv"
        let config2 = new hw5.PerfConfig (100, 200, 1500, true)
        hw5.perfTestsForLists config2 List.sort 1  "timingsSystemListSortOut5_debug_GC.csv"
        hw5.perfTestsForLists config2 sorts.listQuickSort 1 "timingsCustomListQuickSortOut5_debug_GC.csv"
        hw5.perfTestsForLists config2 sorts.listBubbleSort 1 "timingsCustomListBubbleSortOut5_debug_GC.csv"
        hw5.perfTestsForArrays config2 Array.sort 1  "timingsSystemArraySortOut5_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayBubbleSort 1  "timingsCustomArrayBubbleSortOut5_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayQuickSortForExperiments 1  "timingsCustomArrayQuickSortForExperimentsOut5_debug_GC.csv"
        hw5.perfTestsForArrays config2 sorts.arrayQuickSortForExperiments 1  "timingsCustomArrayQuickSortOut5_debug_GC.csv"
        0


