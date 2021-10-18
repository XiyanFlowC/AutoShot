# AutoShot
This is a software that can auto click and take a screenshot. This toy is programed and used to take silly, meaningless, rediculous 'result screenshots' which is required by the lab report of CS220FZ.

By what the screenshots is necessary? If the number of inputs reaches 6 or even 7, are we supposed to take 64 or 128 shots? Why can't we just upload varilog files and run test cases to checking them?

However, this is the solution to take screenshots required.

This programe could simulate mouse clicks every points specified according to the gray code, and take screenshot at specified area. Meanwhile, if the location of LED is specified, it can also generating the truthtable in TeX.

此程序，可以根据格雷码规律模拟鼠标点击各点，然后在指定位置截图。同时，如果给出 LED 灯的位置，还能自动判断灯的颜色，生成 TeX 形式的真值表。

已经添加了对 Markdown 语法的输出支持。

## Usage 用法
首先在程序根目录创建文件 innam.txt 及 outnam.txt，其中分别为输入端和输出端的名称。

启动程序后，程序将询问在何处点击。将鼠标悬停在目标开关位置上，然后敲击回车。如此登记各点位置。

在询问完截图区域后，程序将自动处理剩下的全部内容。

截图将保存到 vimg 文件夹中。并生成用于嵌入的 variimgs.tex 文件便于将图像嵌入 TeX 文档。

注意：图像为 PNG 格式，请使用 pdfLaTeX 或先行转换格式。

如果需要以 Markdown 语法输出，请在程序根目录处新建文件，文件名为 usemd，注意不能有扩展名。

## 用例
比如，有输入端 A, B, C, D 和输出端 $f_{gt}$，$f_{eq}$，$f_{lt}$ （分别连接开关和 LED）。则编写以下文件：

innam.txt:
```
A
B
C
D
```

outnam.txt:
```
$f_{gt}$
$f_{eq}$
$f_{lt}$
```

然后运行程序。首先输入保存名，如 lab1。然后回车。

接下来，按提示将鼠标悬停到相应组件（开关或 LED）上，然后按回车键。

全部完成后，鼠标将自动移动到开关上并点击。此时请双手离开鼠标键盘以免影响。默认每秒截一次图，点一次开关。

截图将保存到文件夹 vimglab1 中，截图的引用(\includegraphics指令序列)也将自动生成到 vimglab1.tex 中，此外，真值表将生成到 ttbllab1.tex 中。

生成的 tex 文件不能直接使用，请自行微调。

## 环境需求
Windows （高分屏运行测试正常）
.Net framework 3.5
