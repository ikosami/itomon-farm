using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stage : MonoBehaviour
{
    List<Monster> monsterList = new List<Monster>();
    public StageKind kind;

    public virtual void Init()
    {
    }

    protected void RandomPop(int id)
    {
        var monsterPrefab = MonsterManager.Instance.monsterPrefab;
        var monster = Instantiate(monsterPrefab, transform);
        monster.SetID(id);
        monster.rect.anchoredPosition = new Vector2(Random.Range(-400, 400), Random.Range(-600, 600));

        monsterList.Add(monster);
    }

    public void OnDisable()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            Destroy(monsterList[0].gameObject);
            monsterList.RemoveAt(0);
        }
    }
}
