using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public Transform groundPoint; 
    public ObjectPooler[] groundPoolers;

    public float minGap; 
    public float maxGap;

    private float[] groundWidths;
    private MaskGenerator maskGenerator;

    void Start()
    {
        groundWidths = new float[groundPoolers.Length];
        for(int i = 0; i<groundPoolers.Length; i++)
        {
            groundWidths[i] = groundPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        maskGenerator = FindObjectOfType<MaskGenerator>();
    }

    void Update()
    {
        if(transform.position.x < groundPoint.position.x)
        {
            int random = Random.Range(0, groundPoolers.Length);
            float distance = groundWidths[random] / 2;
                

            float Gap = Random.Range(minGap, maxGap);

            transform.position = new Vector3(
                transform.position.x + Gap,
                transform.position.y,
                transform.position.z
                );

            GameObject ground = groundPoolers[random].GetPooledGameObject();
            ground.transform.position = transform.position;

            maskGenerator.SpinMask(
                    transform.position,
                    groundWidths[random]
                );
            ground.SetActive(true);

            transform.position = new Vector3(
                transform.position.x + distance+ Gap,
                transform.position.y,
                transform.position.z
                );
        }
    }
}
