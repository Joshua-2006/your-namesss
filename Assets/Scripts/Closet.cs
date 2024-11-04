using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class Closet : MonoBehaviour
{
    public UnityEvent open;
    public UnityEvent closed;
    public UnityEvent five;
    public bool openSesame;
    [SerializeField] GameObject enemy;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Closet") && collision.gameObject.CompareTag("Player") && openSesame == false)
        {
            openSesame = true;
           enemy.GetComponent<Enemy>().navMesh = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("Closet") && collision.gameObject.CompareTag("Player") && openSesame == false)
         {
            openSesame = true;
            enemy.GetComponent<Enemy>().navMesh = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CompareTag("Closet") && collision.gameObject.CompareTag("Player") && openSesame == true)
        {
            openSesame = false;
            enemy.GetComponent<Enemy>().navMesh = true;
        }
    }
    private void Update()
    {
        if (openSesame == true)
        {
            open.Invoke();
            one();
            five.Invoke();
        }
        else if (openSesame == false)
        {
            closed.Invoke();
        }
    }
    IEnumerator one()
    {
        yield return new WaitForSeconds(1);
    }
}
