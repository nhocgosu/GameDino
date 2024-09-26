
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initalGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;

    private Player player;
    private Spawner spawner;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    public Button retryButton;

    private float score;
    


    public float gameSpeed { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
   
    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindAnyObjectByType<Player>();
        spawner = FindAnyObjectByType<Spawner>();
        NewGame();

    }
    public void NewGame()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();

        foreach (Enemy enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        score = 0;
        gameSpeed = initalGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
       retryButton.gameObject.SetActive(false);

       UpdateHiscore();
    }
    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        spawner.gameObject.SetActive(false);
        player.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHiscore();
    }
    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;
        score += gameSpeed * Time.deltaTime;
        scoreText.text = MathF.Round(score).ToString();
    }
    private void UpdateHiscore(){
        float hiscore = PlayerPrefs.GetFloat("hiscore",0);

        if (score > hiscore){
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore",hiscore);
        }

        hiscoreText.text = MathF.Floor(hiscore).ToString();
        
    }
}
