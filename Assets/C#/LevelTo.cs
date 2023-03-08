using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.RemoteConfig;

public class LevelTo : MonoBehaviour
{
    public struct userAttributes { }
    public struct appAttributes { }

    public int PlaySceneNumber;

    void Awake()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(), new appAttributes());
    }

    public void ToLevel(int NumberOfScene)
    {
        SceneManager.LoadScene(NumberOfScene);
    }

    public void OnStartButton()
    {
        SceneManager.LoadScene(PlaySceneNumber);
    }
}
