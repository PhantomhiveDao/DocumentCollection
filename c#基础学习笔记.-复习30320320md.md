# c#基础学习笔记

[TOC]



### 1. c#的重要功能

- 布尔条件（Boolean Conditions）

- 自动垃圾回收（Automatic Garbage Collection）

- 标准库（Standard Library）

- 组件版本（Assembly Versioning）

- 属性（Properties）和事件（Events）

- 委托（Delegates）和事件管理（Events Management）

- 易于使用的泛型（Generics）

- 索引器（Indexers）

- 条件编译（Conditional Compilation）

- 简单的多线程（Multithreading）

- LINQ 和 Lambda 表达式

- 集成 Windows

  注意：

  > - C# 是大小写敏感的。
  > - 所有的语句和表达式必须以分号（;）结尾。
  > - 程序的执行从 Main 方法开始。
  > - 与 Java 不同的是，文件名可以不同于类的名称。

### 2.数据类型

#### 1） 引用类型

    引用类型不包含存储在变量中的实际数据，但它们包含对变量的引用。
    
    > 换句话说，它们指的是一个内存位置。使用多个变量时，引用类型可以指向一个内存位置。
    >
    > 如果内存位置的数据是由一个变量改变的，其他变量会自动反映这种值的变化。**内置的** 引用类型有：**object**、**dynamic** 和 **string**。

#### 2）对象（object）类型

> **对象（Object）类型** 是 C# 通用类型系统（Common Type System - CTS）中所有数据类型的终极基类。Object 是 System.Object 类的别名。所以对象（Object）类型可以被分配任何其他类型（值类型、引用类型、预定义类型或用户自定义类型）的值。但是，在分配值之前，需要先进行类型转换。
>
> 当一个值类型转换为对象类型时，则被称为 **装箱**；另一方面，当一个对象类型转换为值类型时，则被称为 **拆箱**。

```c#
object obj;
obj = 100; // 这是装箱
```

####  3）动态（Dynamic）类型

> 您可以存储任何类型的值在动态数据类型变量中。这些变量的类型检查是在运行时发生的。
>
> 声明动态类型的语法：

```
dynamic d = 20;
```

​	动态类型与对象类型相似，但是对象类型变量的类型检查是在编译时发生的，而动态类型变量的类型检查是在运行时发生的。

####  4）字符串（String）类型

> **字符串（String）类型** 允许您给变量分配任何字符串值。字符串（String）类型是 System.String 类的别名。它是从对象（Object）类型派生的。字符串（String）类型的值可以通过两种形式进行分配：引号和 @引号。

```c#
//引号
String str = "runoob.com";
//@引号字符串：
@"runoob.com";
//C# string 字符串的前面可以加 @（称作"逐字字符串"）将转义字符（\）当作普通字符对待，比如：
string str = @"C:\Windows";
//等价于：
string str = "C:\\Windows";
//@ 字符串中可以任意换行，换行符及缩进空格都计算在字符串长度之内。
string str = @"<script type=""text/javascript""> 
<!--    
--></script>";
```

用户自定义引用类型有：class、interface 或 delegate。我们将在以后的章节中讨论这些类型。

####  5）指针类型（Pointer types）

> 指针类型变量存储另一种类型的内存地址。C# 中的指针与 C 或 C++ 中的指针有相同的功能。

声明指针类型的语法：

```c#
type* identifier;
```

例如：

```c#
char* cptr;
int* iptr;
```

我们将在章节"不安全的代码"中讨论指针类型。

#### 2.1术语解释：初始化、声明、实例

- 定义变量的时候——声明:**只生成对象不赋值的过程**。

- 将定义出的变量给一个初始值——初始化:**是给对象赋值的过程**。

- 用类创建对象的过程——实例化:**是使用new为对象分配内存的过程**。

  > 将一个抽象的概念类，具体到该类实物的过程
  >
  > 实例化过程中一般由**类名 对象名 = new 类名（参数1，参数2...参数n）**构成。
  >
  > 实例化一个对象就是为对象开辟内存空间，或者是不用声明，直接使用new 构造函数名，建立一个临时对象。

