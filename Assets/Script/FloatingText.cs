using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public Animation floaingText_Animation;
    public float destory_Time;
    void Start()
    {
        floaingText_Animation.Play();
        Destroy(gameObject.transform.parent.gameObject, destory_Time);
    }
}
