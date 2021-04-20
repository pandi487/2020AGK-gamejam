using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public sealed class FloatingTextManager : MonoBehaviour
{
    public static FloatingTextManager Instance;

    private void Start()
    {
        Instance = this;
    }

    public GameObject prefabs;

    public void CreateFloatingText(Vector3 _pos, string _text)
    {
        GameObject clone = Instantiate(prefabs, _pos, prefabs.transform.rotation);
        clone.GetComponentInChildren<Text>().text = _text;
    }
}
