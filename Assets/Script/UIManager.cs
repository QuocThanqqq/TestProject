using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textTotalThug;


    private void Update()
    {
        _textTotalThug.text = "Total Thug: " + SpawnManager.Instance.totalThugsSpawned;
    }
}
