using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    
    [SerializeField] private WaveThugData waveManager;
    [SerializeField] private Transform _posSpawn;

    public int totalThugsSpawned;
   private void Awake()
   {
       Instance = this;
   }
    
   public async void SpawnWave(int waveNumber)
   {
       if (waveNumber >= 1 && waveNumber <= waveManager.waveData.Length)
       {
           int numberOfThugs = waveManager.waveData[waveNumber - 1].numberOfThug;
           await SpawnThug(numberOfThugs);
       }
       else
       {
           Debug.LogWarning("Invalid wave number");
       }
   }
    
   public async UniTask SpawnThug(int numberOfEnemies)
   {
       for (int i = 0; i < numberOfEnemies; i++)
       {
           GameObject thug = BYPoolManager.Instance.GetThugFromPool();

           Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(0f, 3f);
           Vector3 randomPosition = new Vector3(randomCircle.x, 0f, randomCircle.y) + _posSpawn.position;
           thug.transform.position = randomPosition;
           thug.SetActive(true);
           totalThugsSpawned++;
           await UniTask.Delay(TimeSpan.FromSeconds(0.7));
       }
    }
}
