//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 简易 UGUI 示例。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Collections.Generic;
using UnityEngine;

namespace Debugger
{
    public partial class DebuggerUGUI : MonoBehaviour
    {
        public static bool IsDebugging = false;

        [SerializeField] private DebuggerScrollview groupScrollview;
        [SerializeField] private DebuggerScrollview methodScrollview;

        [SerializeField] private DescribeUI describe;

        private GroupElement checkedGroup;
        private MethodElement checkedMethod;

        private void Start()
        {
            IsDebugging = true;
            DebuggerElement.Language = SystemLanguage.Chinese;

            List<DebuggerGroup> groups = DebuggerUtility.GetGroups();
            groups.Sort((a, b) => a.Layout.Priority > b.Layout.Priority ? 1 : 0);
            groupScrollview.Initialize();
            methodScrollview.Initialize();
            foreach (DebuggerGroup group in groups)
            {
                DebuggerBaseElement element = groupScrollview.AddData(group);
                element.SetAction(OnToggleGroup);
            }

            if (groups.Count > 0)
            {
                checkedGroup = groupScrollview.GetElements()[0] as GroupElement;
                checkedGroup.GroupToggle.isOn = true;
                OnToggleGroup(checkedGroup);
            }
        }

        private void OnToggleGroup(DebuggerBaseElement element)
        {
            GroupElement group = element as GroupElement;
            methodScrollview.Recycle();
            group.GroupData.Sort();
            foreach (DebuggerElement elementData in group.GroupData.Elements)
            {
                DebuggerBaseElement ele = methodScrollview.AddData(elementData);
                ele.SetAction(OnToggleMethod);
            }

            if (group.GroupData.Elements.Count > 0)
            {
                checkedMethod = methodScrollview.GetElements()[0] as MethodElement;
                checkedMethod.GroupToggle.isOn = true;
                OnToggleMethod(checkedMethod);
            }
            checkedGroup = group;
        }

        private void OnToggleMethod(DebuggerBaseElement element)
        {
            MethodElement method = element as MethodElement;
            describe.SetData(method.MethodData);
            checkedMethod = method;
        }
    }
}