using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Corona_Player player;
    public ScoreManage scoreManage;
    public AudioSource backgroundSound;
    public AudioSource deathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groudGeneratingPoint;

    public GroundGenerator groundGenerator;

    public GameObject largeGround1;
    public GameObject largeGround2;
    public GameObject mediumGround1;
    public GameObject mediumGround2;
    public GameObject smallGround1;

    public GameObject gameOverScreen;
    

    void Start()
    {
        playerStartingPoint = player.transform.position;
        groudGeneratingPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);

    }

    public void GameOver()
    {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManage.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
        
    }

    public void Quit()
    {
        Application.Quit(); 
    }
    public void Restart()
    {
        PlatformEndPoint[] destroyer = FindObjectsOfType<PlatformEndPoint>();
        for(int i = 0; i<destroyer.Length; i++)
        {
            destroyer[i].gameObject.SetActive(false);
        }
        largeGround1.SetActive(true);
        largeGround2.SetActive(true);
        mediumGround1.SetActive(true);
        mediumGround2.SetActive(true);
        smallGround1.SetActive(true);
        player.transform.position = playerStartingPoint;
        groundGenerator.transform.position = groudGeneratingPoint;
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        backgroundSound.Play();
        scoreManage.score = 0;
        scoreManage.isScoreIncreasing = true;
    }


}
