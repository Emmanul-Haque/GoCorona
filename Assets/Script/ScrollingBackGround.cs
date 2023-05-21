using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackGround : MonoBehaviour
{

    public Renderer BackGround;
    public float BackGroundSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        BackGround.material.mainTextureOffset += new Vector2(-BackGroundSpeed * Time.deltaTime, 0f);
    }
}
