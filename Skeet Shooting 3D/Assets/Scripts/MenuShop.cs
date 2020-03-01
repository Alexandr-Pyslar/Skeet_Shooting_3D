using UnityEngine;
using UnityEngine.UI;

public class MenuShop : MonoBehaviour
{
    private int money = 0;
    public Text textMoney;
    public Text gun0Distance, gun1Distance, gun2Distance;
    public Text gun0Spread, gun1Spread, gun2Spread;
    public Button gun0DistanceBtn, gun1DistanceBtn, gun2DistanceBtn;
    public Button gun0SpreadBtn, gun1SpreadBtn, gun2SpreadBtn;


    public Button gun1BtnPrice;
    public Button gun2BtnPrice;

    private int gun1Price = 5;
    private int gun2Price = 10;

    public static int isGun1Purchased = 0;
    public static int isGun2Purchased = 0;

    public int addGun0Distance, addGun1Distance, addGun2Distance;
    public float addGun0Spread, addGun1Spread, addGun2Spread;




    void Start()
    {
        money = 0;
        isGun1Purchased = PlayerPrefs.GetInt("isGun1Purchased");
        isGun2Purchased = PlayerPrefs.GetInt("isGun2Purchased");
        addGun0Distance = PlayerPrefs.GetInt("addGun0Distance");
        addGun0Spread = PlayerPrefs.GetFloat("addGun0Spread");

        gun0Distance.text = "Distance: 25 + " + PlayerPrefs.GetInt("addGun0Distance");
        gun1Distance.text = "Distance: 40 + " + PlayerPrefs.GetInt("addGun1Distance");
        gun2Distance.text = "Distance: 100 + " + PlayerPrefs.GetInt("addGun2Distance");

        gun0Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun0Spread");
        gun1Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun1Spread");
        gun2Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun2Spread");

        if (PlayerPrefs.HasKey("addGun0Spread"))
        {
            RayShooter.randomRot = 2 - PlayerPrefs.GetFloat("addGun0Spread");
        }
    }

    void Update()
    {
        money = PlayerPrefs.GetInt("currenteMoney");
        textMoney.text = "Money: " + money;

        if (money < gun1Price) gun1BtnPrice.interactable = false;
            else gun1BtnPrice.interactable = true;

        if (money < gun2Price) gun2BtnPrice.interactable = false;
            else gun2BtnPrice.interactable = true;

        if (PlayerPrefs.GetInt("isGun1Purchased") == 1 || isGun1Purchased != 0) gun1BtnPrice.gameObject.SetActive(false);
        if (PlayerPrefs.GetInt("isGun2Purchased") == 1 || isGun2Purchased != 0) gun2BtnPrice.gameObject.SetActive(false);
    }

    public void Gun1Purchase()
    {
        isGun1Purchased = 1;
        money -= gun1Price;
        PlayerPrefs.SetInt("currenteMoney", money);
        PlayerPrefs.SetInt("isGun1Purchased", isGun1Purchased);
    }

    public void Gun2Purchase()
    {
        isGun2Purchased = 1;
        money -= gun2Price;
        PlayerPrefs.SetInt("currenteMoney", money);
        PlayerPrefs.SetInt("isGun2Purchased", isGun2Purchased);
    }

    public void AddDistanceGun0()
    {
        if (money > 0)
        {
            gun0DistanceBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun0Distance"))
            {
                addGun0Distance = PlayerPrefs.GetInt("addGun0Distance");
            }
            addGun0Distance++;
            PlayerPrefs.SetInt("addGun0Distance", addGun0Distance);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun0Distance.text = "Distance: 25 + " + addGun0Distance;
        } else
        {
            gun0DistanceBtn.interactable = false;
        }
    }

    public void AddDistanceGun1()
    {
        if (money > 0)
        {
            gun1DistanceBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun1Distance"))
            {
                addGun1Distance = PlayerPrefs.GetInt("addGun1Distance");
            }
            addGun1Distance++;
            PlayerPrefs.SetInt("addGun1Distance", addGun1Distance);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun1Distance.text = "Distance: 40 + " + addGun1Distance;
        }
        else
        {
            gun1DistanceBtn.interactable = false;
        }
    }

    public void AddDistanceGun2()
    {
        if (money > 0)
        {
            gun2DistanceBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun2Distance"))
            {
                addGun2Distance = PlayerPrefs.GetInt("addGun2Distance");
            }
            addGun2Distance++;
            PlayerPrefs.SetInt("addGun2Distance", addGun2Distance);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun2Distance.text = "Distance: 100 + " + addGun2Distance;
        }
        else
        {
            gun2DistanceBtn.interactable = false;
        }
    }

    public void AddSpreadGun0()
    {
        if (money > 0)
        {
            gun0SpreadBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun0Spread"))
            {
                addGun0Spread = PlayerPrefs.GetFloat("addGun0Spread");
            }
            addGun0Spread += 0.1f;
            PlayerPrefs.SetFloat("addGun0Spread", addGun0Spread);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun0Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun0Spread");
        }
        else
        {
            gun0SpreadBtn.interactable = false;
        }
    }

    public void AddSpreadGun1()
    {
        if (money > 0)
        {
            gun1SpreadBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun1Spread"))
            {
                addGun1Spread = PlayerPrefs.GetFloat("addGun1Spread");
            }
            addGun1Spread += 0.1f;
            PlayerPrefs.SetFloat("addGun1Spread", addGun1Spread);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun1Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun1Spread");
        }
        else
        {
            gun1SpreadBtn.interactable = false;
        }
    }

    public void AddSpreadGun2()
    {
        if (money > 0)
        {
            gun2SpreadBtn.interactable = true;
            if (PlayerPrefs.HasKey("addGun2Spread"))
            {
                addGun2Spread = PlayerPrefs.GetFloat("addGun2Spread");
            }
            addGun2Spread += 0.1f;
            PlayerPrefs.SetFloat("addGun2Spread", addGun2Spread);
            money--;
            PlayerPrefs.SetInt("currenteMoney", money);
            gun2Spread.text = "Spread: 2 - " + PlayerPrefs.GetFloat("addGun2Spread");
        }
        else
        {
            gun2SpreadBtn.interactable = false;
        }
    }


}
