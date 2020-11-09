import matplotlib.pyplot as plt
import matplotlib.patches as mpatches
import pandas as pd

labels = []

def add_label(violin, label):
    color = violin["bodies"][0].get_facecolor().flatten()
    labels.append((mpatches.Patch(color=color), label))


def draw(file, name, axs, wLbl):
    df = pd.read_csv(file)
    data = [[d[1][0], d[1][1:]] for d in df.iterrows()]

    plt.ioff()

    r = [d[1] for d in data]
    lbl = [d[0] / 1000 for d in data]
    lbl2 = [d[0] for d in data]
    lbl3 = [d[0] / 10 for d in data]
    if wLbl == "wLbl1":
        add_label(axs.violinplot(r,
                                 positions=lbl,
                                 widths=35,
                                 showmeans=False,
                                 showmedians=True),
                  name)
    elif wLbl == "wLbl2":
        add_label(axs.violinplot(r,
                                 positions=lbl2,
                                 widths=100,
                                 showmeans=False,
                                 showmedians=True),
                  name)
    else:
        add_label(axs.violinplot(r,
                                 positions=lbl3,
                                 widths=150,
                                 showmeans=False,
                                 showmedians=True),
                  name)


def drawFiles(filesWithLegend, out, wLbl):
    fig = plt.figure()
    axs = plt.axes()

    axs.yaxis.grid(True)
    if wLbl == "wLbl1":
        axs.set_xlabel('Длина входного списка (* 1000)')
    elif wLbl == "wLbl2":
        axs.set_xlabel('Длина входного списка')
    else:
        axs.set_xlabel('Длина входного списка (* 10)')
    axs.set_ylabel('Время сортировки (миллисекунды)')

    for (file, legend) in filesWithLegend:
        draw(file, legend, axs, wLbl)

    plt.legend(*zip(*labels), loc=2)

    plt.savefig(out)
    plt.close(fig)


drawFiles([('ListSort_debug_noGC.csv', "List.sort, no GC, debug"),
           ('ListSort_debug_GC.csv', "List.sort, GC, debug")
           ],
          "ListSortGCvsNoGC.pdf", "wLbl1")
labels = []
drawFiles([('ListQuickSort_debug_noGC.csv', "List qSort, no GC, debug"),
           ('ListQuickSort_debug_GC.csv', "List qSort, GC, debug")
           ],
          "ListQSortGCvsNoGC.pdf", "wLbl1")
labels = []
drawFiles([('ListBubbleSort_debug_noGC.csv', "List bSort, no GC, debug"),
           ('ListBubbleSort_debug_GC.csv', "List bSort, GC, debug")
           ],
          "ListBubbleSortGCvsNoGC.pdf", "wLbl2")
labels = []

drawFiles([('ArraySort_debug_noGC.csv', "Array.sort, no GC, debug"),
           ('ArraySort_debug_GC.csv', "Array.sort, GC, debug")
           ],
          "ArraySortGCvsNoGC.pdf", "wLbl1")
labels = []
drawFiles([('ArrayQuickSort_debug_noGC.csv', "Array qSort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "Array qSort, GC, debug")
           ],
          "ArrayQSortGCvsNoGC.pdf", "wLbl1")
labels = []
drawFiles([('ArrayQuickSortForExp_debug_noGC.csv', "Not optimized Array qSort, no GC, debug"),
           ('ArrayQuickSortForExp_debug_GC.csv', "Not optimized Array qSort, GC, debug")
           ],
          "ArrayQSortForExpGCvsNoGC.pdf", "wLbl1")
labels = []
drawFiles([('ArrayBubbleSort_debug_noGC.csv', "Array bSort, no GC, debug"),
           ('ArrayBubbleSort_debug_GC.csv', "Array bSort, GC, debug")
           ],
          "ArrayBubbleSortGCvsNoGC.pdf", "wLbl3")
labels = []
############################################################################
drawFiles([('ListSortForBubble_debug_GC.csv', "List.sort, GC, debug"),
           ('ListQuickSortForBubble_debug_GC.csv', "List qSort, GC, debug"),
           ('ListBubbleSort_debug_GC.csv', "List bSort, GC, debug")
           ],
          "ListSortsComparison.pdf", "wLbl2")
labels = []
drawFiles([('ArraySortForBubble_debug_GC.csv', "Array.sort, GC, debug"),
           ('ArrayQuickSortForBubble_debug_GC.csv', "Array qSort, GC, debug"),
           ('ArrayBubbleSort_debug_GC.csv', "Array bSort, GC, debug")
           ],
          "ArraySortsComparison.pdf", "wLbl3")
labels = []

drawFiles([('ArrayQuickSort_debug_GC.csv', "Array qSort, GC, debug"),
           ('ArrayQuickSortForExp_debug_GC.csv', "Not optimized Array qSort, GC, debug")
           ],
          "ArrayQuickSortVSNotOptimizedQSort.pdf", "wLbl1")
labels = []

drawFiles([('ListSort_debug_GC.csv', "List.sort, GC, debug"),
           ('ListQuickSort_debug_GC.csv', "List qSort, GC, debug"),
           ],
          "ListSortsComparisonSystemVSQSort.pdf", "wLbl1")
labels = []
drawFiles([('ArraySort_debug_GC.csv', "Array.sort, GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "Array qSort, GC, debug"),
           ],
          "ArraySortsComparisonSystemVSQSort.pdf", "wLbl1")
labels = []
############################################################################
drawFiles([('ListSort_debug_GC.csv', "List.sort, GC, debug"),
           ('ListSort_release_GC.csv', "List.sort, GC, release")
           ],
          "ListSortDebugVSRelease.pdf", "wLbl1")
labels = []
drawFiles([('ListQuickSort_debug_GC.csv', "List qSort, GC, debug"),
           ('ListQuickSort_release_GC.csv', "List qSort, GC, release")
           ],
          "ListQSortDebugVSRelease.pdf", "wLbl1")
labels = []
drawFiles([('ListBubbleSort_debug_GC.csv', "List bSort, GC, debug"),
           ('ListBubbleSort_release_GC.csv', "List bSort, GC, release")
           ],
          "ListBubbleDebugVSRelease.pdf", "wLbl2")
labels = []

drawFiles([('ArraySort_debug_GC.csv', "Array.sort, GC, debug"),
           ('ArraySort_release_GC.csv', "Array.sort, GC, release")
           ],
          "ArraySortDebugVSRelease.pdf", "wLbl1")
labels = []
drawFiles([('ArrayQuickSort_debug_GC.csv', "Array qSort, GC, debug"),
           ('ArrayQuickSort_release_GC.csv', "Array qSort, GC, release")
           ],
          "ArrayQSortDebugVSRelease.pdf", "wLbl1")
labels = []
drawFiles([('ArrayQuickSortForExp_debug_GC.csv', "Not optimized Array qSort, GC, debug"),
           ('ArrayQuickSortForExp_release_GC.csv', "Not optimized Array qSort, GC, release")
           ],
          "ArrayQSortForExpDebugVSRelease.pdf", "wLbl1")
labels = []
drawFiles([('ArrayBubbleSort_debug_GC.csv', "Array bSort, GC, debug"),
           ('ArrayBubbleSort_release_GC.csv', "Array bSort, GC, release")
           ],
          "ArrayBubbleSortDebugVSRelease.pdf", "wLbl3")
labels = []


