#include "stdafx.h"
#include <Windows.h> 
 
int _tmain(int argc, _TCHAR* argv[])
{
	/*����dll�������÷�ʽΪĬ�ϵ��÷�ʽ*/
	HINSTANCE hInst = LoadLibrary(L"DllDemo2.dll");
	if(!hInst)
	{
		printf("����MathFuns.dllʧ��!\n");
	}
	typedef int (*DllDemoAPIProc)(int a, int b);
	DllDemoAPIProc Add = (DllDemoAPIProc)::GetProcAddress(hInst,"add");
	printf("5+3=%d\n",Add(5,3));
	::FreeLibrary(hInst);
	
	
	return 0;
}
