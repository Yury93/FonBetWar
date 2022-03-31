using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float m_Radius = 5f;
    private ArmyController m_Target = null;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private float rateOfShooting;
    private float startRate;
    [SerializeField] private bool ai;
    private void Start()
    {
        startRate = rateOfShooting;
    }
    private void Update()
    {
        DetectedEnemy();
    }
    private void DetectedEnemy()
    {
        if (m_Target)
        {
            Vector2 targetVector = m_Target.transform.position - transform.position;
            if (targetVector.magnitude <= m_Radius)
            {
                Fire();
            }
            else
            {
                m_Target = null;
            }
        }
        else
        {
            var enter = Physics2D.OverlapCircle(transform.position, m_Radius);

            if (enter && enter.TryGetComponent<ArmyController>(out var enemy))
            {
                if (enemy)
                {
                    if (enemy.AI == false && ai)
                    {
                        m_Target = enemy;
                    }
                    else if (enemy.AI && ai == false)
                    {
                        m_Target = enemy;
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
            var projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Vector2 targetVector = m_Target.transform.position - transform.position;
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
        Gizmos.DrawWireSphere(transform.position, m_Radius);
    }
}
