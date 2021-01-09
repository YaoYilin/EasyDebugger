//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 列表元素基类。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using UnityEngine;
using UnityEngine.Events;

namespace Debugger
{
    public class DebuggerBaseElement : MonoBehaviour
    {
        public virtual DebuggerBaseElement SetData(IDebuggerData data)
        {
            return this;
        }

        public virtual void SetAction(UnityAction<DebuggerBaseElement> action)
        {
            
        }

        public virtual void OnRecycle()
        {
            
        }
    }
}
