//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 方法布局属性。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;

namespace Debugger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class MethodLayoutAttribute : Attribute
    {
        public int Priority { get; private set; }
        public bool IsObsolete { get; private set; }
        public MethodLayoutAttribute(int priority, bool isObsolete = false)
        {
            Priority = priority;
            IsObsolete = isObsolete;
        }
    }
}

