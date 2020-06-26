from matplotlib import pyplot as plt;
from mpl_toolkits.mplot3d.axes3d import Axes3D
import json
import numpy as np
import struct

def read_txt_high(filename):
    with open(filename, 'r') as file_to_read:
        listall0 = []
        while True:
            lines = file_to_read.readline()  # 整行读取数据
            list0 = []
            if not lines:
                break
            item = [i for i in lines.split()]
            for i in range(0,len(item),1):
                data0 = json.loads(item[i])#每行第一个值
                list0.append(data0)

            listall0.append(list0)
            listall=np.transpose(listall0)
    return listall

def plotcurve():
    fig = plt.figure()
    axes3d = Axes3D(fig)
    axes3d.set_xlabel('Mx')
    axes3d.set_ylabel('My')
    axes3d.set_zlabel('N')

    filename='D:\Github\TractDll\PMM.dat'
    alldata=read_txt_high(filename)
    
    Num=int(len(alldata)/3)

    for i in range(0,Num,1):
        x=alldata[i*3]
        y=alldata[i*3+1]
        z=alldata[i*3+2]

        axes3d.plot(x,y,z,'--',color='dimgray')
        axes3d.scatter(x,y,z,'--',color='black')

    #filename='D:\Github\JSTract\JSTract\COL.dat'
    #z000,x000,y000=read_txt_high(filename)
    #axes3d.plot(x000,y000,z000,color='red')
    #axes3d.scatter(x000,y000,z000,color='red')
    #plt.xlim(-1e9,1e9)
    #plt.ylim(-1e9,1e9)
    plt.show()
