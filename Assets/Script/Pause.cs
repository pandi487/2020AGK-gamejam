using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject PauseUI;

    private bool Paused = false;

    // Use this for initialization
    void Start()
    {
        PauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Paused = !Paused;
        }
        if (Paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!Paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void ReSume()
    {
        Paused = !Paused;
    }
  

}
