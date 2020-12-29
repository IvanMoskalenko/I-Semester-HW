import matplotlib.pyplot as plt
import matplotlib.patches as mpatches
import pandas as pd

labels = []


def prepare_data(csv_filename):
    data_fr = pd.read_csv("./" + csv_filename + ".csv")
    return data_fr.T  #переворачиваем


def to_array_length(key, x=15000, y=25000):
    return key * x + y

def get_dict_of_average_for_alg(alg_data_name: str, x=15000, y=25000):
    dft = prepare_data(alg_data_name)
    res = {}
    for key, values in dft.iteritems():
        v = values[1:]
        res[to_array_length(key, x=x, y=y)] = v.sum() / v.size
    return res


def get_ratio(filename1: str, filename2: str, x=15000, y=25000):
    res = {}
    alg1 = get_dict_of_average_for_alg(filename1, x=x, y=y)
    alg2 = get_dict_of_average_for_alg(filename2, x=x, y=y)
    keys = list(alg1.keys())
    for key, first, second in zip(keys, list(alg1.values()), list(alg2.values())):
        res[key] = (first / second)
    return res

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
    elif wLbl == "wLbl3":
        add_label(axs.violinplot(r,
                                 positions=lbl3,
                                 widths=150,
                                 showmeans=False,
                                 showmedians=True),
                  name)
    else:
        add_label(axs.violinplot(r,
                                 positions=lbl3,
                                 widths=30,
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


def plot_ratio_to_pdf(ratios, filename: str, k, max_array_length=1500000, scale_factor=1.0):
    plt.ioff()
    axs = plt.axes()
    axs.yaxis.grid(True)
    axs.set_xlabel(f'Длина входного списка (* {k})')
    axs.set_ylabel('k отношения средних значений по времени')
    plt.plot(list(ratios.keys()), list(ratios.values()))
    plt.xlim(0 * scale_factor, max_array_length * scale_factor)
    plt.savefig("./" + filename + ".pdf")
    plt.clf()

plot_ratio_to_pdf(get_ratio("ListSort_debug_noGC", "ListSort_debug_GC"), "kGCvsNOGC", 1000000)
plot_ratio_to_pdf(get_ratio("ListSort_debug_GC", "ListSort_release_GC"), "debugvsrel1", 1000000)
plot_ratio_to_pdf(get_ratio("ListQuickSort_debug_GC", "ListQuickSort_release_GC"), "debugvsrel2", 1000000)
plot_ratio_to_pdf(get_ratio("ArrayQuickSort_debug_GC", "ArrayQuickSort_release_GC"), "debugvsrel3", 1000000)
plot_ratio_to_pdf(get_ratio("ArrayBubbleSort_debug_GC", "ArrayBubbleSort_release_GC", 500, 1500), "debugvsrel4", 10, 50000)
plot_ratio_to_pdf(get_ratio("ListBubbleSort_debug_GC", "ListBubbleSort_release_GC", 50, 150), "debugvsrel5", 1, 3000)
plot_ratio_to_pdf(get_ratio("ListBubbleSort_debug_GC", "ListQuickSortForBubble_debug_GC", 50, 150), "kqsortvsbsortlist", 1, 3000)
plot_ratio_to_pdf(get_ratio("ArrayBubbleSort_debug_GC", "ArrayQuickSortForBubble_debug_GC", 500, 1500), "kqsortvsbsortarray", 10, 50000)
plot_ratio_to_pdf(get_ratio("ListQuickSort_debug_GC", "ListSort_debug_GC"), "kqsortvsssortlist", 1000000)
plot_ratio_to_pdf(get_ratio("ArrayQuickSort_debug_GC", "ArraySort_debug_GC"), "kqsortvsssortarray", 1000000)
plot_ratio_to_pdf(get_ratio("ArrayQuickSortForExp_debug_GC", "ArrayQuickSort_debug_GC"), "karrayexp1", 1000000)
plot_ratio_to_pdf(get_ratio("ArrayQuickSortForExp2_debug_GC", "ArrayQuickSortForCompWithExp2_debug_GC", 250, 350), "karrayexp2", 1, 10000)


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
drawFiles([('ArrayBubbleSort_debug_GC.csv', "Array bSort, GC, debug"),
           ('ArrayBubbleSort_release_GC.csv', "Array bSort, GC, release")
           ],
          "ArrayBubbleSortDebugVSRelease.pdf", "wLbl3")
labels = []

####### Added much later #######
drawFiles([('ArrayQuickSortForCompWithExp2_debug_GC.csv', "Array qSort, GC, debug"),
           ('ArrayQuickSortForExp2_debug_GC.csv', "Not optimized Array qSort #2, GC, debug")
           ],
          "ArrayQuickSortVSNotOptimizedQuickSort_2.pdf", "wLbl4")
labels = []

