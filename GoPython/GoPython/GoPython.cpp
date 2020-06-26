// GoPython.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <Python.h>

void print()
{
	Py_Initialize();
	PyRun_SimpleString("print('Hello World!')\n");//Python3语法
	Py_Finalize();
}
void Hello()
{
	Py_Initialize();//调用Py_Initialize()进行初始化
	PyRun_SimpleString("import sys"); PyRun_SimpleString("sys.argv = ['python.py']");
	PyObject * pModule = NULL;
	PyObject * pFunc = NULL;
	pModule = PyImport_ImportModule("Plot");//调用的Python文件名
	pFunc = PyObject_GetAttrString(pModule, "plotcurve");//调用的函数名
	PyEval_CallObject(pFunc, NULL);//调用函数,NULL表示参数为空
	Py_Finalize();//调用Py_Finalize,和Py_Initialize相对应的.
}
int main()
{
	//print();
	Hello();
    //std::cout << "Hello World!\n"; 
	Py_Initialize(); /*初始化python解释器,告诉编译器要用的python编译器*/

	PyRun_SimpleString("import sys"); PyRun_SimpleString("sys.argv = ['python.py']");

	PyRun_SimpleString("import matplotlib.pyplot as plt"); /*调用python文件*/
	PyRun_SimpleString("plt.bar([1,2,3],[2,1,3])"); /*调用python文件*/
	PyRun_SimpleString("plt.show()"); /*调用python文件*/
	Py_Finalize(); /*结束python解释器，释放资源*/
	system("pause");
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
