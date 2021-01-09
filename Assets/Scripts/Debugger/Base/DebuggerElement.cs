//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 布局元素
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;
using System.Reflection;
using UnityEngine;

namespace Debugger
{
    public class DebuggerElement : IDebuggerData
    {
        public static SystemLanguage Language { get; set; } = SystemLanguage.English;
        public Type ExcuteType { get; private set; }
        public MethodInfo MethodInfo { get; private set; }
        public GroupLayoutAttribute Layout { get; private set; }

        public bool IsObsolete { get; private set; }
        public int Priority { get; private set; }
        public DebuggerElement(Type type, MethodInfo methodInfo, GroupLayoutAttribute layoutAttribute)
        {
            ExcuteType = type;
            MethodInfo = methodInfo;
            Layout = layoutAttribute;
            foreach (Attribute attribute in MethodInfo.GetCustomAttributes())
            {
                if (attribute is MethodLayoutAttribute)
                {
                    MethodLayoutAttribute a = (MethodLayoutAttribute)attribute;
                    IsObsolete = a.IsObsolete;
                    Priority = a.Priority;
                    break;
                }
            }
        }

        private string methodName = null;

        public string MethodName
        {
            get
            {
                if (discribe == null)
                {
                    methodName = ExcuteType.Name;
                    foreach (Attribute attribute in MethodInfo.GetCustomAttributes())
                    {
                        if (attribute is MethodNameAttribute)
                        {
                            MethodNameAttribute a = (MethodNameAttribute)attribute;
                            methodName = Language == SystemLanguage.English ? a.English : a.Chinese;
                            break;
                        }
                    }
                }

                return methodName;
            }
        }

        private string discribe = null;

        public string Describe
        {
            get
            {
                if (discribe == null)
                {
                    discribe = ExcuteType.ToString();
                    foreach (Attribute attribute in MethodInfo.GetCustomAttributes())
                    {
                        if (attribute is DescribeAttribute)
                        {
                            DescribeAttribute a = (DescribeAttribute)attribute;
                            discribe = Language == SystemLanguage.English ? a.English : a.Chinese;
                            break;
                        }
                    }
                }

                return discribe;
            }
        }

        private int parameterCount = -1;

        public uint ParameterCount
        {
            get
            {
                if (parameterCount < 0)
                {
                    parameterCount = 0;
                    foreach (Attribute attribute in MethodInfo.GetCustomAttributes())
                    {
                        if (attribute is ParameterAttribute)
                        {
                            var parameterAttribute = (ParameterAttribute)attribute;
                            parameterCount = (int)parameterAttribute.Count;
                            break;
                        }
                    }
                }

                return (uint)parameterCount;
            }
        }

        public void Invoke(object[] parameters)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            object obj = assembly.CreateInstance(ExcuteType.FullName);

            if (ParameterCount <= 0)
            {
                MethodInfo.Invoke(obj, null);
            }
            else
            {
                if (parameters == null || parameters.Length != ParameterCount)
                {
                    Debug.LogError("error invoke, parameter not match..");
                }
                else
                {
                    MethodInfo.Invoke(obj, parameters);
                }
            }
        }
    }
}