### 1）循环

#### 1. if

> ```c#
> if(int a;a<=10;i++){}
> ```
>
> ## ? : 运算符
>
> 我们已经在前面的章节中讲解了 **条件运算符 ? :**，可以用来替代 **if...else** 语句。它的一般形式如下：
>
> ```c#
> Exp1 ? Exp2 : Exp3;
> ```
>
> 其中，Exp1、Exp2 和 Exp3 是表达式。请注意，冒号的使用和位置。
>
> ? 表达式的值是由 Exp1 决定的。如果 Exp1 为真，则计算 Exp2 的值，结果即为整个 ? 表达式的值。如果 Exp1 为假，则计算 Exp3 的值，结果即为整个 ? 表达式的值。

#### 2. switch

> ``` c#
> switch(expression){
>     case constant-expression  :
>        statement(s);
>        break; 
>     case constant-expression  :
>        statement(s);
>        break; 
>   
>     /* 您可以有任意数量的 case 语句 */
>     default : /* 可选的 */
>        statement(s);
>        break; 
> }
> ```
>
> - **switch** 语句中的 **expression** 必须是一个整型或枚举类型，或者是一个 class 类型，其中 class 有一个单一的转换函数将其转换为整型或枚举类型。
> - 在一个 switch 中可以有任意数量的 case 语句。每个 case 后跟一个要比较的值和一个冒号。
> - 一个 **switch** 语句可以有一个可选的 **default** 语句，在 switch 的结尾。default 语句用于在上面所有 case 都不为 true 时执行的一个任务。default 也需要包含 **break** 语句，这是一个良好的习惯。
> - 【人话版本】：expression中是要比较判断的内容，只有一致的时候才会执行case中的语句/方法，defalt：case中的条件全不满足的时候执行。

#### 3. while

> ```c#
> while(任意的表达式)//当为任意非零值时都为真;当条件为真时执行循环。
> {}
> ```
>
> 

#### 4. for

> ```c#
> for(定义，条件，跳出)
> {}
> ```
>
> 

#### 5. do...while

> ```c#
> do
> {}
>  while(条件);
> ```
>
> 

### 二、常用方法

#### 1.控制输入输出：

```c#
Console.ReadLine();//获取当前行
Console.WriteLine();//输出并换行
Console.Write();//输出
```

#### 2. 转换字符类型

```c#
Convert.ToInt32();//Convert：转换类型
```

#### 3. 获取单个字符

读取一个字符的输入

```c#
//控制台应用程序中Console.Readkey();返回的类型为Assic码；用tochar转换为字符，判断按下的值。
char C；
C = Convert.ToChar(Console.Read());
```

#### 4.强制类型转换

​	（强制转换的类型）int a；

​	eg：int a=(int) float num;(将浮点形强制转换成int类型)

> Q：C#中Convert与强制转换之间的区别
>
> A：Convert与强转最大的区别是 增加了范围校验，如果不在范围内，直接抛出异常。
>
> [参考链接]https://blog.csdn.net/ylq1045/article/details/128114314
>
> > C#中小数转化为整数，Convert转换原理如下：如果小数部分小于0.5，或者小数部分大于0.5，则按照四舍五入的方式获取整数
> >
> > C#中小数转化为整数，Convert转换原理如下：如果小数部分等于0.5，则返回最接近的偶数，即返回的偶数与原小数的差的绝对值相差0.
> >
> > > by源泽：console.writeline不好使的时候可以试试debug.writeline

### 三、数据基本类型

​	整型：按照存储值的范围不同，c#语言将整形分成了byte类型

short类型、int类型、long类型等，并分别定义了有符号数和无符号数。

​	有符号数可表示负数；无符号数只能表示正数。

​	https://www.runoob.com/csharp/csharp-data-types.html

![image-20230209212902006](C:\Users\mkdz\AppData\Roaming\Typora\typora-user-images\image-20230209212902006.png)

