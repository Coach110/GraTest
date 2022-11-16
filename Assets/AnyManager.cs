using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{
    public static AnyManager anyManager;
    bool gameStart;

    private void Awake()
    {
        if (!gameStart)
        {
            anyManager = this;
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            gameStart = true;
        }
    }

    public void UnloadScean(int sceneNumber)
    {
        SceneManager.UnloadSceneAsync(sceneNumber);
    }

    IEnumerable Unload(int sceneNumber)
    {
        yield return null;
        
    }
}
