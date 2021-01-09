//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 描述的 UGUI实现。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Debugger
{
    public class DescribeUI : MonoBehaviour
    {
        [SerializeField] private DebuggerScrollview paramaters;
        [SerializeField] private Text discribe;
        [SerializeField] private Button excuteButton;

        [SerializeField] private Text hints;

        private DebuggerElement _data;

        void Start()
        {
            excuteButton.onClick.AddListener(OnClick);
            paramaters.Initialize();
            discribe.text = "";
        }

        private void OnClick()
        {
            List<object> list = new List<object>();
            foreach (DebuggerBaseElement element in paramaters.GetElements())
            {
                ParamaterElement param = element as ParamaterElement;
                list.Add(param.GetParamater());
            }

            if (list.Count > 0)
            {
                _data.Invoke(list.ToArray());
            }
            else
            {
                _data.Invoke(null);
            }
        }

        public void SetData(DebuggerElement data)
        {
            _data = data;
            if (data.IsObsolete)
            {
                discribe.text = $"<color=red>[Obsolete]</color> {data.Describe}";
                excuteButton.enabled = false;
            }
            else
            {
                discribe.text = data.Describe;
                excuteButton.enabled = true;
            }

            paramaters.Recycle();
            if (data.ParameterCount > 0)
            {
                paramaters.gameObject.SetActive(true);
                for (int i = 0; i < data.ParameterCount; i++)
                {
                    paramaters.AddData(new ParamaterData(i, data));
                }
                hints.text = "";
            }
            else
            {
                hints.text = "No Parameters";
            }
        }
    }

    public class ParamaterData : IDebuggerData
    {
        public int Index { get; private set; }
        public DebuggerElement Data { get; private set; }

        public ParamaterData(int index, DebuggerElement data)
        {
            Index = index;
            Data = data;
        }
    }
}