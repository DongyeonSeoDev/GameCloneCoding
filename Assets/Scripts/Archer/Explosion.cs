using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float inactiveTime;

    private void OnEnable()
    {
        inactiveTime = Time.time + 4f;
    }

    private void Update()
    {
        if(Time.time>inactiveTime)
        {
            gameObject.SetActive(false);
        }
    }
}
