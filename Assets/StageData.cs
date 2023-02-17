using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject
{
    public List<PopData> dataList;
}

[Serializable]
public class PopData
{
    public string memo;
    public int id;
}
