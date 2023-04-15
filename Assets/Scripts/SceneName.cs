using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class SceneName : PropertyAttribute
{
    public SceneName() { }
}