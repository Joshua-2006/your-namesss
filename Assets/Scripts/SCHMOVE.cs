using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCHMOVE : MonoBehaviour
{
    public GameObject place;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            transform.position = place.transform.position;
        }
       
    }
}
