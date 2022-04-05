using System;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] private int hp;

    public event Action OnDestroyCamp;
    [SerializeField] private bool ai;
    public bool AI => ai;
    public void DamageCamp(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnDestroyCamp?.Invoke();
            print("База разрушена!");
        }
    }
}
