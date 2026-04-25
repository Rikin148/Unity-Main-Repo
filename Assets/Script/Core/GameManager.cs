using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject enemyPrefab;
    public TextMeshProUGUI levelText;
    public GameFacade gameFacade;
    public GameObject player;
    public int level = 1;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        gameFacade.Initialize(enemyPrefab);
    }

    public void StartGame()
    {
        level = 1;
        UpdateLevelUI();
        SpawnNextLevel();

        player.SetActive(true);
        if (player != null)
        {
            PlayerHealth ph = player.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.ResetPlayer();
            }
        }

        if (PlayerBulletPool.Instance != null)
            PlayerBulletPool.Instance.ResetPool();

        if (EnemyBulletPool.Instance != null)
            EnemyBulletPool.Instance.ResetPool();
    }
    void SpawnNextLevel()
    {
        if (gameFacade != null)
            gameFacade.StartLevel(level);
    }

    public void EnemyDied()
    {
        if (gameFacade != null)
        {
            gameFacade.EnemyDied();
            if (gameFacade.GetEnemiesAlive() <= 0)
            {
                level++;

                UpdateLevelUI();

                Invoke(nameof(SpawnNextLevel), 1.5f);
            }
        }
    }
    void UpdateLevelUI()
    {
        if (levelText != null)
            levelText.text = "Level: " + level;
    }
}