using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveData")]
public class WaveThugData : ScriptableObject
{
    [System.Serializable]
    public class WaveData
    {
        public int numberOfThug;
    }

    public WaveData[] waveData;
}
