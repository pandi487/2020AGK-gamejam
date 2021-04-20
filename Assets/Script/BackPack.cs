using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BackPack : Item
{
    BackPack() { }
    static readonly Lazy<BackPack> _instance = new Lazy<BackPack>(() => new BackPack());
    public static BackPack Instance { get { return _instance.Value; } }

    public List<Item> items = new List<Item>();

    public Text NormalCountText;
    public Text StunCountText;
    public Text KnockBackCountText;
    public Text UpgradeCountText;

    void Update()
    {
/*        //if (FindItem(Property.Normal) != null)
            NormalCountText.text = $"{FindItem(Property.Normal).item_Count}";

        //if (FindItem(Property.Stun) != null)
            StunCountText.text = $"{FindItem(Property.Stun).item_Count}";

        //if (FindItem(Property.Knockback) != null)
            KnockBackCountText.text = $"{FindItem(Property.Knockback).item_Count}";

        //if (FindItem(Property.Upgrade) != null)
            UpgradeCountText.text = $"{FindItem(Property.Upgrade).item_Count}";*/
    }

    public Item FirstItem()
    {
        return items.Count > 0 ? items[0] : null;
    }

    public void AddItem(Item _item)
    {
        if(FindItem(Property.Knockback) == null)
            items.Add(_item);
        else
            FindItem(Property.Knockback).item_Count += _item.item_Count;

        if (FindItem(Property.Stun) == null)
            items.Add(_item);
        else
            FindItem(Property.Stun).item_Count += _item.item_Count;

        if (FindItem(Property.Upgrade) == null)
            items.Add(_item);
        else
            FindItem(Property.Upgrade).item_Count += _item.item_Count;

        if (FindItem(Property.Normal) == null)
            items.Add(_item);
        else
            FindItem(Property.Normal).item_Count += _item.item_Count;
    }

    public Item FindItem(string _name)
    {
        foreach (var item in items)
        {
            if(item.item_Name == _name)
            {
                return item;
            }
        }
        return null;
    }
    public Item FindItem(Property _property)
    {
        foreach (var item in items)
        {
            if (item.property == _property)
            {
                return item;
            }
        }
        return null;
    }
}
