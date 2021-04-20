using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ButtonManager : MonoBehaviour
{
    public void ChangeSecene1() //TitleSecene
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeSecene2() //SampleSecene
    {
        SceneManager.LoadScene(1);
    }
    public GameObject Button;

    public void changeMonsterOn(string changeToOn)
    {
        Button.SetActive(true);
    }
    public void changeMonsterOff(string changeToOff)
    {
        Button.SetActive(false);

    }
    public void TimeStop()
    {
        Time.timeScale = 0;
    }    
    public void TimeStart()
    {
        Time.timeScale = 1;
    }
}
