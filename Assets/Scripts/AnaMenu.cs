using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AnaMenu : MonoBehaviour
{
    public Button playBtn, quitBtn; 
    Text text1;
    public void Start()
    {

    }

    public void Playy()
    {
        SceneManager.LoadScene("Islemler");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
   

}

