using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unload : MonoBehaviour
{
    [SerializeField] int sceneNumber;

    bool x = true;


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (x)
        {
            if (collision.tag == "Player")
            {
                AnyManager.anyManager.UnloadScean(sceneNumber);
                x = false;
            }
            
        }
    }
}
