using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platePrefab;
    public GameObject canvasNextLevel;
    public GameObject player;
    public GameObject nextLevelBtn;
    public GameObject restartLevelBtn;
    public GameObject pushFireBtn;


    public Text scoreText;
    public Text plateText;
    public Text levelText;

    public Text scoreTextNextLevel;
    public Text levelTextNextLevel;

    public static int score = 0;
    public static int coin;
    public static int level = 1;
    public static bool isTimeDestroy = false;
    private  int plateAvailible;

    private int count = 3;
    public static int countDestroyPlate = 0;

    void Start()
    {
        plateAvailible = count;
    }

    void Update()
    {
        UpdateScoreLevelPlate();
        Debug.Log(countDestroyPlate);
    }

    public void SpawnPlate()
    {
        Instantiate(platePrefab, new Vector3(-3f, 5f, 0), Quaternion.identity);
        plateAvailible--;
        pushFireBtn.SetActive(false);
    }

    public void UpdateScoreLevelPlate()
    {
        scoreText.text = "Score: " + score + "/" + count;
        levelText.text = "Level: " + level;
        plateText.text = "Plates: " + plateAvailible + "/" + count;

        scoreTextNextLevel.text = "Score: " + score + "/" + count;
        levelTextNextLevel.text = "Level: " + level;

        if (plateAvailible == 0 && countDestroyPlate == count)
        {
            if (!isTimeDestroy)
            {
                // Next Level
                Invoke("WaitCanvasNextLevel", 1);

            }
            if (isTimeDestroy)
            {
                //Restart level
                Invoke("WaitCanvasRestartLevel", 1);
            }
        }
    }


    public void StartNextLevel()
    {
        canvasNextLevel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        level++;
        score = 0;
        countDestroyPlate = 0;
        plateAvailible = count;
        isTimeDestroy = false;
        nextLevelBtn.SetActive(false);
        pushFireBtn.SetActive(true);

    }

    public void RestartLevel()
    {
        canvasNextLevel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        score = 0;
        countDestroyPlate = 0;
        plateAvailible = count;
        isTimeDestroy = false;
        restartLevelBtn.SetActive(false);
        pushFireBtn.SetActive(true);
    }

    public void WaitCanvasNextLevel()
    {
        canvasNextLevel.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        nextLevelBtn.SetActive(true);
        pushFireBtn.SetActive(false);
        StopAllCoroutines();
    }

    public void WaitCanvasRestartLevel()
    {
        canvasNextLevel.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        restartLevelBtn.SetActive(true);
        pushFireBtn.SetActive(false);
        StopAllCoroutines();
    }




}
