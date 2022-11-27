using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load : MonoBehaviour
{
    [SerializeField] int sceneNumber;


    bool x = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (x)
        {
            if (collision.tag == "Player")
            {
                SceneManager.LoadSceneAsync(sceneNumber, LoadSceneMode.Additive);
                x = false;
            }
                
        }
       
    }
}
