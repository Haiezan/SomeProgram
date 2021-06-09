/**********************************************/
/*FileName:DllDemo.h 						  */
/**********************************************/
 
#ifdef DllDemoAPI
#else
#define DllDemoAPI _declspec(dllimport)
#endif

#include<vector>
using namespace std;
 
DllDemoAPI int add(int a, int b);
DllDemoAPI int subtract(int a, int b);
DllDemoAPI int multiple(int a, int b);

DllDemoAPI void many(vector<float> x);
 
class DllDemoAPI Point
{
public:
	void Print(int x, int y);
};
