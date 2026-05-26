using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public Transform PlayerPos;

    public GameObject EnemyPrefab;

    [SerializeField]
    public GameObject ammoPreFab;

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

    [SerializeField]
    private int Score = 0;

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
        if(WaveCount > MaxWave){
            yield break;
        }
        Debug.Log("Wave " + WaveCount + " completed!");
        StopAllCoroutines();
        
    }

    public void EnemyKilled(Vector2 position){
        Score++;
        int percentage = Random.Range(0, 100);
        if(percentage < 50){
            Instantiate(ammoPreFab, position, Quaternion.identity);
        }

        if (Score != MaxEnemyCount){
            return;
        }
        SpawnCd -= 0.15f;
        MaxEnemyCount += 5;
        WaveCount++;
        EnemyCount = 0;
        HudController.Instance.ChangeWaveCount(WaveCount, MaxWave);
        StartCoroutine(SpawnEnemy());
    }
    
}
