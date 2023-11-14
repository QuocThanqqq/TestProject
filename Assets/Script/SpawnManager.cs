using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    public WaveThugData waveManager;
    
   [SerializeField] private GameObject _thugPrefab;
   [SerializeField] private Transform _posSpawn;

   private void Awake()
   {
       Instance = this;
   }

   
   public void SpawnWave(int waveNumber)
   {
       if (waveNumber >= 1 && waveNumber <= waveManager.waveData.Length)
       {
           int numberOfThugs = waveManager.waveData[waveNumber - 1].numberOfThug;
           SpawnThug(numberOfThugs);
           Debug.Log("Creating wave " + waveNumber + " with " + numberOfThugs + " thugs.");
       }
       else
       {
           Debug.LogWarning("Invalid wave number.");
       }
   }
   
   
   public void SpawnThug(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
           Instantiate(_thugPrefab, _posSpawn.transform.position, Quaternion.identity);
        }
    }
}