​	动态（Dynamic）类型：

​		Dynamic：可以存极大值（底层转成字符串存储）

​	显示转换：大范围数据类型值塞入小范围数据类型时，使用（数据类型）

​	隐示类型转换：小范围类型转入大范围类型[编译器无法判断数据是否丢失]

​	编译器只检查容器大小，不检查容器内的具体数值大小。因为数值作为变量是随时变化的。

强制类型转换的对象需要类型一致。

eg：int a=（int）“3342”；字符串无法转为数字。

#### 1.字符串

#### 2.数组

- 表达形式：

  ​	定义一个数组：int[] a;

  ​	给数组赋值：

  ​	int[] a ={1,2,4,1,2,3,1};

  ​	int[] a=new int[4];//长度为4的空数组

  ​	int[] a= new int [4]{1,2,4,2};

  ​	int[] a;

  ​	a=new int [3]{1,2,3};

## 一、错误调试

#### 正常模式下：打印

#### 中断模式：debug

## 二、中断模式下的调试

#### 1.怎么打断点

- 鼠标在代码行前边点击
- F9快捷键

#### 2.窗口

- 断点窗口

- 局部变量

- 错误列表：

  - 中断模式下的窗⼝（左下⾓），有三个选项卡

  - 局部变量 -当前运⾏环境中所有的局部变量的值

  - 监视 -监视某个变量的值的变化 

    在上⾯的⼏个窗⼝中不但可以观察变量值的变化，还可以直接去修改变量中存储的值

#### 3.执行

- 逐语句
- 逐过程

## 三、错误处理（异常的处理）

### 1.异常：(Exception)

​	异常是在运⾏期间代码中产⽣的错误。

- 实例：

  - ```c#
    int[] myArray = {1,2,3,4}; 
    int myEle = myArray[4];//数组下标越界
    ```

    ​	运⾏到这⾥的时候，会出现异常，这个异常的定义已经在CLR中定义好了。如果我们不去 处理这个异常，那么当异常发⽣的时候，程序会终⽌掉，然后异常后⾯的代码都⽆法执 ⾏。

    ​	CLR: c# .net框架中的内容

  - 异常处理(捕捉异常) try ... catch ... finally 语句

  - 

## 四、构造函数

### 1.起因

- 构造对象的时候，对象的初始化过程是**⾃动完成**的，但是在初始化对象的过程中有的 时候需要做⼀些额外的⼯作

### 2.声明构造函数

- 构造函数的名字应该与类名保持一致，函数没有返回值

- 用来初始化数据

- 每创建一次函数的时候，都会调用一次构造函数。

- ```c#
  namespace unit004_面向对象//命名空间的名称与项目名一致
  {    //顾客类
      class Customer
      { 
          //数据成员
          public string name;
          public string address;
          public int age;
          public int creatTime;
          //构造函数
          public Customer(string arg1, string arg2, int arg3, int arg4)
          {
              name = arg1;
              address = arg2;
              age = arg3;
              creatTime = arg4;
          }
          //函数成员
          public void Show()
          {
              Console.WriteLine("名字：" + name);
              Console.WriteLine("地址：" + address);
              Console.WriteLine("年龄：" + age);
              Console.WriteLine("创建时间：" + creatTime);
          }      
      }
  }
  ```

  

## 五、属性

​	get{  }set{  }

```c#
namespace unit005_属性//命名空间的名称与项目名一致
{
    //顾客类
    class Customer
    {   //数据成员
        private string name;
        private string address;
        private int age;
        private int creatTime;
        //获取数据成员的值：get方法，set方法。
        //public void SetAge(int age)
        //{
        //    this.age = age;//this可以区分参数还是成员
        //}
        //public int GetAge()
        //{
        //    return age;
        //是个属性，使用时等同普通的成员，可以直接设置值和取得值
        //get{}set{}相当于一个简写的public void SetAge(int age)和public int GetAge()
        public int Age
        {
            get//相当于一个返回方法
            {
                return age;
            }
            set//vaule默认的参数
            {
                age = value;
            }
        }
    }
```

