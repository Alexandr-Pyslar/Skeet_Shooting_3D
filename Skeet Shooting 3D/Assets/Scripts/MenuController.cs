
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menuBtn;
    public GameObject exitGameBtn;
    public GameObject shopBtn;
    public GameObject menuSampleScene;

    private float camVol;
    private bool fadingVol = false;

    void Start()
    {
        camVol = GameObject.Find("Main Camera").GetComponent<AudioSource>().volume;
    }

    void Update()
    {
        
        if (fadingVol && camVol >= 0)
        {
            camVol *= 0.8f;
            GameObject.Find("Main Camera").GetComponent<AudioSource>().volume = camVol;
        }
        
    }
    public void ShowExitBtns()
    {
        menuBtn.SetActive(false);
        exitGameBtn.SetActive(true);
    }

    public void BackInMenu()
    {
        menuBtn.SetActive(true);
        exitGameBtn.SetActive(false);
        shopBtn.SetActive(false);
    }

    public void OpenShop()
    {
        shopBtn.SetActive(true);
        menuBtn.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        fadingVol = true;
        // Задержка выполнения для затухания звука
        Invoke("LoadGame", 0.3f);
    }
    public void BackToMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void LoadGame()
    {

        if (PlayerPrefs.HasKey("currenteLevel"))
        {
            SceneManager.LoadScene("Level "+ PlayerPrefs.GetInt("currenteLevel"));

        } else if (!PlayerPrefs.HasKey("currenteLevel") || PlayerPrefs.GetInt("currenteLevel") > 3)
        SceneManager.LoadScene("Level 1");

    }

    public void RestartGame()
    {
        GameManager.money = 0;
        GameManager.level = 1;
        MenuShop.isGun1Purchased = 0;
        MenuShop.isGun2Purchased = 0;
        PlayerPrefs.DeleteAll();
        RayShooter.randomRot = 2;
    }

}
