using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public Item() { }
    public Item(string _name, Property _property, int _count = 1)
    {
        item_Name = _name;
        item_Count = _count;
        property = _property;
    }

    public enum Property
    {
        Normal,
        Upgrade,
        Knockback,
        Stun,
    }

    private void Start()
    {
        //BackPack.Instance.AddItem(this);
/*        Debug.Log(item_Count);*/
    }

    public string item_Name;
    public int item_Count;
    public Property property;
}
