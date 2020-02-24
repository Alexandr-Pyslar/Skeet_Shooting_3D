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

    private int count = 5;
    public static int countDestroyPlate = 0;

    private float randomRange;
    private int randomXPos = 1;

    public GameObject spawnPoint;

    public static bool playShoot = false;

    void Start()
    {
        plateAvailible = count;
        if (PlayerPrefs.HasKey("currenteMoney"))
        {
            money = PlayerPrefs.GetInt("currenteMoney");
        }
        if (PlayerPrefs.HasKey("currenteLevel"))
        {
            level = PlayerPrefs.GetInt("currenteLevel");
        }
    }

    void Update()
    {
        UpdateScoreLevelPlate();
        moneyText.text = "Money: " + money;
    } 

    public void SpawnPlate()
    {
        randomRange = Random.Range(3f, 6f);
        int prefabIndex = Random.Range(0, platePrefabs.Length);
        platePrefabs[prefabIndex].GetComponent<BoxCollider>().size = Guns.sizeColliderPlate;

        RandomPosX();
        spawnPoint.transform.position = new Vector3( spawnPoint.transform.position.x * randomXPos, spawnPoint.transform.position.y, spawnPoint.transform.position.z);
        Instantiate(platePrefabs[prefabIndex], spawnPoint.transform.position, Quaternion.identity);
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
                pushFireBtn.SetActive(false);
                Invoke("WaitCanvasNextLevel", .5f);
            }
            if (isTimeDestroy)
            {
                //Restart level
                pushFireBtn.SetActive(false);
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

    void RandomPosX()
    {
        float pushPosX = Random.Range(0.0f, 1.0f);
        if (pushPosX < 0.5f)
        {
            randomXPos = -1;
        }
        else
        {
            randomXPos = 1;
        }
    }
}
