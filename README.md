# AutoShot
This is a software that can auto click and take a screenshot. This toy is programed and used to take silly, meaningless, rediculous 'result screenshots' which is required by the lab report of CS220FZ.

By what the screenshots is necessary? If the number of inputs reaches 6 or even 7, are we supposed to take 64 or 128 shots? Why can't we just upload varilog files and run test cases to checking them?

However, this is the solution to take screenshots required.

This programe could simulate mouse clicks every points specified according to the gray code, and take screenshot at specified area. Meanwhile, if the location of LED is specified, it can also generating the truthtable in TeX.

此程序，可以根据格雷码规律模拟鼠标点击各点，然后在指定位置截图。同时，如果给出 LED 灯的位置，还能自动判断灯的颜色，生成 TeX 形式的真值表。

## Usage 用法
首先在程序根目录创建文件 innam.txt 及 outnam.txt，其中分别为输入端和输出端的名称。

启动程序后，程序将询问在何处点击。将鼠标悬停在目标开关位置上，然后敲击回车。如此登记各点位置。

在询问完截图区域后，程序将自动处理剩下的全部内容。

截图将保存到 vimg 文件夹中。并生成用于嵌入的 variimgs.tex 文件便于将图像嵌入 TeX 文档。

注意：图像为 PNG 格式，请使用 pdfLaTeX 或先行转换格式。

## 用例
innam.txt:
```
A
B
C
D
```

outnam.txt:
```
$$f_{gt}$$
$$f_{eq}$$
$$f_{lt}$$
```

## 环境需求
Windows （高分屏运行测试正常）
.Net framework 3.5
