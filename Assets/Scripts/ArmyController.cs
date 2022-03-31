using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class ArmyController : MonoBehaviour
{
    /// ///////////////////////////////
    [Header("Combat unit parameters")]
    [SerializeField] private int currentHp;
    public int CurrentHP => currentHp;
    [SerializeField] private float speed;
    public float Speed => speed;
    [SerializeField] private bool ai;
    public bool AI => ai;
    /// ///////////////////////////////
    [Header("Auto work")]
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    public enum StateMode
    {
        Idle,
        Move,
        AttackBase,
        AttackArmy
    }

    [SerializeField] private StateMode state = StateMode.Idle;
    public StateMode State => state;

    private GameObject camp, enemy;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(state == StateMode.Idle)
        {
            rb.drag = 10000;
        }
        if (state == StateMode.Move)
        {
            Move();
        }
        if (state == StateMode.AttackBase)
        {
            FindBase();
            if(camp)
            {
                DirectionOfGameObject(camp);
            }
        }
        if (state == StateMode.AttackArmy)
        {
            FindArmy();
            if (enemy)
            {
                DirectionOfGameObject(enemy);
            }
        }
    }
    private void FindArmy()
    {
        camp = null;
        if (!AI && !enemy)
        {
            enemy = GameObject.FindGameObjectWithTag("EnemyArmy");
        }
        else if (AI && !enemy)
        {
            enemy = GameObject.FindGameObjectWithTag("PlayerArmy");
        }
    }
    private void FindBase()
    {
        enemy = null;
        if (!AI && !camp)
        {
            camp = GameObject.FindGameObjectWithTag("EnemyBase");
        }
        else if (AI && !camp)
        {
            camp = GameObject.FindGameObjectWithTag("PlayerBase");
        }
    }
    private void Move()
    {
        rb.drag = 0.3f;
        if (!AI)
        {
            Rb.AddForce(Vector2.right * Speed * Time.deltaTime);
        }
        else if (AI)
        {
            Rb.AddForce(Vector2.left * Speed * Time.deltaTime);
        }
    }

    /// <summary>
    /// метод вычисляет направление до объекта и идёт к нему
    /// </summary>
    /// <param name="obj"></param>
    private void DirectionOfGameObject(GameObject obj)
    {
        var direction = obj.transform.position - transform.position;
        direction.z = transform.position.z;
        var distance = direction.magnitude;
        print(distance);
        ////TODO: танк, солдат и так далее, какая дистанция 
        if (distance >= 1)
        {
            rb.drag = 0.3f;
            rb.AddForce(direction * speed * Time.deltaTime);
        }
        else
        {
            Debug.Log($"Остановился перед {obj.name}");
            rb.drag = 10000;
        }
    }
    public void SetState(string writeState)
    {
        switch(writeState)
        {
            case "Idle":
                {
                    state = StateMode.Idle;
                    break;
                }
            case "Move":
                {
                    state = StateMode.Move;
                    break;
                }
            case "AttackBase":
                {
                    state = StateMode.AttackBase;
                    break;
                }
            case "AttackArmy":
                {
                    state = StateMode.AttackArmy;
                    break;
                }
        }
    }
}