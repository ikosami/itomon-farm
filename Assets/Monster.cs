using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public RectTransform rect;
    public Image image;

    int moveState = 0;
    float moveTimer = 0;
    Vector2 moveStartPos;
    Vector2 movePos;

    private void Start()
    {
        moveTimer = Random.Range(0, 1f);
    }

    private void Update()
    {
        switch (moveState)
        {
            case 0:
                {
                    moveTimer += Time.deltaTime / 5;
                    moveStartPos = rect.anchoredPosition;
                    movePos = new Vector2(Random.Range(-400, 400), Random.Range(-600, 600));
                    break;
                }
            case 1:
                {
                    moveTimer += Time.deltaTime / 5;
                    rect.anchoredPosition = Vector2.Lerp(moveStartPos, movePos, moveTimer);
                    break;
                }
        }
        if (moveTimer >= 1)
        {
            moveTimer = 0;
            moveState = (moveState + 1) % 2;
        }
    }

    public void SetID(int id)
    {
        var sprite = MonsterManager.Instance.monsterAtlas.GetSprite("m" + id);
        image.sprite = sprite;
    }
}
