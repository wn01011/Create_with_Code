using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    private float surviveTime;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    private void TimeTextManager()
    {
        surviveTime += Time.deltaTime;
        timeText.text = "Time: " + (uint)surviveTime;
    }
    private void EndGame()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime>bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        if (playerController != null)
        {
            if (playerController.isDie)
            {
                gameoverText.SetActive(true);
                recordText.text = "Best Record: " + (uint)bestTime;
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene("SampleScene");
                }
            }
            else
                TimeTextManager();
        }
    }
}
