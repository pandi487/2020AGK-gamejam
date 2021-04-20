using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public List<GameObject> lifes = new List<GameObject>();

    int hp;
    
    void Start()
    {

    }

    void Update()
    {
        hp = GameObject.Find("Player").GetComponent<PlayerControl>().player_Hp;

        lifes[hp].GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprites/Ingame/HeartGray");
    }
}
