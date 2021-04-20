using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bose : MonoBehaviour
{
    public int Hp;
    public float Speed;
    private float Damaged = 2.0f;
    //   private float MaxHp;
    public GameObject prfhBar;
    public GameObject canvas;

    public float height = 1.7f;
   
    RectTransform Hpbar;

    private void Start()
    {
        Hpbar = Instantiate(prfhBar, canvas.transform).GetComponent<RectTransform>();

       // MaxHp = Hp;
    }

    void Update()
    {
        Vector3 _hpBarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        Hpbar.position = _hpBarPos;       
    }

    public void Monster_Damaged(int _dmg)
    {
        Hp -= _dmg;

       // HPbar.fillAmount = Hp / MaxHp;

        if (Hp <= 0)
            DestroyGameObject();
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }

}
