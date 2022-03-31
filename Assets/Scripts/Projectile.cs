using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed => speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<ArmyController>();
        if (enemy)
        {
            Destroy(gameObject);
        }
    }
}
