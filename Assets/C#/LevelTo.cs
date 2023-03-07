using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTo : MonoBehaviour
{
    public void ToLevel(int NumberOfScene)
    {
        SceneManager.LoadScene(NumberOfScene);
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(1);
    }
}
