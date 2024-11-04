using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform place;
    [SerializeField] Transform place2;
   
    NavMeshAgent agent;
    public bool navMesh;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        navMesh = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh == false)
        {
            if(transform.position.y < 30)
            {
                agent.SetDestination(place.position);
            }
            else if(transform.position.y > 30)
            {
                agent.SetDestination(place2.position);
            }
            
        }
        else if(navMesh == true)
        {
            agent.SetDestination(target.position);
        }

       
    }
    private void OnDisable()
    {
        
        target.GetComponent<Movement>().dead = true;
       
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            if(SceneManager.GetActiveScene().name == "Your Name")
            {
                SceneManager.LoadScene("Game Over");
            }
            else if (SceneManager.GetActiveScene().name == "2")
            {
                SceneManager.LoadScene("Game Over 1");
            }
            else if (SceneManager.GetActiveScene().name == "3")
            {
                SceneManager.LoadScene("Game Over 2");
            }
        }
    }
    
}
