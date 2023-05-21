using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPicker : MonoBehaviour
{

    private AudioSource maskPickSound;

    private float maskPoint = 5f;
    private ScoreManage scoreManage;

    void Start()
    {
        maskPickSound = GameObject.Find("MaskpickingSound").GetComponent<AudioSource>();
        scoreManage = FindObjectOfType<ScoreManage>(); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Corona Player")
        {
            gameObject.SetActive(false);

            if(maskPickSound.isPlaying)
                maskPickSound.Stop();

            maskPickSound.Play();

            scoreManage.score -= maskPoint;
        }
    }
}
