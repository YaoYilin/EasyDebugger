////==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: Debugger 组。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Debugger
{
    public class GroupElement : DebuggerBaseElement
    {
        public Toggle GroupToggle;
        public Text ToggleText;

        [NonSerialized] public DebuggerGroup GroupData;
        private UnityAction<DebuggerBaseElement> OnToggle;

        public override DebuggerBaseElement SetData(IDebuggerData data)
        {
            base.SetData(data);
            GroupData = data as DebuggerGroup;
            ToggleText.text = GroupData.GroupName;
            GroupToggle.onValueChanged.AddListener((isOn) =>
            {
                if (isOn)
                {
                    OnToggle?.Invoke(this);
                }
            });
            return this;
        }

        public override void SetAction(UnityAction<DebuggerBaseElement> action)
        {
            OnToggle = action;
        }

        public override void OnRecycle()
        {
            GroupToggle.isOn = false;
        }
    }
}