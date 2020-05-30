import numpy as np
import matplotlib.pyplot as plt

import easygui as a
Msg='欢迎关注**梁柱墙笔记**微信公众号\n请输入参数'
Title='Bouc-Wen'
Fields=['初始刚度','屈服力','屈服后刚度比','屈服指数']

ret=a.multenterbox(Msg,Title,Fields,values=['100000','500','0.02','2'])

k=float(ret[0])    #初始刚度
Fy=float(ret[1])  #屈服力
ratio=float(ret[2]) #屈服后刚度比
exp=float(ret[3])   #屈服指数

x=np.arange(0,np.pi*2,np.pi/100)

d=np.sin(x)/10
f=d*1
z0=0
z=0


for i in range(1,len(d)):
    u=d[i]
    du=(d[i]-d[i-1])/10
    for j in range(10):
        sign=0
        if(du*z>0):
            sign=1
        dz=k/Fy*du*(1-sign*pow(abs(z),exp))
        z=z+dz
    f[i]=ratio*k*u+(1-ratio)*Fy*z

dp=d-f/k
plt.plot(d,f)
#plt.plot(f)
#plt.plot(dp,f)
x000=np.vstack((f,d)).transpose()
np.savetxt('wen.txt',x000)
plt.show()
