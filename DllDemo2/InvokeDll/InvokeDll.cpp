#include "stdafx.h"
#include <Windows.h> 

#include<vector>
using namespace std;
 
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

	typedef void (*DllDemoAPIProc1)(vector<float> x);
	DllDemoAPIProc1 many = (DllDemoAPIProc1)::GetProcAddress(hInst,"many");
	printf("5+3=%d\n",Add(5,3));

	vector<float> x;
	x.push_back(1.f);
	many(x);






	::FreeLibrary(hInst);
	
	
	
	return 0;
}
