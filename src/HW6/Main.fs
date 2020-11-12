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

        let measurements config sortFunc path generate =
            hw5.perfTests config sortFunc 25 path generate
        (*
        measurements configNoGC List.sort "ListSort_debug_noGC.csv" hw5.genRandomList
        measurements configGC List.sort "ListSort_debug_GC.csv" hw5.genRandomList
        measurements configNoGC hw4.listQuickSort "ListQuickSort_debug_noGC.csv" hw5.genRandomList
        measurements configGC hw4.listQuickSort "ListQuickSort_debug_GC.csv" hw5.genRandomList

        measurements configNoGC Array.sort "ArraySort_debug_noGC.csv" hw5.genRandomArray
        measurements configGC Array.sort "ArraySort_debug_GC.csv" hw5.genRandomArray
        measurements configNoGC hw4.arrayQuickSortForExperiments "ArrayQuickSortForExp_debug_noGC.csv" hw5.genRandomArray
        measurements configGC hw4.arrayQuickSortForExperiments "ArrayQuickSortForExp_debug_GC.csv" hw5.genRandomArray
        measurements configNoGC hw4.arrayQuickSort "ArrayQuickSort_debug_noGC.csv" hw5.genRandomArray
        measurements configGC hw4.arrayQuickSort "ArrayQuickSort_debug_GC.csv" hw5.genRandomArray

        measurements configGCForBubble hw4.listQuickSort "ListQuickSortForBubble_debug_GC.csv" hw5.genRandomList
        measurements configNoGCForBubble hw4.listBubbleSort "ListBubbleSort_debug_noGC.csv" hw5.genRandomList
        measurements configGCForBubble hw4.listBubbleSort "ListBubbleSort_debug_GC.csv" hw5.genRandomList
        measurements configGCForBubble List.sort "ListSortForBubble_debug_GC.csv" hw5.genRandomList

        measurements configGCForBubbleArray hw4.arrayQuickSort "ArrayQuickSortForBubble_debug_GC.csv" hw5.genRandomArray
        measurements configGCForBubbleArray hw4.arrayBubbleSort "ArrayBubbleSort_debug_GC.csv" hw5.genRandomArray
        measurements configNoGCForBubbleArray hw4.arrayBubbleSort "ArrayBubbleSort_debug_noGC.csv" hw5.genRandomArray
        measurements configGCForBubbleArray Array.sort "ArraySortForBubble_debug_GC.csv" hw5.genRandomArray
        *)

        measurements configGC List.sort "ListSort_release_GC.csv" hw5.genRandomList
        measurements configGC hw4.listQuickSort "ListQuickSort_release_GC.csv" hw5.genRandomList
        measurements configGCForBubble hw4.listBubbleSort "ListBubbleSort_release_GC.csv" hw5.genRandomList

        measurements configGC Array.sort "ArraySort_release_GC.csv" hw5.genRandomArray
        measurements configGC hw4.arrayQuickSortForExperiments "ArrayQuickSortForExp_release_GC.csv" hw5.genRandomArray
        measurements configGC hw4.arrayQuickSort "ArrayQuickSort_release_GC.csv" hw5.genRandomArray
        measurements configGCForBubbleArray hw4.arrayBubbleSort "ArrayBubbleSort_release_GC.csv" hw5.genRandomArray

        0


