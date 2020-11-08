namespace HW5
open HW4

module Main =
    [<EntryPoint>]
    let main (argv: string array) =
        let configNoGC = new hw5.PerfConfig (10000, 15000, 1500 * 1000, false)
        let configGC = new hw5.PerfConfig (10000, 15000, 1500 * 1000, true)
        let configNoGCForBubble = new hw5.PerfConfig (100, 50, 3000, false)
        let configGCForBubble = new hw5.PerfConfig (100, 50, 3000, true)
        let configNoGCForBubbleArray = new hw5.PerfConfig (1000, 500, 50 * 1000, false)
        let configGCForBubbleArray = new hw5.PerfConfig (1000, 500, 50 * 1000, true)

        hw5.perfTests configNoGC List.sort 25 "ListSort_debug_noGC.csv" hw5.genRandomList
        hw5.perfTests configGC List.sort 25 "ListSort_debug_GC.csv" hw5.genRandomList
        hw5.perfTests configNoGC hw4.listQuickSort 25 "ListQuickSort_debug_noGC.csv" hw5.genRandomList
        hw5.perfTests configGC hw4.listQuickSort 25 "ListQuickSort_debug_GC.csv" hw5.genRandomList

        hw5.perfTests configNoGC Array.sort 25 "ArraySort_debug_noGC.csv" hw5.genRandomArray
        hw5.perfTests configGC Array.sort 25 "ArraySort_debug_GC.csv" hw5.genRandomArray
        hw5.perfTests configNoGC hw4.arrayQuickSortForExperiments 25 "ArrayQuickSortForExp_debug_noGC.csv" hw5.genRandomArray
        hw5.perfTests configGC hw4.arrayQuickSortForExperiments 25 "ArrayQuickSortForExp_debug_GC.csv" hw5.genRandomArray
        hw5.perfTests configNoGC hw4.arrayQuickSort 25 "ArrayQuickSort_debug_noGC.csv" hw5.genRandomArray
        hw5.perfTests configGC hw4.arrayQuickSort 25 "ArrayQuickSort_debug_GC.csv" hw5.genRandomArray

        hw5.perfTests configGCForBubble hw4.listQuickSort 25 "ListQuickSortForBubble_debug_GC.csv" hw5.genRandomList
        hw5.perfTests configNoGCForBubble hw4.listBubbleSort 25 "ListBubbleSort_debug_noGC.csv" hw5.genRandomList
        hw5.perfTests configGCForBubble hw4.listBubbleSort 25 "ListBubbleSort_debug_GC.csv" hw5.genRandomList
        hw5.perfTests configGCForBubble List.sort 25 "ListSortForBubble_debug_GC.csv" hw5.genRandomList

        hw5.perfTests configGCForBubbleArray hw4.arrayQuickSort 25 "ArrayQuickSortForBubble_debug_GC.csv" hw5.genRandomArray
        hw5.perfTests configGCForBubbleArray hw4.arrayBubbleSort 25 "ArrayBubbleSort_debug_GC.csv" hw5.genRandomArray
        hw5.perfTests configNoGCForBubbleArray hw4.arrayBubbleSort 25 "ArrayBubbleSort_debug_noGC.csv" hw5.genRandomArray
        hw5.perfTests configGCForBubbleArray Array.sort 25 "ArraySort_debug_GC.csv" hw5.genRandomArray

        (*
        hw5.perfTestsForLists configGC List.sort 25 "ListSort_release_GC.csv"
        hw5.perfTestsForLists configGC hw4.listQuickSort 25 "ListQuickSort_release_GC.csv"

        hw5.perfTestsForArrays configGC Array.sort 25 "ArraySort_release_GC.csv"
        hw5.perfTestsForArrays configGC hw4.arrayQuickSortForExperiments 25 "ArrayQuickSortForExp_release_GC.csv"
        hw5.perfTestsForArrays configGC hw4.arrayQuickSort 25 "ArrayQuickSort_release_GC.csv"

        hw5.perfTestsForLists configGCForBubble hw4.listQuickSort 25 "ListQuickSortForBubble_release_GC.csv"
        hw5.perfTestsForLists configGCForBubble hw4.listBubbleSort 25 "ListBubbleSort_release_GC.csv"
        hw5.perfTestsForLists configGCForBubble List.sort 25 "ListSortForBubble_release_GC.csv"

        hw5.perfTestsForArrays configGCForBubbleArray hw4.arrayQuickSort 25 "ArrayQuickSortForBubble_release_GC.csv"
        hw5.perfTestsForArrays configGCForBubbleArray hw4.arrayBubbleSort 25 "ArrayBubbleSort_release_GC.csv"
        hw5.perfTestsForArrays configGCForBubbleArray Array.sort 25 "ArraySort_release_GC.csv"
        *)

        0


