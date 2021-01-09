//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 方法显示元素。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Debugger
{
    public class MethodElement : DebuggerBaseElement
    {
        public Toggle GroupToggle;
        public Text ToggleText;

        [NonSerialized] public DebuggerElement MethodData;
        private UnityAction<DebuggerBaseElement> OnToggle;

        public override DebuggerBaseElement SetData(IDebuggerData data)
        {
            base.SetData(data);
            MethodData = data as DebuggerElement;
            ToggleText.text = MethodData.MethodName;
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