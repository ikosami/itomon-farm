using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private static StageManager instance;
    public static StageManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<StageManager>();
            }
            return instance;
        }
    }

    public List<Stage> stageList;
    public CanvasGroup fadeCanvas;

    private Stage nowStage;

    public void Awake()
    {
        nowStage = GetStage(StageKind.Home);
    }

    public Stage GetStage(StageKind stageKind)
    {
        for (int i = 0; i < stageList.Count; i++)
        {
            if (stageList[i].kind == stageKind)
            {
                return stageList[i];
            }
        }
        return stageList[0];
    }

    public void ChangeStage(StageKind stageKind)
    {
        StartCoroutine(ChangeStageIE(stageKind));
    }

    private IEnumerator ChangeStageIE(StageKind stageKind)
    {
        fadeCanvas.blocksRaycasts = true;
        float timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * 2;
            fadeCanvas.alpha = timer;
            yield return null;
        }

        fadeCanvas.alpha = 1;
        nowStage.gameObject.SetActive(false);
        nowStage = GetStage(stageKind);
        nowStage.gameObject.SetActive(true);
        nowStage.Init();

        timer = 0;
        while (timer < 1)
        {
            timer += Time.deltaTime * 2;
            fadeCanvas.alpha = 1 - timer;
            yield return null;
        }

        fadeCanvas.blocksRaycasts = false;
    }
}


public enum StageKind
{
    Home,
    Mori,
    Dou,
    Kakou,
    Mizu,
    Hai
}