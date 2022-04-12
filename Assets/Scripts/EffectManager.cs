using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : SingletonBase<EffectManager>
{
    [SerializeField] private GameObject unitDestroy, campDestroy;

    public void CreateEffectDestroy(GameObject destrObj)
    {
        if(destrObj.GetComponent<Camp>())
        {
            var effect = Instantiate(campDestroy, destrObj.transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 6);
        }
        if (destrObj.GetComponent<CombatUnit>())
        {
            var effect = Instantiate(unitDestroy, destrObj.transform.position, Quaternion.identity);
            Destroy(effect.gameObject, 6);
        }
    }
}
