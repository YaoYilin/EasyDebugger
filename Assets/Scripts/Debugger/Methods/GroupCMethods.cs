using Debugger;
using UnityEngine;

[GroupLayoutAttribute(LayoutGroupPriority.Group2, GroupTag.GroupC)]
public class GroupCMethods : IDebugger
{
    [DescribeAttribute("单一参数函数示例 这里可以写很长的描述，尽可能的详细一些。", "One Parameter Method. You can write more words to describe this method.")]
    [MethodNameAttribute("函数名称", "Method Name")]
    [MethodLayoutAttribute(LayoutMethodPriority.GroupC2)]
    [ParameterAttribute(1)]
    public void Method(int p)
    {
        Debug.Log($"GroupCMethods.Method2 is excuted. paramter value is {p}");
    }
}
