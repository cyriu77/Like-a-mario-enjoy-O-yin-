/*using System.Collections;
using System.Collections.Generic;*/
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI numbCoinsText;

    public static int currentHealth = 100;
    public Slider healthBar;
    public static bool gameOver;
    public GameObject gameOverPan;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        numbCoinsText.text = "coins:" + numberOfCoins;

        //updatevalue of slider
        healthBar.value = currentHealth;

        //gameOver
        if(currentHealth < 0)
        {
            gameOver = true;
            gameOverPan.SetActive(true);
            currentHealth = 100;
        }
    }

}
