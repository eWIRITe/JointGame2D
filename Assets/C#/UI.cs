using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UI : MonoBehaviour
{
    public int NumberMainScene;

    private float Timer;

    public TMP_Text MainTime;

    public TMP_Text MinTimeEverOnWinCanv;

    public TMP_Text NowTimeOnWinCanv;

    public string SavedName;
    private bool first = true;

    private void FixedUpdate()
    {
        Timer += Time.deltaTime;
        MainTime.text = Math.Round(Timer, 1).ToString();
        if (NowTimeOnWinCanv.IsActive())
        {
            if (first)
            {
                SetTimes();
            }
        }
    }

    void SetTimes()
    {
        float MinTime = PlayerPrefs.GetFloat(SavedName);
        if (MinTime == 0 || MinTime >= Timer) MinTime = Timer;
        PlayerPrefs.SetFloat(SavedName, MinTime);

        MinTimeEverOnWinCanv.text = MinTime.ToString();
        NowTimeOnWinCanv.text = Timer.ToString();
        first = false;
    }

    public void OnRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnMainButton()
    {
        SceneManager.LoadScene(NumberMainScene);
    }
}
