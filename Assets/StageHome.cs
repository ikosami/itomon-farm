using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHome : Stage
{

    public override void Init()
    {
        var list = MonsterManager.Instance.monsterList;
        for (int i = 0; i < list.Count; i++)
        {
            var id = list[i];
            RandomPop(id);
        }
    }
}
