// InvokeDll.cpp : �������̨Ӧ�ó������ڵ㡣
//

#include "stdafx.h"
#include "..\DllDemo\DllDemo.h"

int _tmain(int argc, _TCHAR* argv[])
{
	/*����dll�������÷�ʽΪĬ�ϵ��÷�ʽ*/
	 
	printf("5+3=%d\n",add(5,3)); 
 
	Point p;
	p.Print(5,3);
	return 0;
}

