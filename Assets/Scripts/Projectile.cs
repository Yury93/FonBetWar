using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


    public class Projectile : MonoBehaviour
    {
    [SerializeField] private bool ai;//
    [SerializeField] private float velocity;
    public float Velocity => velocity;
    [SerializeField] private float lifeTime;
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Camp>(out var camp))
        {
            if(ai != camp.AI)
            {
                camp.DamageCamp(10);
                Destroy(gameObject);
            }
            
        }
        if (collision.TryGetComponent<Unit>(out var unit))
        {
            if (ai != unit.AI)
            {
                unit.DamageUnit(10);
                Destroy(gameObject);
            }
        }
    }
    public void SetAI(bool aiProjectile)
    {
        ai = aiProjectile;
    }
}

