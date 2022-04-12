using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private GameObject target;
    private GameObject startTarget;
    public GameObject Target => target;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float rateOfShooting;
    private float startRate;
    [SerializeField] private bool ai;
    
    private void Start()
    {
        startRate = rateOfShooting;
        startTarget = target;
        
    }
    private void Update()
    {
        TargetAttack();
    }
    private void TargetAttack()
    {
        if (target)
        {
            Vector2 targetVector = target.transform.position - transform.position;
            if (targetVector.magnitude <= radius)
            {
                Fire();
            }
            else
            {
                target = null;
            }
        }
        if(!target)
        {
            var enter = Physics2D.OverlapCircle(transform.position, radius);
            
            if (enter)
            {
                if (enter.TryGetComponent<Camp>(out var camp))
                {
                    if (camp.AI == true && !ai)
                    {
                        target = camp.gameObject;
                    }
                    else if (!camp.AI && ai == true)
                    {
                        target = camp.gameObject;
                    }
                }
                else if (enter.TryGetComponent<CombatUnit>(out var enemy))
                {

                    if (enemy.AI == false && ai)
                    {
                        target = enemy.gameObject;
                    }
                    else if (enemy.AI && ai == false)
                    {
                        target = enemy.gameObject;
                    }
                }
            }
            //else { return; }
        }
    }
   
    private void Fire()
    {
        if (rateOfShooting < 0)
        {
            AudioManager.Instance.AudioPlay("shot");
            var dir = transform.position - target.transform.position;
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.Rb.AddForce(-dir * projectile.Velocity * Time.deltaTime, ForceMode2D.Impulse);
            projectile.SetAI(ai);
            rateOfShooting = startRate;
        }
        else
        {
            rateOfShooting -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void RadiusAttack(float r)
    {
        radius = r;
    }
}
