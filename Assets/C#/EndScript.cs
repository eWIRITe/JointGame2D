using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject WinCanv;
    public GameObject LoseCanv;
    public GameObject MainCanv;

    public bool WinScr;

    private void Start()
    {
        WinCanv.SetActive(false);
        LoseCanv.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (WinScr) OnWin();
            else OnLose();

            MainCanv.SetActive(false);
        }
    }

    void OnLose()
    {
        LoseCanv.SetActive(true);
    }

    void OnWin()
    {
        WinCanv.SetActive(true);
    }
}