### 只读

```c#
 public string Address
    {
        get//相当于一个只读
        {
            return address;
        }        
    }
```



### 只写

```c#
   public int Address
        {
            set//相当于一个只读
            {
                creatTime=value;
            }
        }
```

### 简写

```c#
public int Address
        {
            get;set;//相当于一个只读
            
        }
```

## 六、匿名类型

### var

声明类型之前不指定类型；在初始化的时候指定类型。

## 七、程序内存区域

- 程序所有的数据，也就是所有的变量，都是存储在内存中的。

### 1.堆 

堆空间⽐较⼤，但是读取速度慢

堆是⼀块内存区域，与栈不同，堆⾥的内存能够以任意顺序存⼊和移除

### 2.栈 

栈空间⽐较⼩，但是读取速度快

#### 特征-后进先出（Last in First out）

数据只能从栈的顶端插⼊和删除 
把数据放⼊栈顶称为⼊栈（push） 
从栈顶删除数据称为出栈（pop）

内存中的栈，是由系统管理（.Net框架）

### 3.静态存储区

### 4.垃圾回收器(GC Garbage Collector)

CLR的GC就是内存管理机制，我们写程序不需要关⼼内存的使⽤，因为这些都是CLR帮 我们做了

上述是编译器开发者的事情。

只需要了解和知道的，不需要知道内在核⼼原理，我们知道汽⻋的引擎 是汽⻋的核⼼动⼒来源，我们不需要知道引擎是怎么造。

### 5.值类型和引⽤类型

值类型只需要⼀段单独的内存，⽤于存储实际的数据，（单独定义的时候放在栈中） 

引⽤类型需要两段内存 第⼀段存储实际的数据，它总是位于堆中 第⼆段是⼀个引⽤，指向数据在堆中的存放位置

#### 构造和赋值

### 八、继承

很多类中有相似的数据，⽐如在⼀个游戏中，有Boss类，⼩怪类Enemy，这些类他们有 很多相同的属性，也有不同的，这个时候我们可以使⽤继承来让这两个类继承⾃同⼀个 类。

将公共的部分提取成一个类，作为父类。

#### 1.实现继承

父类（基类）-子类（派生类）

子类可以重写父类的函数/方法

#### 2.接口继承

**多层继承 （可以继承多个父类）//c#和java不支持。**

⼀些语⾔(C++)⽀持所谓的 “多重继承”,即⼀个类派⽣⾃多个类。

#### 3.多重接口继承

 ⽽ C#允许类型派⽣⾃多个接 Unity 1143 C#编程-第⼆季-⾯向对象 16 ⼝— — 多重接⼝继承。 这说明,C#类可以派⽣⾃另⼀个类和任意多个接⼝。更准确地说, System.Object 是⼀个公共的基类,所 以每个 C#(除了Object类之外)都有⼀个基类,还可以 有任意多个基接 ⼝。

#### 4.虚方法-可以重写父类中的方法

##### 1）虚方法

关键字：virtual

```c#
//boss的移动方式和父类的方法不一样
//使用虚方法的方式：在父类中将方法声明为 virtual
```

##### 2.重写

关键字 override

会提示可以重写的方法。

![image-20230219150620140](C:\Users\mkdz\AppData\Roaming\Typora\typora-user-images\image-20230219150620140.png)

#### 5.隐藏方法-也可以重写父类中的方法

关键字：new

隐藏方法只有在声明的对象是子类的时候才会调用重写之后的方法。

如果声明的对象是父类，则调用父类中的同名方法。

## 八、抽象类

不完整的模板-声明为抽象类。不能调用对象

### 1.抽象函数

//在抽象类下声明一个抽象函数；

关键字：abstract

