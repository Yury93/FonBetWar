using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAiArmy : MonoBehaviour
{
    [SerializeField] private Unit prefabUnitAi;

    [SerializeField] private float timer;
    private float startTimer;
    [SerializeField] private UnitProperties unitProperties;

    private void Start()
    {
        startTimer = timer;

        //prefabUnitAi.SetProperties(unitProperties.SetHp, 
        //    unitProperties.SetSpeed, 
        //    unitProperties.SetDistanceStop
        //    , unitProperties.SetAi, 
        //    unitProperties.SetSprite);
    }
    private void Update()
    {
        if(timer < 0)
        {
            var enemy =  Instantiate(prefabUnitAi, transform.position, Quaternion.identity);
            
            timer = startTimer;

            enemy.SetProperties(unitProperties.SetHp,
            unitProperties.SetSpeed,
            unitProperties.SetDistanceStop
            , unitProperties.SetAi,
            unitProperties.SetSprite);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
