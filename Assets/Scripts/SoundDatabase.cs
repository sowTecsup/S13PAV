using System;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
public enum SoundType
{
    Shoot,
    Jump,
    Hit,
    Death
}

[CreateAssetMenu(fileName = "SoundDatabase", menuName = "Scriptable Objects/SoundDatabase")]
public class SoundDatabase : ScriptableObject
{
   [ShowInInspector] public Dictionary<SoundType, string> lookup = new();
}
