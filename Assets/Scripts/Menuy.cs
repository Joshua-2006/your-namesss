using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuy : MonoBehaviour
{
    public void Apple()
    {
        SceneManager.LoadScene("Your Name");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Retry()
    {
     SceneManager.LoadScene("Your Name"); 
    }    
    public void Retry2()
    {
        SceneManager.LoadScene("2");
    }    
    public void Retry3()
    {
        SceneManager.LoadScene("3");
    }
}
