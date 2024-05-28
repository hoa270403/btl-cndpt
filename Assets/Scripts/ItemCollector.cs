using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    private int bananas = 0;
    private int totalBananas;
    [SerializeField] private Text BananasText;
    [SerializeField] private AudioSource collectsoundeffect;

    private int currentLevelIndex;

    void Start()
    {
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        totalBananas = GameObject.FindGameObjectsWithTag("banana").Length;
        BananasText.text = "Level " + currentLevelIndex + " - Bananas: " + bananas + "/" + totalBananas;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("banana"))
        {
            collectsoundeffect.Play();
            Destroy(collision.gameObject);
            bananas++;
           BananasText.text = "Level " + currentLevelIndex + " - Bananas: " + bananas + "/" + totalBananas;
        }
    }
    public bool checkBananas()
    {
        return bananas == totalBananas;
    }
}

