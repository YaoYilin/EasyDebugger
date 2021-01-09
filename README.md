# EasyDebugger

一个简单的方便给 Unity 项目添加调试函数用的编辑器。

例如我们定义如下类：
 ```cs
using Debugger;
using UnityEngine;

[GroupLayoutAttribute(LayoutGroupPriority.Common, GroupTag.GroupA)]
public class GroupAMethods : IDebugger
{
    [DescribeAttribute("无参数函数示例", "No Parameter Method")]
    [MethodNameAttribute("函数名称 1", "Method Name 1")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupA1)]
    public void Method1()
    {
        Debug.Log("GroupAMethods.Method1 is excuted.");
    }

    [DescribeAttribute("单一参数函数示例", "One Parameter Method")]
    [MethodNameAttribute("函数名称 2", "Method Name 2")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupA2)]
    [ParameterAttribute(1)]
    public void Method2(int p)
    {
        Debug.Log($"GroupAMethods.Method2 is excuted. paramter value is {p}");
    }

    [DescribeAttribute("多参数函数示例", "Parameters Method")]
    [MethodNameAttribute("函数名称 3", "Method Name 3")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupA3)]
    [ParameterAttribute(3)]
    public void Method3(int p1, string p2, long p3)
    {
        Debug.Log($"GroupAMethods.Method3 is excuted. p1 = {p1}, p2 = {p2}, p3 = {p3}");
    }
}

 ```
运行编辑器的时候我们就能看到界面上出现了 `GroupA`分组，以及分组下会有三个按钮分别对应 `Method1`、`Method2`、`Method3`,选中操作后，点击执行按钮即可触发对应的调试函数。
