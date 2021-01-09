using Debugger;
using UnityEngine;

[GroupLayoutAttribute(LayoutGroupPriority.Group1, GroupTag.GroupB)]
public class GroupBMethods : IDebugger
{
    [DescribeAttribute("GroupB 无参数函数示例", "[GroupB] No Parameter <color=red>Method</color>")]
    [MethodNameAttribute("函数名称 1", "Method Name 1")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupB3)]
    public void Method1()
    {
        Debug.Log("GroupAMethods.Method1 is excuted.");
    }

    //[GroupLayoutAttribute(LayoutGroupPriority.Group1, GroupTag.GroupB)]
    [DescribeAttribute("单一参数函数示例", "One Parameter Method")]
    [MethodNameAttribute("函数名称 2", "Method Name 2")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupB2)]
    [ParameterAttribute(1)]
    public void Method2(int p)
    {
        Debug.Log($"GroupAMethods.Method2 is excuted. paramter value is {p}");
    }

    //[GroupLayoutAttribute(LayoutGroupPriority.Group1, GroupTag.GroupB)]
    [DescribeAttribute("多参数函数示例", "Parameters Method")]
    [MethodNameAttribute("函数名称 3", "Method Name 3")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupB1)]
    [ParameterAttribute(3)]
    public void Method3(int p1, string p2, long p3)
    {
        Debug.Log($"GroupAMethods.Method3 is excuted. p1 = {p1}, p2 = {p2}, p3 = {p3}");
    }
}
