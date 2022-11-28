using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private Rigidbody2D body;
    public static DontDestroy instance;
    public PozycjaPostaci pozycjaStartowa;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        //transform.position = pozycjaStartowa.initialValue;
  
    }


}
