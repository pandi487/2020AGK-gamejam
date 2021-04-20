using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float Hp;
    public float Speed;

    bool isStun = false;

    float dis;

    private void Update()
    {
        if(!isStun)
        {
            Monster_Move();
        }
    }

    public void Monster_Move()
    {
        dis = Vector3.Distance(transform.position, GameObject.Find("Player").transform.position);
/*        Debug.Log(dis);*/
        if (dis < 50)
        {
            transform.Translate((GameObject.Find("Player").transform.position - transform.position) * Speed * Time.deltaTime);
        }
    }

    public void Monster_KnockBack()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce((GameObject.Find("Player").transform.position - gameObject.transform.position) * -100);
    }

    public void Monster_Stun(bool _is)
    {
        isStun = _is;
    }

    public void Monster_Damaged(int _dmg)
    {
        Hp -= _dmg;
        if (Hp <= 0)
            Monster_Destroy();
    }

    public void Monster_Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}