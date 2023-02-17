using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMoveButton : MonoBehaviour
{
    public StageKind stageKind;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {
            StageManager.Instance.ChangeStage(stageKind);
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
