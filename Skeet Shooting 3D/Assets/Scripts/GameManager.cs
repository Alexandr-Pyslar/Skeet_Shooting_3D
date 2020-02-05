using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject platePrefab;
    public Text scoreText;

    public static int score = 0;
 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    public void SpawnPlate()
    {
        Instantiate(platePrefab, new Vector3(-3f, 5f, 0), Quaternion.identity);
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score + "/5";
    }
    }
