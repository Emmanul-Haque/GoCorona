using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformEndPoint : MonoBehaviour
{
    private GameObject point;

    void Start()
    {
        point = GameObject.Find("PlatformEndPoint");
    }

    void Update()
    {
        if (transform.position.x < point.transform.position.x)
        {
            gameObject.SetActive(false);
        }
    }
}
