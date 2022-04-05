using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class CombatUnit : MonoBehaviour
{
    /// ///////////////////////////////
    [Header("Combat unit parameters")]
    [SerializeField] private int currentHp;
    public int CurrentHP => currentHp;
    [SerializeField] private float speed;
    public float Speed => speed;
    [SerializeField] private float distanceStop;
    public float DistanceAttack => distanceStop;
    [SerializeField] private bool ai;
    public bool AI => ai;
    /// ///////////////////////////////
    [Header("Auto work")]
    [SerializeField] private Rigidbody2D rb;
    public Rigidbody2D Rb => rb;
    public enum StateMode
    {
        MoveBase,
        MoveArmy
    }

    [SerializeField] private StateMode state = StateMode.MoveBase;
    public StateMode State => state;

    private GameObject camp, enemy;
  
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (state == StateMode.MoveBase)
        {
            FindBase();
            
            if(camp)
            {
                DirectionOfGameObject(camp);
            }
        }
        if (state == StateMode.MoveArmy)
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
    private void DirectionOfGameObject(GameObject obj)
    {
        var direction = obj.transform.position - transform.position;
        direction.z = transform.position.z;
        var distance = direction.magnitude;
        
        if (distance > distanceStop)
        {
            rb.drag = 0.3f;
            rb.AddForce(direction * speed * Time.deltaTime);

        }
        else
        {
            rb.drag = 10000;//остановка
        }
    }
    public void SetState(string writeState)
    {
        switch(writeState)
        {
            case "MoveBase":
                {
                    state = StateMode.MoveBase;
                    break;
                }
            case "MoveArmy":
                {
                    state = StateMode.MoveArmy;
                    break;
                }
        }
    }
    public void SetProperties (int hp, float speedUnit,float distanceStop, bool aI, Sprite sprite)
    {
        this.currentHp = hp;
        this.speed = speedUnit;
        this.distanceStop = distanceStop;
        this.ai = aI;
        GetComponentInChildren<SpriteRenderer>().sprite = sprite;
    }
}