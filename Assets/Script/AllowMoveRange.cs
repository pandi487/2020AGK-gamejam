using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowMoveRange : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);

        transform.position = worldPos;
    }
}
