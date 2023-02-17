using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageField : Stage
{
    public StageData stageData;

    public override void Init()
    {
        int i = Random.Range(0, stageData.dataList.Count);
        var id = stageData.dataList[i].id;
        var monsterPrefab = MonsterManager.Instance.monsterPrefab;
        var monster = Instantiate(monsterPrefab, transform);
        monster.SetID(id);
        monster.rect.anchoredPosition = new Vector2(Random.Range(-400, 400), Random.Range(-600, 600));
    }
}
