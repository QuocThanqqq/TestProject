using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public void CreateWave1()
    {
        SpawnManager.Instance.SpawnWave(1);
    }

    public void CreateWave2()
    {
        SpawnManager.Instance.SpawnWave(2);
    }

    public void CreateWave3()
    {
        SpawnManager.Instance.SpawnWave(3);
    }
}
