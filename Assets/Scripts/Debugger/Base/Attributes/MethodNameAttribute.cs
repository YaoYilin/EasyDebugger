//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 方法名称属性。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;

namespace Debugger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Class)]
    public class MethodNameAttribute : Attribute
    {
        public string English { get; private set; }
        public string Chinese { get; private set; }
        public MethodNameAttribute(string chinese, string english)
        {
            Chinese = chinese;
            English = english;
        }
    }
}
