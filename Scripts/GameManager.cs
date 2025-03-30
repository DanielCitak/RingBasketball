using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Boxes;
    public Text scoreText;
    public GameObject basketball;
    private GameObject titleScreen;
    public GameObject startButton;
    public GameObject restartButton;
    [SerializeField] float maxTime;
    float remainingTime;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI startButtonText;
    private Coroutine spawnBallsCoroutine;

    float repeatRate = 1.5f;
    bool isGameActive;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        titleScreen = GameObject.Find("Title Screen");
        score = 0;
        remainingTime= maxTime;
        spawnBallsCoroutine = StartCoroutine(SpawnBalls());


    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            UpdateTimer();
        }


    }
    public void ActivateBoxes()
    {
        foreach (GameObject box in Boxes) {
            box.SetActive(false);
        }
        int randomNum = UnityEngine.Random.Range(0, Boxes.Count);
        Boxes[randomNum].SetActive(true);
    }
    public void UpdateScore()
    {
        score += 1;
        scoreText.text = "Score : " + score;
    }
   
    IEnumerator SpawnBalls()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(repeatRate);
            float randomPosX = UnityEngine.Random.Range(-14, 14);
            
            Instantiate(basketball, new Vector3(randomPosX, 25, 0), Quaternion.identity);
            Debug.Log(isGameActive);

        }
    }
    void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;
        timerText.text = "Time: " + Convert.ToInt32(remainingTime);
        if (remainingTime <= 0)
        {
            if (spawnBallsCoroutine != null)
            {
                StopCoroutine(spawnBallsCoroutine);
                spawnBallsCoroutine = null;
            }
            GameOver();
            Debug.Log("Oyun Saati bitti");
            remainingTime = maxTime;
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        ActivateBoxes();
        StartCoroutine(SpawnBalls());
        
    }
    public void GameOver()
    {
        isGameActive = false;

        titleScreen.SetActive(true);
        startButton.SetActive(false);
        restartButton.SetActive(true);
        
        

        DestroyGameObjects("Ball");
        Debug.Log("GameOver");
    }
    public void RestartGame()
    {
        
        isGameActive = true;
        titleScreen.SetActive(false);
        score = -1;
        UpdateScore();
        DestroyGameObjects("Ball");
        ActivateBoxes();
        StartCoroutine(SpawnBalls());
    }
    private void DestroyGameObjects(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject gameObject in gameObjects)
        {
            Destroy(gameObject);
        }
    }
}
