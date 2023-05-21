using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskGenerator : MonoBehaviour
{

    public ObjectPooler maskPooler;

    public void SpinMask(Vector3 position, float width)
    {

        int random = Random.Range(1, 10);
        if(random > 5)
        {
            return;
        }

        int numberOfMask = (int)Random.Range(1f, 3f);
        int y = Random.Range(3, 5);

        for (int i = 0; i <= numberOfMask; i++)
        {

            GameObject mask = maskPooler.GetPooledGameObject();

            mask.transform.position = new Vector3(
                position.x + 5 + i,
                position.y + y,
                position.z
                );

            mask.SetActive(true);
        }




    }


}
