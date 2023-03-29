# siki c#第四季

1. 字符串好好学习，其他可以后期遇到再学。

1. 命名空间-namespace

   1) 目的：为了给类进行分类。

   2) 使用：命名空间之间可以嵌套

      ```c#
      namespace unit02namespace
      {
          namespace namespace2
          {
              internal class Class2
              {
      
              }
      
          }
         
      }
      ```

### 字符串和正则表达式

 	1. 字符串类
 	  	1. System.String
 	  	2. System.Text.StringBuilder
 	2. 字符串是静态的 不能被修改。
 	3. 字符串的方法
 	  	1. 

### 正则表达式-regular Expression/规则表达

1. 检索：通过正则表达式，从字符串中获取我们想要的部分
2. 匹配：判断给定字符串是否符合正则表达式的过滤逻辑。
   1. ）正则表达式表述了一个字符串的书写规则。

### 委托

先定义，再使用。

定义的语法：

​	delegate void IntMethodInvoker（int x）；

//定义了一个委托没指向了int

#### 多播委托

​	只能得到调用的最后一个方法的结果。

​	包含了一个委托的集合

​		如何获得这个集合：

```c#
Delegate[] dels=ac1.GetInvocationList();//返回的是Delegate类这个类型的数组
 foreach(Delegate de in dels) 
            {
                de.DynamicInvoke();//DynamicInvoke：动态调用
            }
```

#### 匿名方法

​	用的地方很少。

​	减少代码复杂性。

```c#
//Func<int,int,int>puls=delegate(int a,int b){ return a + b; };

            //lambda表达式：一种语法规则；可以对复杂一些的匿名方法进行简化
            Func<int, int, int> puls = (a, b) => { return a + b; };
            //当lambda表达式中只有一条语句时，可以进一步简化
            Func<int, int, int> test = (x, y) => x - y;
            //Func<传递参数类型，传递参数类型，返回参数类型>匿名方法名称=（参数1，参数2）=>
            int res = puls(3 ,4);
            Console.WriteLine(res);
            //lambda可以访问外部变量;但是容易结果不可控，容易出现编程问题
            int a = 90;
            Func<int, int, int> F = (x, y) => x - y+a;
```

### 事件event

## LINQ

### 用法

​	在数据（集合）中做查询
​		可以为后期学习数据库做准备（服务器端开发）

​	客户端开发用不到linq

​	了解，可以跳过。

## 反射和特性-用的不多

	#### 什么是元数据和反射

​		BCL-（basic Class Lib）基础类库

​	有关程序及其类型的数据被称为元数据（metadata）保存在程序的程序集中。

​	文件后缀：dll；.exe

​	Type
​		通过type可以获得到类里面指定的一些信息。
​		比如：成员，方法，字段，命名空间...

```c#
using System;
using System.Reflection;

namespace unit13_反射
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type
            Type type = typeof(MyClass1);
            Console.WriteLine(type.Name);
            Console.WriteLine(type.Namespace);
            Console.WriteLine(type.Assembly);
            FieldInfo[] fis= type.GetFields();
            foreach (FieldInfo fi in fis) 
            { 
            Console.WriteLine(fi.Name);
            }
            PropertyInfo[] pis=type.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                Console.WriteLine(pi.Name);
            }
            MethodInfo[] methodInfos = type.GetMethods();
            foreach (MethodInfo mi in methodInfos)
            {
                Console.WriteLine(mi.Name);
            }

        }
    }
}

```

#### 如何加载程序集

## 特性

1. Obsolete(过时的):对方法增加描述可以标记为弃用，作为提示。

2. Conditional(条件)：在引用命名空间之前【#define】一个宏，用来控制方法是否启用。

   ```c#
   #define ISshowMessage//定义一个宏
   //宏
   using System;
   using System.Diagnostics;
   namespace unit14_特性
   {internal class Program
       {[Obsolete("请用新的nwetest",false)]//特性：obsolete标记为弃用;
           static void Test( ) 
           { Console.WriteLine("Hello World!"); }     
           static void newTest( )
           {        }
           [Conditional("ISshowMessage")]
           static void ShowMessage(string str )
           {Console.WriteLine(str);        }
           static void Main(string[] args)
           {   Test();
               ShowMessage("qwq");
               Console.WriteLine("---------");
               ShowMessage("TaT");        }
       }
   }
   
   ```

   

### 定义

​	是一种允许我们向程序的程序集增加元数据的语言结构。用于保存程序结构信息的某种特殊类型的类。
​	（相当于文档的批注）

> ​	将应用了特性的程序结构叫目标。
> ​	设计用来获取和使用元数据的程序（对象浏览器）叫做特性的消费者。
> ​	.NET预定了很多特性，我们也可以生命自定义特性。

#### 自定义特性

## 线程、任务、同步

### 线程



#### 概念

> 一个进程的多个线程可以同时运行在不同的CPU上或多核CPU的不同内核上。

一个应用程序启动，会启动一个进程（应用程序运行的载体），然后进程启动多个线程。
进程包含资源，如Window句柄、文件系统句柄嚯其他内核对象。
每个进程都分配的虚拟内存。一个进程至少包含一个线程。

> 程序 ->进程->线程

程序（我们写的代码-静态观念）

### 创建

​	使用Thread类可以创建和控制线程

> Thread构造函数的参数是一个无参、无返回值的**委托类型**

### 任务

### 同步

在一个线程中执行

### 异步

新开一个线程

### 前台线程 后台线程

#### 前台线程：

> 只要有一个前台线程在运行，应用程序的进程就在运行。
>
> 如果，多个前台线程在运行，但是main方法结束了。进程仍然运行，直到所有前台线程完成任务为止
>
> **可以推测出：前台线程优先级高于后台线程**
>
> 后台线程：以服务用的为主

默认情况下Thread类创建的线程是前台线程。线程池中的线程总是后台线程。

Thread类中有个属性IsBackGround

### 线程的优先级

### cpu处理线程的方式

> 以毫秒为单位，切换线程交替进行。
>
> - 调度规则：随机调用一个线程（？）优先级高的，被随机到的概率大

#### 线程优先级的级别：

```c#
设置Priority属性；是ThreadPriority枚举定义的一个值。
    定义的级别有：Highest；AboveNormal，Normal,BelowNormal,Lowset
    //具体表现为
Thread a = new Thread(A);
a.Priority= ThreadPriority.BelowNormal;

    
```

#### 控制线程

1. 获取线程的状态——Running/Unstarted
   1. 调用Start方法之后，不是马上进入Running状态，二十储物Unstarted状态。只有当操作系统的线程调度器选择了要运行的线程，线程的状态才会修改为Running状态
   2. 使用Thread.Sleep()方法让当前线程休眠，进入WaitSleepJoin状态
   3. 
