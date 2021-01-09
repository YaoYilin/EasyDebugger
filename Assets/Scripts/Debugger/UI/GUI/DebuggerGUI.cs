//==================================================
// Copyright © 2020-2021 Yao Yilin. All rights reserved.
// @Author: YaoYilin
// @Description: 简易的 GUI 示例。
// 反馈: mailto:yaoyilin@sina.cn
//==================================================

using System.Collections.Generic;
using UnityEngine;
using Debugger;
using System.Reflection;

public class DebuggerGUI : MonoBehaviour
{
    private List<string> groupNames = new List<string>();
    private List<string> methodNames = new List<string>();
    private List<string> paramaters = new List<string>();
    private int checkedGroup = -1;
    private int checkedMethod = 0;
    private int CheckedGroup
    {
        get
        {
            return checkedGroup;
        }
        set
        {
            if (value < 0)
            {
                checkedGroup = value;
                return;
            }
            if (checkedGroup != value)
            {
                methodNames.Clear();
                checkedMethod = -1;
                DebuggerGroup group = groups[value];
                for (int i = 0; i < group.Elements.Count; i++)
                {
                    methodNames.Add(group.Elements[i].MethodName);
                }
                checkedMethod = 0;
            }
            checkedGroup = value;
        }
    }

    private int CheckedMethod
    {
        get
        {
            return checkedMethod;
        }
        set
        {
            if (value < 0)
            {
                checkedMethod = value;
                return;
            }

            DebuggerGroup group = groups[CheckedGroup];
            DebuggerElement method = group.Elements[value];
            paramaters.Clear();
            for (int i = 0; i < method.ParameterCount; i++)
            {
                paramaters.Add("");
            }
            checkedMethod = value;
        }
    }

    List<DebuggerGroup> groups;
    void Start()
    {
        groups = DebuggerUtility.GetGroups();
        groups.Sort((a, b) => a.Layout.Priority > b.Layout.Priority ? 1 : 0);
        for (int i = 0; i < groups.Count; i++)
        {
            groupNames.Add(groups[i].GroupName);
        }
        CheckedGroup = 0;
    }

    void OnGUI()
    {
        GUI.BeginGroup(new Rect(10, 10, Screen.width - 10, Screen.height - 20));
        {
            GUILayout.BeginHorizontal("box", GUILayout.Width(Screen.width - 20), GUILayout.Height(Screen.height - 20));
            {
                GUILayout.Space(5);
                groupPosition = GUILayout.BeginScrollView(groupPosition, "box", GUILayout.Width(Screen.width / 3), GUILayout.Height(Screen.height - 30));
                {
                    CheckedGroup = GUILayout.SelectionGrid(CheckedGroup, groupNames.ToArray(), 1);
                }
                GUILayout.EndScrollView();

                GUILayout.BeginVertical("box", GUILayout.Width(Screen.width / 3 * 2 - 50), GUILayout.Height(Screen.height - 30));
                {
                    methodPosition = GUILayout.BeginScrollView(methodPosition, "box", GUILayout.Width(Screen.width / 3 * 2 - 50), GUILayout.Height(Screen.height / 3 * 2 - 30));
                    {
                        CheckedMethod = GUILayout.SelectionGrid(CheckedMethod, methodNames.ToArray(), 3);
                    }
                    GUILayout.EndScrollView();

                    GUILayout.Space(5);

                    DebuggerGroup group = groups[CheckedGroup];
                    group.Sort();
                    DebuggerElement method = group.Elements[CheckedMethod];
                    GUILayout.BeginHorizontal();
                    {
                        paramaterPosition = GUILayout.BeginScrollView(paramaterPosition, "box", GUILayout.Width((Screen.width / 3 * 2 - 50) / 2 - 5), GUILayout.Height(Screen.height / 3 - 20));
                        {
                            if (method.ParameterCount > 0)
                            {
                                for (int i = 0; i < method.ParameterCount && paramaters.Count == method.ParameterCount; i++)
                                {
                                    GUILayout.BeginHorizontal();
                                    {
                                        ParameterInfo[] infos = method.MethodInfo.GetParameters();
                                        ParameterInfo info = infos[i];
                                        GUILayout.Label($"Parameter {i + 1} : [{info.ParameterType.Name}]", GUILayout.Width(140));
                                        GUILayout.Space(5);

                                        paramaters[i] = GUILayout.TextField(paramaters[i]);
                                    }
                                    GUILayout.EndHorizontal();
                                }
                            }
                            else
                            {
                                GUILayout.Label("No Parameters.");
                            }
                        }
                        GUILayout.EndScrollView();

                        GUILayout.Space(5);

                        GUILayout.BeginVertical("box", GUILayout.Width((Screen.width / 3 * 2 - 50) / 2 - 5), GUILayout.Height(Screen.height / 3 - 20));
                        {
                            GUILayout.Label(method.Describe, GUILayout.Height(Screen.height / 3 - 50));
                            if (GUILayout.Button("Excute"))
                            {
                                if (method.ParameterCount > 0)
                                {
                                    List<object> list = new List<object>();
                                    ParameterInfo[] infos = method.MethodInfo.GetParameters();
                                    for (int i = 0; i < paramaters.Count; i++)
                                    {
                                        list.Add(DebuggerUtility.ParseParamater(infos[i], paramaters[i]));
                                    }
                                    method.Invoke(list.ToArray());
                                }
                                else
                                {
                                    method.Invoke(null);
                                }
                            }
                        }
                        GUILayout.EndVertical();
                    }
                    GUILayout.EndHorizontal();
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();
        }
        GUI.EndGroup();
    }

    private Vector2 groupPosition = Vector2.zero;
    private Vector2 methodPosition = Vector2.zero;
    private Vector2 paramaterPosition = Vector2.zero;
}
