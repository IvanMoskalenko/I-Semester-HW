namespace HW5
module Main =
    [<EntryPoint>]
    let main (argv: string array) =
        let configNoGC = new hw5.PerfConfig (10000, 15000, 1500 * 1000, false)
        let configGC = new hw5.PerfConfig (10000, 15000, 1500 * 1000, true)
        let configNoGCForBubble = new hw5.PerfConfig (100, 50, 2000, false)
        let configGCForBubble = new hw5.PerfConfig (100, 50, 2000, true)
        let configNoGCForBubbleArray = new hw5.PerfConfig (1000, 1000, 150 * 1000, false)
        let configGCForBubbleArray = new hw5.PerfConfig (1000, 1000, 150 * 1000, true)

        (*hw5.perfTestsForLists configNoGC List.sort 25 "ListSort_debug_noGC.csv"
        hw5.perfTestsForLists configNoGC sorts.listQuickSort 25 "ListQuickSort_debug_noGC.csv"
        hw5.perfTestsForArrays configNoGC Array.sort 25 "ArraySort_debug_noGC.csv"
        hw5.perfTestsForArrays configNoGC sorts.arrayQuickSortForExperiments 25 "ArrayQuickSortForExp_debug_noGC.csv"
        hw5.perfTestsForArrays configNoGC sorts.arrayQuickSort 25 "ArrayQuickSort_debug_noGC.csv"

        hw5.perfTestsForLists configGC List.sort 25 "ListSort_debug_GC.csv"
        hw5.perfTestsForLists configGC sorts.listQuickSort 25 "ListQuickSort_debug_GC.csv"
        hw5.perfTestsForArrays configGC Array.sort 25 "ArraySort_debug_GC.csv"
        hw5.perfTestsForArrays configGC sorts.arrayQuickSortForExperiments 25 "ArrayQuickSortForExp_debug_GC.csv"
        hw5.perfTestsForArrays configGC sorts.arrayQuickSort 25 "ArrayQuickSort_debug_GC.csv"*)

        hw5.perfTestsForLists configNoGCForBubble sorts.listQuickSort 25 "ListQuickSortForBubble_debug_noGC.csv"
        hw5.perfTestsForLists configGCForBubble sorts.listQuickSort 25 "ListQuickSortForBubble_debug_GC.csv"
        hw5.perfTestsForLists configNoGCForBubble sorts.listBubbleSort 25 "ListBubbleSort_debug_noGC.csv"
        hw5.perfTestsForLists configGCForBubble sorts.listBubbleSort 25 "ListBubbleSort_debug_GC.csv"

        hw5.perfTestsForArrays configGCForBubbleArray sorts.arrayQuickSort 25 "ArrayQuickSortForBubble_debug_GC.csv"
        hw5.perfTestsForArrays configNoGCForBubbleArray sorts.arrayQuickSort 25 "ArrayQuickSortForBubble_debug_noGC.csv"
        hw5.perfTestsForArrays configGCForBubbleArray sorts.arrayBubbleSort 25 "ArrayBubbleSort_debug_GC.csv"
        hw5.perfTestsForArrays configNoGCForBubbleArray sorts.arrayBubbleSort 25 "ArrayBubbleSort_debug_noGC.csv"
        0


