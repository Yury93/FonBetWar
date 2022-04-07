using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAiArmy : MonoBehaviour
{
    [SerializeField] private GameObject prefabUnitAi;

    [SerializeField] private float timer;
    private float startTimer;

    private void Start()
    {
        startTimer = timer;
    }
    private void Update()
    {
        if(timer< 0)
        {
            Instantiate(prefabUnitAi, transform.position, Quaternion.identity);
            timer = startTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