```c#
using System;
using System.Collections.Generic;
using System.Text;
namespace unit009_抽象类
{
    class Enemy
    {
        //每个敌人都能攻击，但是攻击方法不一样，
        public abstract void Attack();//抽象函数/抽象方法
        //但是按照这种写法Attack下会报错。
        //因为抽象函数只能在抽象类下出现。
        //抽象函数下没有函数体
    }
}

```

```c#
using System;
using System.Collections.Generic;
using System.Text;

namespace unit009_抽象类
{
    abstract class Enemy//相对于上边的代码块多出了abstract,意思为将该类转换为了抽象类
    {

        //每个敌人都能攻击，但是攻击方法不一样，
        public abstract void Attack();
        //抽象函数/抽象方法

    }
}

```

抽象类下可以包含正常的函数成员。普通的函数等

 **不能用抽象类构造对象**

![image-20230219184220483](C:\Users\mkdz\AppData\Roaming\Typora\typora-user-images\image-20230219184220483.png)

### 2.密封类 密封方法-实际上用的比较少

关键字：sealed

密封类不能被继承。

重写的方法可以加载重载的类前边

```c#
namespace unit009_抽象类
{
    class Boss:Enemy
    {
        public sealed override void Attack()
        {
            //throw new NotImplementedException();//抛出一个异常
            Console.WriteLine("boss攻击");
        }
    }
}
```

### 3.派⽣类（⼦类）的构造函数

指定了调用了有参的构造函数之后，就不会调用父类里无参的构造函数了。

使用方式：

【：base（）】

```c#
namespace unit010_子类的构造
{
    class DrivedClass:BaseClass
    {
        private int attack;
        public DrivedClass():base()//base()调用父类里的构造函数
            //不写也会默认添加
        {
            Console.WriteLine("构造函数：DrivedClass");
        }
        public DrivedClass(int attack,int hp,int age):base(hp,age)
            //指定了调用某个构造函数之后
        {
            this.attack = attack;
        }
    }
}
```

### 4.修饰符

#### 1） 类型或成员的关键字

用来修饰类型或者成员的关键字。修饰符可以指定⽅法的可⻅性。

> public: 同⼀程序集(DLL或EXE)[同一个项目]中的任何其他代码或引⽤该程序集的其他程序集都可 以访问该类型或成员。
>
> private: 只有同⼀类或结构中的代码可以访问该类型或成员。
>
> protected: 只有同⼀类或结构或者此类的派⽣类中的代码才可以访问该类型或成员。 //在子类里可以访问
>
> internal: 同⼀程序集中的任何代码都可以访问该类型或成员，但的代码不可以。 
>
> protected internal: 在⼀程序集中，protected internal体现的是internal的性质；在其 他程序集中，protected internal体现的是protected的性质

public 和private修饰字段和⽅法的时候，表⽰该字段或者⽅法能不能通过对象去访问，只有public的才可以通过对象访问，

private（私有的）只能在类模板内部访问。 

protected 保护的，当没有继承的时候，它的作⽤和private是⼀样的，当有继承的时候， protected表⽰可以被⼦类访问的字段或者⽅法

#### 2）类的修饰符

public 

类的默认权限是只在本项目中使用的。

子类的访问权限不能高于父类

**如何在项目B中调用项目B的**

1. 添加别的项目的引用<img src="C:\Users\mkdz\AppData\Roaming\Typora\typora-user-images\image-20230219192021637.png" alt="image-20230219192021637" style="zoom:50%;" />
2. 引入命名空间<img src="C:\Users\mkdz\AppData\Roaming\Typora\typora-user-images\image-20230219192045974.png" alt="image-20230219192045974" style="zoom:50%;" />

3. 将类的权限设置为public

