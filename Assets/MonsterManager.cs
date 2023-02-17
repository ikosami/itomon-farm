using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class MonsterManager : MonoBehaviour
{
    private static MonsterManager instance;
    public static MonsterManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<MonsterManager>();
            }
            return instance;
        }
    }
    public SpriteAtlas monsterAtlas;
    public Monster monsterPrefab;
}
