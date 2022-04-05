using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float radius = 5f;
    [SerializeField] private GameObject target = null;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float rateOfShooting;
    private float startRate;
    [SerializeField] private bool ai;
    [SerializeField] private Transform transformSpawn;
    
    private void Start()
    {
        startRate = rateOfShooting;
        
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
                //target = null;
            }
        }
        else
        {
            var enter = Physics2D.OverlapCircle(transform.position, radius);

            if (enter && enter.TryGetComponent<CombatUnit>(out var enemy))
            {
                if (enemy)
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
            
           else if (enter && enter.TryGetComponent<Camp>(out var camp))
            {
                if (camp)
                {
                    if (camp.AI == false && ai)
                    {
                        target = camp.gameObject;
                    }
                    else if (camp.AI && ai == false)
                    {
                        target = camp.gameObject;
                    }
                }
            }
            else { return; }
        }
    }

    private void Fire()
    {
        if (rateOfShooting < 0)
        {
           
            var projectile = Instantiate(projectilePrefab, transformSpawn.position, Quaternion.identity);
            Vector2 targetVector = target.transform.position - transform.position;

            float angle = Vector3.Angle(transformSpawn.position, target.transform.position);
            transformSpawn.transform.rotation = Quaternion.Euler(0,0,angle);
            
            projectile.GetComponent<Rigidbody2D>().AddForce(targetVector * projectile.Speed * Time.deltaTime, ForceMode2D.Impulse);

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
