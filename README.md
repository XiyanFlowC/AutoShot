# AutoShot
This is a software that can auto click and take a screenshot. This toy is programed and used to take silly, meaningless, rediculous 'result screenshots' which is required by the lab report of CS220FZ.

By what the screenshots is necessary? If the number of inputs reaches 6 or even 7, are we supposed to take 64 or 128 shots? Why can't we just upload varilog files and run test cases to checking them?

However, this is the solution to take screenshots required.

This programe could simulate mouse clicks every points specified according to the gray code, and take screenshot at specified area. Meanwhile, if the location of LED is specified, it can also generating the truthtable in TeX.

�˳��򣬿��Ը��ݸ��������ģ����������㣬Ȼ����ָ��λ�ý�ͼ��ͬʱ��������� LED �Ƶ�λ�ã������Զ��жϵƵ���ɫ������ TeX ��ʽ����ֵ��

## Usage �÷�
�����ڳ����Ŀ¼�����ļ� innam.txt �� outnam.txt�����зֱ�Ϊ����˺�����˵����ơ�

��������󣬳���ѯ���ںδ�������������ͣ��Ŀ�꿪��λ���ϣ�Ȼ���û��س�����˵ǼǸ���λ�á�

��ѯ�����ͼ����󣬳����Զ�����ʣ�µ�ȫ�����ݡ�

��ͼ�����浽 vimg �ļ����С�����������Ƕ��� variimgs.tex �ļ����ڽ�ͼ��Ƕ�� TeX �ĵ���

ע�⣺ͼ��Ϊ PNG ��ʽ����ʹ�� pdfLaTeX ������ת����ʽ��

## ����
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

## ��������
Windows ���߷������в���������
.Net framework 3.5
