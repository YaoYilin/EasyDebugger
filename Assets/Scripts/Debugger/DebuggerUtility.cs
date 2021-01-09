//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 工具类。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Debugger
{
    public static class DebuggerUtility
    {
        public static List<DebuggerGroup> GetGroups()
        {
            Dictionary<GroupTag, DebuggerGroup> groups = new Dictionary<GroupTag, DebuggerGroup>();
            Type[] types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes().Where(t => t.GetInterfaces().Contains(typeof(IDebugger)))).ToArray();
            foreach (Type type in types)
            {
                GroupLayoutAttribute attr = type.GetCustomAttribute<GroupLayoutAttribute>();
                if (attr == null)
                {
                    continue;
                }

                GroupTag tag = attr.Group;
                DebuggerGroup group;
                if (!groups.TryGetValue(tag, out group))
                {
                    group = new DebuggerGroup(tag, attr);
                    groups.Add(tag, group);
                }

                MethodInfo[] methods = type.GetMethods();
                foreach (MethodInfo method in methods)
                {
                    foreach (Attribute attribute in method.GetCustomAttributes())
                    {
                        if (attribute is MethodNameAttribute)
                        {
                            DebuggerElement element = new DebuggerElement(type, method, attr);
                            group.Elements.Add(element);
                        }
                    }
                }
            }

            return groups.Values.ToList();
        }

        public static object ParseParamater(ParameterInfo info, string value)
        {
            if (info.ParameterType == typeof(int))
            {
                int res;
                if (!int.TryParse(value, out res))
                {
                    Debug.LogError("parameter types not supported...");
                    return null;
                }

                return res;
            }

            if (info.ParameterType == typeof(long))
            {
                long res;
                if (!long.TryParse(value, out res))
                {
                    Debug.LogError("parameter types not supported...");
                    return null;
                }

                return res;
            }

            if (info.ParameterType == typeof(float))
            {
                float res;
                if (!float.TryParse(value, out res))
                {
                    Debug.LogError("parameter types not supported...");
                    return null;
                }

                return res;
            }
            if (info.ParameterType == typeof(uint))
            {
                uint res;
                if (!uint.TryParse(value, out res))
                {
                    Debug.LogError("parameter types not supported...");
                    return null;
                }

                return res;
            }

            if (info.ParameterType == typeof(ulong))
            {
                ulong res;
                if (!ulong.TryParse(value, out res))
                {
                    Debug.LogError("parameter types not supported...");
                    return null;
                }

                return res;
            }

            if (info.ParameterType == typeof(string))
            {
                return value;
            }

            if (info.ParameterType == typeof(string[]))
            {
                string[] array = value.Split(',');
                return array;
            }

            if (info.ParameterType == typeof(int[]))
            {
                string[] array = value.Split(',');
                List<int> res = new List<int>();
                foreach (string str in array)
                {
                    int v;
                    if (!int.TryParse(value, out v))
                    {
                        Debug.LogError("parameter types not supported...");
                        return null;
                    }
                    res.Add(v);
                }
                return res;
            }

            return null;
        }
    }
}