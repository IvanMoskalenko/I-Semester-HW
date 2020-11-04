import matplotlib.pyplot as plt
import matplotlib.patches as mpatches
import pandas as pd

labels = []


def add_label(violin, label):
    color = violin["bodies"][0].get_facecolor().flatten()
    labels.append((mpatches.Patch(color=color), label))


def draw(file, name, axs):
    df = pd.read_csv(file)
    data = [[d[1][0], d[1][1:]] for d in df.iterrows()]  # [0::5]

    plt.ioff()

    r = [d[1] for d in data]
    lbl = [d[0] / 1000 for d in data]

    add_label(axs.violinplot(r,
                             positions=lbl,
                             widths=50,
                             showmeans=False,
                             showmedians=True),
              name)


def drawFiles(filesWithLegend, out):
    fig = plt.figure()
    axs = plt.axes()

    axs.yaxis.grid(True)
    axs.set_xlabel('Длина входного списка (* 1000)')
    axs.set_ylabel('Время сортировки (миллисекунды)')

    for (file, legend) in filesWithLegend:
        draw(file, legend, axs)

    plt.legend(*zip(*labels), loc=2)

    plt.savefig(out)
    plt.close(fig)


drawFiles([('ListQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ListSort_debug_noGC.csv', "List.sort, no GC, debug"),
           ('ListQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ListSort_debug_GC.csv', "List.sort, GC, debug"),
           ('ListQuickSort_release_noGC.csv', "qSort, no GC, release"),
           ('ListSort_release_noGC.csv', "List.sort, no GC, release"),
           ('ListQuickSort_release_GC.csv', "qSort, GC, release"),
           ('ListSort_release_GC.csv', "List.sort, GC, release")
           ],
          "SystemListSortVSCustomQSort.pdf")

drawFiles([('ListQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ListBubbleSort_debug_noGC.csv', "bSort, no GC, debug"),
           ('ListQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ListBubbleSort_debug_GC.csv', "bSort, GC, debug"),
           ('ListQuickSort_release_noGC.csv', "qSort, no GC, release"),
           ('ListBubbleSort_release_noGC.csv', "bSort, no GC, release"),
           ('ListQuickSort_release_GC.csv', "qSort, GC, release"),
           ('ListBubbleSort_release_GC.csv', "bSort, GC, release")
           ],
          "CustomListBubbleSortVSCustomQSort.pdf")

drawFiles([('ArrayQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArraySort_debug_noGC.csv', "Array.sort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ArraySort_debug_GC.csv', "Array.sort, GC, debug"),
           ('ArrayQuickSort_release_noGC.csv', "qSort, no GC, release"),
           ('ArraySort_release_noGC.csv', "Array.sort, no GC, release"),
           ('ArrayQuickSort_release_GC.csv', "qSort, GC, release"),
           ('ArraySort_release_GC.csv', "Array.sort, GC, release")
           ],
          "SystemArraySortVSCustomQSort.pdf")

drawFiles([('ArrayQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArrayBubbleSort_debug_noGC.csv', "bSort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ArrayBubbleSort_debug_GC.csv', "bSort, GC, debug"),
           ('ArrayQuickSort_release_noGC.csv', "qSort, no GC, release"),
           ('ArrayBubbleSort_release_noGC.csv', "bSort, no GC, release"),
           ('ArrayQuickSort_release_GC.csv', "qSort, GC, release"),
           ('ArrayBubbleSort_release_GC.csv', "bSort, GC, release")
           ],
          "CustomArrayBubbleSortVSCustomQSort.pdf")

drawFiles([('ArrayQuickSort_debug_noGC.csv', "qSort, no GC, debug"),
           ('ArrayQuickSortForExp_debug_noGC.csv', "Not optimized qSort, no GC, debug"),
           ('ArrayQuickSort_debug_GC.csv', "qSort, GC, debug"),
           ('ArrayQuickSortForExp_debug_GC.csv', "Not optimized qSort, GC, debug"),
           ('ArrayQuickSort_release_noGC.csv', "qSort, no GC, release"),
           ('ArrayQuickSortForExp_release_noGC.csv', "Not optimized qSort, no GC, release"),
           ('ArrayQuickSort_release_GC.csv', "qSort, GC, release"),
           ('ArrayQuickSortForExp_release_GC.csv', "Not optimized qSort, GC, release")
           ],
          "NotOptimizedArrayQuickSortVSOptimizedQSort.pdf")


