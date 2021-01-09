//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 分组。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Collections.Generic;

namespace Debugger
{
    public class DebuggerGroup : IDebuggerData
    {
        public DebuggerGroup(GroupTag groupTag, GroupLayoutAttribute layoutAttribute)
        {
            this.groupTag = groupTag;
            GroupName = this.groupTag.ToString();
            Layout = layoutAttribute;
        }

        private GroupTag groupTag;
        public string GroupName { get; private set; }
        public List<DebuggerElement> Elements = new List<DebuggerElement>();

        public GroupLayoutAttribute Layout { get; private set; }

        public List<DebuggerElement> Sort()
        {
            Elements.Sort((a, b) =>
            {
                if (a.IsObsolete != b.IsObsolete)
                {
                    return a.IsObsolete ? 0 : 1;
                }
                else
                {
                    return a.Priority > b.Priority ? 1 : 0;
                }
            });
            return Elements;
        }
    }
}