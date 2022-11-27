using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour {

    BoxCollider2D boxCollider2D;
    [SerializeField] float hpPoints = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy1Glista")
        {
            hpPoints = hpPoints - 25;
            Debug.Log("HP: {0}" + hpPoints);
        }

        if (hpPoints <= 0)
        {
            DestroyGameObject();
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
