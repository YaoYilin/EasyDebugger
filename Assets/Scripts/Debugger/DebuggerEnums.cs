//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 部分枚举。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

namespace Debugger
{
    /// <summary>
    /// 页签
    /// </summary>
    public enum GroupTag
    {
        Common,

        GroupA,
        GroupB,
        GroupC
    }

    // 布局优先级。
    public static class LayoutGroupPriority
    {
        public const int Common = 1;
        public const int Group1 = 10;
        public const int Group2 = 20;
    }

    public static class LayoutMethodPriority
    {
        public const int Common = 0;

        public const int GroupA1 = 10;
        public const int GroupA2 = 11;
        public const int GroupA3 = 20;

        public const int GroupB1 = 1000;
        public const int GroupB2 = 1001;
        public const int GroupB3 = 1002;

        public const int GroupC1 = 2000;
        public const int GroupC2 = 2010;
    }
}
