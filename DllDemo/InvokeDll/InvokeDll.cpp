// InvokeDll.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "..\DllDemo\DllDemo.h"

int _tmain(int argc, _TCHAR* argv[])
{
	/*加载dll函数调用方式为默认调用方式*/
	 
	printf("5+3=%d\n",add(5,3)); 
 
	Point p;
	p.Print(5,3);
	return 0;
}

