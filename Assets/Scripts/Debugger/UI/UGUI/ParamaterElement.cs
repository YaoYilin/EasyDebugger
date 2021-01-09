//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 输入参数元素。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace Debugger
{
    public class ParamaterElement : DebuggerBaseElement
    {
        [SerializeField] private Text title;
        [SerializeField] private InputField inputField;

        private ParamaterData data;

        public override DebuggerBaseElement SetData(IDebuggerData data)
        {
            this.data = data as ParamaterData;
            var infos = this.data.Data.MethodInfo.GetParameters();
            ParameterInfo info = infos[this.data.Index];
            title.text = $"Parameter {this.data.Index + 1} : [{info.ParameterType.Name}]";
            return this;
        }

        public object GetParamater()
        {
            ParameterInfo[] infos = data.Data.MethodInfo.GetParameters();
            string value = inputField.text;
            ParameterInfo info = infos[data.Index];
            return DebuggerUtility.ParseParamater(info, value);
        }
    }
}