using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public RectTransform rect;
    public Image image;
    public Button button;

    int id;
    int moveState = 0;
    float moveTimer = 0;
    Vector2 moveStartPos;
    Vector2 movePos;

    private void Start()
    {
        moveTimer = Random.Range(0, 1f);
        button.onClick.AddListener(() =>
        {
            if (moveState != 2)
            {
                if (StageManager.Instance.nowStage.kind == StageKind.Home)
                {

                }
                else
                {
                    MonsterManager.Instance.monsterList.Add(id);
                    moveState = 2;
                    SetLeft(true);
                }
            }
        });
    }

    private void Update()
    {
        switch (moveState)
        {
            case 0:
                {
                    moveTimer += Time.deltaTime / 5;
                    moveStartPos = rect.anchoredPosition;
                    break;
                }
            case 1:
                {
                    moveTimer += Time.deltaTime / 3;
                    rect.anchoredPosition = Vector2.Lerp(moveStartPos, movePos, moveTimer);
                    break;
                }
            case 2:
                {
                    rect.anchoredPosition += new Vector2(-10, 0);
                    break;
                }
        }
        if (moveTimer >= 1)
        {
            switch (moveState)
            {
                case 0:
                    {
                        movePos = new Vector2(Random.Range(-400, 400), Random.Range(-600, 600));
                        SetLeft(rect.anchoredPosition.x > movePos.x);
                        break;
                    }
                case 1:
                    {
                        break;
                    }
            }
            moveTimer = 0;
            moveState = (moveState + 1) % 2;
        }
    }

    public void SetID(int id)
    {
        this.id = id;
        var sprite = MonsterManager.Instance.monsterAtlas.GetSprite("m" + id);
        image.sprite = sprite;
    }

    public void SetLeft(bool isRight)
    {
        var scale = rect.transform.localScale;
        scale.x = isRight ? 1 : -1;
        rect.transform.localScale = scale;
    }
}
