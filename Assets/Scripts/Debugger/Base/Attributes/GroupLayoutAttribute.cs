//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 功能组布局属性。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;

namespace Debugger
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class GroupLayoutAttribute : Attribute
    {
        public int Priority { get; private set; }
        public GroupTag Group { get; private set; }

        public GroupLayoutAttribute(int priority, GroupTag group)
        {
            Priority = priority;
            Group = group;
        }
    }
}
