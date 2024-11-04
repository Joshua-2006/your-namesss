using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    private float horizontalInput;
    private float verticalInput;
    public GameObject GUNIcon;
    private bool pickUpAllowed;
    public GameObject GUN;
    public GameObject cookie;
    public GameObject enemy;
    public float j;
    public bool dead;
    public Sprite sprite;
    public Sprite sprite2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);
        
        if (Input.GetButtonDown("Drop") && GUNIcon.activeInHierarchy )
        {
            Instantiate(cookie, transform.position, transform.rotation);
            GUNIcon.SetActive(false);
        }
        if (pickUpAllowed && Input.GetButtonDown("Pickup"))
        {
            PickUp();
        }
        if (Input.GetButtonDown("Left Trigger"))
        {
            speed = 3f;
        }
        else if(Input.GetButtonUp("Left Trigger"))
        {
            speed = 2f;
        }
         if(enemy.activeInHierarchy)
         {
            dead = false;
         }
         if(dead == true)
        {
            StartCoroutine(one());
        }
    }
    IEnumerator one()
    {
        yield return new WaitForSeconds(j);
        enemy.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            pickUpAllowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gun"))
        {
            pickUpAllowed = false;
        }
    }
    private void PickUp()
    {
        GUN.SetActive(false);
        GUNIcon.SetActive(true);
    }
}