[https://www.cnblogs.com/zhouzl/archive/2019/04/13/10701476.html]: https://www.cnblogs.com/zhouzl/archive/2019/04/13/10701476.html	"c#常用修饰符-博客园"

## 接口

定义关键字：interface

接口名以I开头

只包含方法的定义，不包含方法的实现。

实现接口：必须重写接口的所有方法

c#中单继承——只能继承一个类，但是可以实现多个接口

## 接口的继承（用的少）

类可以实现多个接口和类的继承

```c#
class test : IFly,IColor
    {
        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void FlyAttack()
        {
            throw new NotImplementedException();
        }

        public void SetColor()
        {
            throw new NotImplementedException();
        }
```

## 九、索引器

说明：索引器是类的特殊成员，它可以根据索引在多个成员中进行选择，能够让对象以类似数组的方式来存取。索引器的数据类型必须是统一的

用法：取值，赋值

某些情况下方便阅读。

```c#
//定义一个索引器 
//this--使用的当前对象
//index--索引
public int this[int index]
        {
            get 
            {
                return 100;
            }
            set
            {
                Console.WriteLine(value);
            }
        }
```

作用：可以利用索引器往数组里

类里声明一个数组。利用索引器往数组内赋值，也可以取值。

```c#
private string [] name = new string[10];
        //定义一个索引器
        public string this[int index]
        {
            get 
            {
                
                return name[index];
            }
            set
            {
                name[index] = value;
              
            }
        }
```

## 十、运算符重载

关键字：operator

```c#
 public static bool operator ==(Student s1, Student s2)
        {
            if (s1.age == s2.age && s1.id == s2.id && s1.name == s2.name)
                return true;
            return false;
        }
```

## 十一、结构体和类的不同

#### 结构体 - struct

>  C# 中，结构体是**值类型**数据结构。它使得一个单一变量可以存储各种数据类型的相关数据。**struct** 关键字用于创建结构体。
>
> 结构是值类型，它在**栈**中分配空间；而类是引用类型，它在**堆**中分配空间，栈中保存的只是引用。

```c#
struct Game
{
  	public int Gameid;  
    private string UserName;
    public int Level;
}
```

> 结构体中声明的字段无法赋予初值，类可以:
>
> ```c#
> struct test001
> {
>     private int aa = 1;
> }
> ```
>
> 执行以上代码将出现“**结构中不能实例属性或字段初始值设定**”的报错，而类中无此限制，代码如下：
>
> ```c#
> class test002
> {
>     private int aa = 1;
> }
> ```
>
> 

## 类 vs 结构

> 类和结构有以下几个基本的不同点：
>
> - 类是引用类型，结构是值类型。
> - 结构不支持继承。
> - 结构不能声明默认的构造函数。

### 重构-重新设计-架构师

重新 结构

把程序中的某些结构进行修改或增加

## 十二、集合类

### 列表List

创建一个list

```c#
using System;
using System.Collections.Generic;

namespace unit018_list列表
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1,2,3};
            //需要定义放置什么类型的数据;用<>标识--泛型
            //用系统提供的一个类创建了一个对象
            //使用{}添加初始数据
        }
    }
}
```

列表内部存储数据的原理.

列表的容量会自动增加-以2的n次方来增加

在已知列表长度的时候-指定列表容量的初始大小:

List<int> list=new List<int>(50);//定义了一个初始容量为50的列表.



- 元素个数≠list容量
- .Capacity----获取列表容量
- .Count----获取列表元素个数

### 泛型类

定义:

```c#
class ClassA<T> //一个泛型用T;Type=->int string double
    {
        private T a;
        private T b;

        public ClassA(T a, T b)
        {
            this.a = a;
            this.b = b;
        }
        public T GetSum()
        {
            //声明一个动态类型-dynamic
            dynamic num1 = a;
            dynamic num2 = b;
            dynamic result = num1 + num2;
            return (T)result;
        }
    }
```

### 类的对象-ToString方法

默认情况下输出类的完整路径

把对象当作字符串来用的时候,会默认调用ToString()方法,输出类所在的路径

### 泛型方法

T

#### 字典-dictionary

##### Hashtable--哈希表

不需要指定泛型；同样是键值对存储

##### Dictionary<TKey,TVaule>--必须指定泛型

键值对存储key-vaule；key不能重复

游戏中使用字典存储游戏道具
