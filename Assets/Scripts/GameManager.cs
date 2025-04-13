using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public delegate void PowerUp(Color c);
    public static event PowerUp OnPowerUp;

    public Collectable collectablePrefab;
    public Collectable keyPrefab, powerupPrefab;
    public GameObject[] walls;

    public int collectableCount;

    private int collected = 0;
    
    public GameObject scorePanel, gameOverPanel;
    public TextMeshProUGUI scoreText, powerupText;
    
    
    private int powerupCount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < collectableCount; i++)
        {
            Instantiate(collectablePrefab, new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f)), Quaternion.identity);
        }
        Instantiate(powerupPrefab, new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f)), Quaternion.identity);

        scoreText.text = $"{collected}/{collectableCount}";
    }

    public void OnCollect()
    {
        collected++;
        scoreText.text = $"{collected}/{collectableCount}";
        if (collected == collectableCount)
        {
            Instantiate(keyPrefab, new Vector3(Random.Range(-4f, 4f), 0, Random.Range(-4f, 4f)), Quaternion.identity);
        }
    }

    public void OnKeyCollected()
    {
        foreach (var g in walls)
        {
            keyCollected = true;
            g.gameObject.SetActive(false);
        }
    }

    private bool keyCollected;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && collected == collectableCount && keyCollected)
        {
            gameOverPanel.SetActive(true);
            scorePanel.SetActive(false);
        }
    }

    public void OnPowerCollected()
    {
        powerupCount++;
        powerupText.text = $"{powerupCount}";    
        OnPowerUp?.Invoke(Color.red);
    }
}
