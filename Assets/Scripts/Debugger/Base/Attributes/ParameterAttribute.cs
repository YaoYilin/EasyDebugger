//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 方法参数属性。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;

namespace Debugger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Class)]
    public class ParameterAttribute : Attribute
    {
        public uint Count { get; private set; }

        public ParameterAttribute(uint count)
        {
            Count = count;
        }
    }
}
