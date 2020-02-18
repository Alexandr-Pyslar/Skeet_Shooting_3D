using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuShop : MonoBehaviour
{
    private int money = 0;
    public Text textMoney;
    public Button gun1BtnPrice;
    public Button gun2BtnPrice;

    private int gun1Price = 5;
    private int gun2Price = 10;

    public static int isGun1Purchased = 0;
    public static int isGun2Purchased = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        isGun1Purchased = PlayerPrefs.GetInt("isGun1Purchased");
        isGun2Purchased = PlayerPrefs.GetInt("isGun2Purchased");

    }

    // Update is called once per frame
    void Update()
    {
        money = PlayerPrefs.GetInt("currenteMoney");
        textMoney.text = "Money: " + money;
        // add foreach
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
}
