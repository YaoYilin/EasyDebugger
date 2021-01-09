//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 描述属性。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;

namespace Debugger
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Class)]
    public class DescribeAttribute : Attribute
    {
        public string English { get; private set; }
        public string Chinese { get; private set; }
        public DescribeAttribute(string chinese, string english)
        {
            Chinese = chinese;
            English = english;
        }
    }
}
