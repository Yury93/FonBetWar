using System;
using System.Collections;
using UnityEngine;

public class Camp : MonoBehaviour
{
    [SerializeField] private int hp;
    public int HP => hp;

    public static event Action OnDestroyCampEnemy, OnDestroyCampPlayer;
    [SerializeField] private bool ai;
    public bool AI => ai;
    private int getDamage;
    public int GetDamage => getDamage;
    public void DamageCamp(int damage)
    {
        hp -= damage;
        getDamage = damage;
        UIManager.Instance.Damage(gameObject.GetComponent<Camp>());
        if(hp <= 0)
        {
            AudioManager.Instance.AudioPlay("blastCamp");
            if (!ai)
            {
                OnDestroyCampEnemy?.Invoke();
               
            }
            else
            {
                OnDestroyCampPlayer?.Invoke();
               
            }
            EffectManager.Instance.CreateEffectDestroy(gameObject);
           
            Destroy(gameObject);

        }
    }
}
