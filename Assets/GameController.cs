using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform PlayerPos;

    public GameObject EnemyPrefab;

    public float XOffset = 50f;
    public float YOffset = 50f;

    public float SpawnCd = 1f;
    public float WaveCd = 5f;

    [SerializeField]
    private int MaxEnemyCount = 20;

    [SerializeField]
    private int EnemyCount = 0;

    [SerializeField]
    private int WaveCount = 1;

    [SerializeField]
    private int MaxWave = 5;

    private void Awake()
    {
        //Instance = this;
        PlayerPos = FindFirstObjectByType<PlayerController>().transform;
        StartCoroutine(SpawnEnemy());
        HudController.Instance.ChangeWaveCount(WaveCount, MaxWave);
    }


    private IEnumerator SpawnEnemy()
    {
        while (EnemyCount < MaxEnemyCount){
            yield return new WaitForSeconds(SpawnCd);
            float x = Random.Range(PlayerPos.position.x - XOffset, PlayerPos.position.x + XOffset);
            float y = Random.Range(PlayerPos.position.y - YOffset, PlayerPos.position.y + YOffset);
            Vector2 spawnPos = new Vector2(x, y);
            Instantiate(EnemyPrefab, spawnPos, Quaternion.identity);
            EnemyCount++;
        }
        if (WaveCount < MaxWave){
            yield return new WaitForSeconds(WaveCd);
            SpawnCd -= 0.15f;
            MaxEnemyCount =+ 5;
            WaveCount++;
            EnemyCount = 0;
            HudController.Instance.ChangeWaveCount(WaveCount, MaxWave);
            StartCoroutine(SpawnEnemy());
        }
        
    }

    
    
}
