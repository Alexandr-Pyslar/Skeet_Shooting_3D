using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Transform loadingBar;
    public static float currentAmount;
    public static bool readyToShot = false;
    private float speedRadial = 5f;

    void FixedUpdate()
    {
        if (currentAmount < 100 && RayShooter.inAim)
        {
            currentAmount += 1 * speedRadial;
        }
        loadingBar.GetComponent<Image>().fillAmount = currentAmount / 100;

        if (loadingBar.GetComponent<Image>().fillAmount == 1)
        {
            readyToShot = true;
        }
        else
        {
            readyToShot = false;
        }
    }

}
