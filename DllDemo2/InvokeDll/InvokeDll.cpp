#include "stdafx.h"
#include <Windows.h> 
 
int _tmain(int argc, _TCHAR* argv[])
{
	/*加载dll函数调用方式为默认调用方式*/
	HINSTANCE hInst = LoadLibrary(L"DllDemo2.dll");
	if(!hInst)
	{
		printf("加载MathFuns.dll失败!\n");
	}
	typedef int (*DllDemoAPIProc)(int a, int b);
	DllDemoAPIProc Add = (DllDemoAPIProc)::GetProcAddress(hInst,"add");
	printf("5+3=%d\n",Add(5,3));
	::FreeLibrary(hInst);
	
	
	return 0;
}
