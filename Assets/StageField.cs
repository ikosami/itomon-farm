using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageField : Stage
{
    public StageData stageData;

    public override void Init()
    {
        for (int i = 0; i < 5; i++)
        {
            int kind = Random.Range(0, stageData.dataList.Count);
            var id = stageData.dataList[kind].id;
            RandomPop(id);
        }
    }
}
