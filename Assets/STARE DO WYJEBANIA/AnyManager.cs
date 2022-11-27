using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnyManager : MonoBehaviour
{
    public static AnyManager anyManager;
    bool gameStart;
    [SerializeField] int scenaStartowa = 1;

    private void Awake()
    {
        if (!gameStart)
        {
            anyManager = this;
            SceneManager.LoadSceneAsync(scenaStartowa, LoadSceneMode.Additive);
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
