﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
                if (_instance == null) Debug.LogError("No Game Manager Found!!!");
            }
            return _instance;
        }
    }
    #endregion
    public int Score { get; private set; }
    [Header("Box Coin Controller")]
    public int coinSpawn;
    [SerializeField] CoinBox boxCoinPrefabs;
    private List<CoinBox> boxCoinsPool = new List<CoinBox>();

    [Header("Game area constraint")]
    public float areaConstraintValue = 5f;

    [Header("UI")]
    public Text scoreText;

    private void Start()
    {
        for (int i = 0; i < coinSpawn; i++)
        {
            CoinBox coin = Instantiate(boxCoinPrefabs);
            coin.Spawn();
        }
        scoreText.text = $"Score : {Score}";
    }

    public Vector2 GetRandomPosition()
    {
        float xPosition = Random.Range(-areaConstraintValue, areaConstraintValue);
        float yPosition = Random.Range(-areaConstraintValue, areaConstraintValue);

        return new Vector2(xPosition, yPosition);
    }


  
    public void AddScore()
    {
        Score++;
        scoreText.text = $"Score : {Score}";
    }

    public void RespawnBox() => StartCoroutine(ReSpawnBox());
    IEnumerator ReSpawnBox()
    {
        yield return new WaitForSeconds(3);
        CoinBox coin = GetBox();
        coin.Spawn();
    }

    public CoinBox GetBox()
    {
        for (int i = 0; i < boxCoinsPool.Count; i++)
        {
            if (!boxCoinsPool[i].gameObject.activeSelf)
            {
                boxCoinsPool[i].gameObject.SetActive(true);
                return boxCoinsPool[i];
            }
        }

        CoinBox boxObject = Instantiate(boxCoinPrefabs, transform);
        boxCoinsPool.Add(boxObject);
        return boxObject;
    }
}
