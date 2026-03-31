using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform PlayerPos;

    public GameObject EnemyPrefab;

    public float XOffset = 50f;
    public float YOffset = 50f;

    public float SpawnCd = 4f;

    [SerializeField]
    private int MaxEnemyCount = 10;

    [SerializeField]
    private int EnemyCount = 0;

    private void Awake()
    {
        //Instance = this;
        PlayerPos = FindFirstObjectByType<PlayerController>().transform;
        StartCoroutine(SpawnEnemy()); }

    private IEnumerator SpawnEnemy()
    {
        while (EnemyCount < MaxEnemyCount)
        {
            yield return new WaitForSeconds(SpawnCd);
            float x = Random.Range(PlayerPos.position.x - XOffset, PlayerPos.position.x + XOffset);
            float y = Random.Range(PlayerPos.position.y - YOffset, PlayerPos.position.y + YOffset);
            Vector2 spawnPos = new Vector2(x, y);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
            EnemyCount++;
        }
    }
    
}
