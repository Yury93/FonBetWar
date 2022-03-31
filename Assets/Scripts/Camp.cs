using System;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [Range(0,9)]
    [SerializeField] private int energy;

    public event Action OnDestroyCamp;
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
