using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] platePrefabs;
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
    public Text moneyText;
    public Text moneyTextMenu;

    public static int money;
    public static int score = 0;
    public static int level = 1;
    public static bool isTimeDestroy = false;
    private int plateAvailible;

    private int count = 3;
    public static int countDestroyPlate = 0;

    private float randomRange;

    void Start()
    {
        plateAvailible = count;
        if (PlayerPrefs.HasKey("currenteMoney"))
        {
            money = PlayerPrefs.GetInt("currenteMoney");
            //Debug.Log(money);
        }
        if (PlayerPrefs.HasKey("currenteLevel"))
        {
            level = PlayerPrefs.GetInt("currenteLevel");
            //Debug.Log(level);
        }
    }

    void Update()
    {
        UpdateScoreLevelPlate();
        moneyText.text = "Money: " + money;
        Debug.Log("Level: " + level + " Score: " + score + " plateAvailible: " + plateAvailible + " countDestroyPlate: " + 
            countDestroyPlate + " money: " + money + " currenteMoney: " + PlayerPrefs.GetInt("currenteMoney"));
    } 

    public void SpawnPlate()
    {
        randomRange = Random.Range(3f, 6f);
        int prefabIndex = Random.Range(0, platePrefabs.Length);
        platePrefabs[prefabIndex].GetComponent<BoxCollider>().size = Guns.sizeColliderPlate;
        Instantiate(platePrefabs[prefabIndex], new Vector3(-randomRange, randomRange, 0), Quaternion.identity);      
        plateAvailible--;
        pushFireBtn.SetActive(false);
        Debug.Log(prefabIndex);
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
                //Invoke("WaitCanvasRestartLevel", 1);
                WaitCanvasRestartLevel();
            }
        }
    }


    public void StartNextLevel()
    {
        
        canvasNextLevel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        CountMoney();
        level++;
        score = 0;
        PlayerPrefs.SetInt("currenteLevel", level);
        countDestroyPlate = 0;
        plateAvailible = count;
        isTimeDestroy = false;
        nextLevelBtn.SetActive(false);
        pushFireBtn.SetActive(true);
        if(level > 3)
        {
            level = 1;
            PlayerPrefs.SetInt("currenteLevel", level);
            SceneManager.LoadScene("Game Over Level");

        } else
        SceneManager.LoadScene("Level " + level);
    }

    public void RestartLevel()
    {
        canvasNextLevel.SetActive(false);
        player.GetComponent<PlayerController>().enabled = true;
        CountMoney();
        score = 0;
        countDestroyPlate = 0;
        plateAvailible = count;
        isTimeDestroy = false;
        restartLevelBtn.SetActive(false);
        pushFireBtn.SetActive(true);
    }

    public void WaitCanvasNextLevel()
    {
        //добавить 
        //SceneManager.LoadScene(sceneBuildIndex + 1);

        canvasNextLevel.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        nextLevelBtn.SetActive(true);
        pushFireBtn.SetActive(false);
        moneyTextMenu.text = "Money: " + score * level + " x " + level;
    }

    public void WaitCanvasRestartLevel()
    {

        canvasNextLevel.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        restartLevelBtn.SetActive(true);
        pushFireBtn.SetActive(false);
        moneyTextMenu.text = "Money: +" + score * level + " x" + level;
    }

    public void CountMoney()
    {
        money += score * level;
        PlayerPrefs.SetInt("currenteMoney", money);
    }

    public void BackToMenu()
    {
        score = 0;
        countDestroyPlate = 0;
        SceneManager.LoadScene("MenuScene");
    }
}
