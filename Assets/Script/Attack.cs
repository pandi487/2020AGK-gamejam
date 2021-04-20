using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    public int player_Damage;

    public int AttackType;

    public bool isMAttack = false;
    public bool isRAttack = false;

    int per;

    IEnumerator delay(Monster monster)
    {
        Debug.Log("delaied");
        yield return new WaitForSeconds(1.5f);
        monster.Monster_Stun(false);
        yield return null;
    }

    public bool StunAttack(Monster _monster)
    {
        Debug.Log("StunAttack");
        if (BackPack.Instance.FindItem(Item.Property.Stun).item_Count > 0)
        {
            per = Random.Range(0, 100);
            if(per >= 50)
                BackPack.Instance.FindItem(Item.Property.Stun).item_Count--;

            Debug.Log("Stun " + BackPack.Instance.FindItem(Item.Property.Stun).item_Count);

            _monster.Monster_Damaged((int)(player_Damage * 0.8f));
            _monster.Monster_Stun(true);
            StartCoroutine(delay(_monster));
            return true;
        }
        return false;
    }

    public bool KnockBackAttack(Monster _monster)
    {
        Debug.Log("KnockBackAttack");
        if (BackPack.Instance.FindItem(Item.Property.Knockback).item_Count > 0)
        {
            per = Random.Range(0, 100);
            if (per >= 50)
                BackPack.Instance.FindItem(Item.Property.Knockback).item_Count--;

            Debug.Log("KnockBack " + BackPack.Instance.FindItem(Item.Property.Knockback).item_Count);

            _monster.Monster_Damaged(player_Damage);
            _monster.Monster_KnockBack();

            return true;
        }
        return false;
    }

    public bool UpgradeAttack(Monster _monster)
    {
        Debug.Log("UpgradeAttack");
        if (BackPack.Instance.FindItem(Item.Property.Upgrade).item_Count > 0)
        {
            per = Random.Range(0, 100);
            if (per >= 50)
                BackPack.Instance.FindItem(Item.Property.Upgrade).item_Count--;

            Debug.Log("Upgrade " + BackPack.Instance.FindItem(Item.Property.Upgrade).item_Count);

            _monster.Monster_Damaged((int)(player_Damage * 1.2f));

            return true;
        }
        return false;
    }

    public bool NormalAttack(Monster _monster)
    {
        Debug.Log("NormalAttack");
        if (BackPack.Instance.FindItem(Item.Property.Normal).item_Count > 0)
        {
            per = Random.Range(0, 100);
            if (per >= 50)
                BackPack.Instance.FindItem(Item.Property.Normal).item_Count--;

            Debug.Log("Normal " + BackPack.Instance.FindItem(Item.Property.Normal).item_Count);

            _monster.Monster_Damaged(player_Damage);

            return true;
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if(isMAttack)
            {
                isMAttack = false;
                Debug.Log($"근접공격 attack type  {AttackType}");
                var tempEnemy = collision.gameObject.GetComponent<Monster>();

                switch (AttackType)
                {
                    case 1:
                        StunAttack(tempEnemy); //joystick 클릭할때
                        break;
                    case 2:
                        KnockBackAttack(tempEnemy); //joystick 클릭할때
                        break;
                    case 3:
                        UpgradeAttack(tempEnemy); //joystick 클릭할때
                        break;
                    case 4:
                        NormalAttack(tempEnemy); //joystick 클릭할때
                        break;
                }
            }
        }
    }

    public void MeleeAttack()
    {
        isMAttack = true;
    }

    public void RangeAttack()
    {
        isRAttack = true;
    }

    void Start()
    {

    }

    private void Update()
    {
        if (isRAttack)
        {
            isRAttack = false;
            Debug.Log("원거리공격");
        }
    }
}
