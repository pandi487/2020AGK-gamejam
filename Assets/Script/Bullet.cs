using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Item
{
    public Bullet() { }
    public Bullet(Vector3 _dir) { dir = _dir; }

    public Vector3 dir;
    public float speed;

/*    public void SetBulletDir(Vector3 _dir)
    {
        dir = _dir;
    }*/

    private void Start()
    {
        transform.position = GameObject.Find("Player").transform.position;
        Destroy(gameObject, 0.2f);
    }

    private void Update()
    {
/*        Debug.Log(dir);*/
        transform.Translate(new Vector3(dir.x, dir.y, 1) * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            var tempMonster = collision.gameObject.GetComponent<Monster>();
            var tempAttack = GameObject.Find("AttackRange").GetComponent<Attack>();
            var tempProperty = BackPack.Instance.FindItem(property);

            if (tempProperty != null)
            {
                tempProperty.item_Count--;
                Debug.Log($"{tempProperty.item_Count} property count");

                if (property == Property.Knockback)
                {
                    tempMonster.Hp -= (int)(tempAttack.player_Damage * 0.8f);
                }
                if (property == Property.Normal)
                {
                    tempMonster.Hp -= (int)(tempAttack.player_Damage);
                }
                if (property == Property.Stun)
                {
                    tempMonster.Hp -= (int)(tempAttack.player_Damage);
                }
                if (property == Property.Upgrade)
                {
                    tempMonster.Hp -= (int)(tempAttack.player_Damage * 1.2f);
                }
                Debug.Log("damaged");
            }

            Destroy(gameObject);
        }
    }
}
