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
    if wLbl == "wLbl1":
        add_label(axs.violinplot(r,
                                 positions=lbl,
                                 widths=50,
                                 showmeans=False,
                                 showmedians=True),
                  name)
    else:
        add_label(axs.violinplot(r,
                                 positions=lbl2,
                                 widths=50,
                                 showmeans=False,
                                 showmedians=True),
                  name)


def drawFiles(filesWithLegend, out, wLbl):
    fig = plt.figure()
    axs = plt.axes()

    axs.yaxis.grid(True)
    if wLbl == "wLbl1":
        axs.set_xlabel('Длина входного списка (* 1000)')
    else:
        axs.set_xlabel('Длина входного списка')
    axs.set_ylabel('Время сортировки (миллисекунды)')

    for (file, legend) in filesWithLegend:
        draw(file, legend, axs, wLbl)

    plt.legend(*zip(*labels), loc=2)

    plt.savefig(out)
    plt.close(fig)


drawFiles([('ListQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ListSort_debug_noGC.csv', "List.sort, no GC, debug"),
           ('ListQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ListSort_debug_GC.csv', "List.sort, GC, debug")
           ],
          "SystemListSortVSCustomQSort.pdf", "wLbl1")
labels = []
drawFiles([('ListQuickSortForBubble_debug_noGC.csv', "qSort, no GC, debug"),
           ('ListBubbleSort_debug_noGC.csv', "bSort, no GC, debug"),
           ('ListQuickSortForBubble_debug_GC.csv', "qSort, GC, debug"),
           ('ListBubbleSort_debug_GC.csv', "bSort, GC, debug")
           ],
          "CustomListBubbleSortVSCustomQSort.pdf", "wLbl2")
labels = []
drawFiles([('ArrayQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArraySort_debug_noGC.csv', "Array.sort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ArraySort_debug_GC.csv', "Array.sort, GC, debug")
           ],
          "SystemArraySortVSCustomQSort.pdf", "wLbl1")
labels = []
drawFiles([('ArrayQuickSortForBubble_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArrayBubbleSort_debug_noGC.csv', "bSort, no GC, debug"),
           ('ArrayQuickSortForBubble_debug_GC.csv', "qSort, GC, debug"),
           ('ArrayBubbleSort_debug_GC.csv', "bSort, GC, debug")
           ],
          "CustomArrayBubbleSortVSCustomQSort.pdf", "wLbl2")
labels = []
drawFiles([('ArrayQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArrayQuickSortForExp_debug_noGC.csv', "Not optimized qSort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ArrayQuickSortForExp_debug_GC.csv', "Not optimized qSort, GC, debug")
           ],
          "NotOptimizedArrayQuickSortVSOptimizedQSort.pdf", "wLbl1")


