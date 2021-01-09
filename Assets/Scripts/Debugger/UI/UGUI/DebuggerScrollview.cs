//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 简易滚动列表。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Debugger
{
    public class DebuggerScrollview : MonoBehaviour
    {
        /// <summary>
        /// 滑动区域。
        /// </summary>
        public ScrollRect ScrollRect;

        /// <summary>
        /// 容器。
        /// </summary>
        public LayoutGroup Group;

        /// <summary>
        /// 模板。
        /// </summary>
        public DebuggerBaseElement Templete;

        protected List<IDebuggerData> Data = new List<IDebuggerData>();

        private Queue<DebuggerBaseElement> objectPool = new Queue<DebuggerBaseElement>();
        private List<DebuggerBaseElement> showingElements = new List<DebuggerBaseElement>();

        public void Initialize()
        {
            Recycle();
            Templete.gameObject.SetActive(false);
        }

        public void SetData(List<IDebuggerData> data)
        {
            foreach (var item in Data)
            {
                AddData(item);
            }
        }

        public List<DebuggerBaseElement> GetElements()
        {
            return showingElements;
        }

        public DebuggerBaseElement AddData(IDebuggerData data)
        {
            Data.Add(data);
            DebuggerBaseElement element = CreateElement();
            element.SetData(data);
            element.transform.SetSiblingIndex(Data.Count);
            element.gameObject.SetActive(true);
            showingElements.Add(element);
            return element;
        }

        public void Recycle()
        {
            foreach (DebuggerBaseElement item in showingElements)
            {
                item.OnRecycle();
                item.gameObject.SetActive(false);
                objectPool.Enqueue(item);
            }
            showingElements.Clear();
        }
        
        private DebuggerBaseElement CreateElement()
        {
            DebuggerBaseElement element;
            if (objectPool.Count <= 0)
            {
                element = Instantiate(Templete);
                element.transform.SetParent(Templete.transform.parent);
                element.transform.localPosition = Vector3.zero;
                element.transform.localScale = Vector3.one;
            }
            else
            {
                element = objectPool.Dequeue();
            }
            return element;
        }
    }
}
