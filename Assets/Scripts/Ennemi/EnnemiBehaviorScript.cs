using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemiBehaviorScript : MonoBehaviour {

    [SerializeField]
    private HealthbarScript m_hbScript;
    public HealthbarScript HbScript
    {
        get { return m_hbScript; }
        set { m_hbScript = value; }
    }

    [SerializeField]
    private HealthbarScript m_playerHbScript;
    public HealthbarScript PlayerHbScript
    {
        get { return m_playerHbScript; }
        set { m_playerHbScript = value; }
    }

    [SerializeField]
    private NavMeshAgent m_agent;
    public NavMeshAgent Agent
    {
        get { return m_agent; }
        set { m_agent = value; }
    }

    [SerializeField]
    private Transform m_player;
    public Transform Player
    {
        get { return m_player; }
        set { m_player = value; }
    }

    public enum ENNEMI_STATE
    {
        WALK,
        ATTACK,
        ENRAGE,
        FEAR
    }

    private ENNEMI_STATE currentState;
    private Vector3 randomDir;

    // Use this for initialization
    void Start () {
        currentState = ENNEMI_STATE.WALK;
        randomDir = new Vector3();
    }
	
	// Update is called once per frame
	void Update () {
        if (HbScript.Health <= 0.0f)
        {
            Destroy(gameObject);
        }

        switch(currentState)
        {
            case ENNEMI_STATE.WALK:
                if(Random.Range(0.0f, 10.0f) < 4.0f)
                {
                    randomDir = Random.onUnitSphere;
                }

                Vector3 p = transform.position + randomDir * 15.0f;

                Agent.SetDestination(p);

                float dist = Vector3.Distance(transform.position, Player.position);

                if(dist < 2.0f)
                {
                    currentState = ENNEMI_STATE.ATTACK;
                }
            break;

            case ENNEMI_STATE.ATTACK:
                Agent.SetDestination(Player.position);

                float dist2 = Vector3.Distance(transform.position, Player.position);

                if (dist2 < 1.5f)
                {
                    PlayerHbScript.takeDamages(4.0f);
                }

                if(PlayerHbScript.Health < 20.0f)
                {
                    currentState = ENNEMI_STATE.ENRAGE;
                }

                break;

            case ENNEMI_STATE.ENRAGE:
                Agent.SetDestination(Player.position);

                float dist3 = Vector3.Distance(transform.position, Player.position);

                if (dist3 < 1.5f)
                {
                    PlayerHbScript.takeDamages(8.0f);
                }

                if (PlayerHbScript.Health < 10.0f)
                {
                    currentState = ENNEMI_STATE.FEAR;
                }
                break;

            case ENNEMI_STATE.FEAR:
                Vector3 invDirPlayer = -(Player.position - transform.position).normalized;

                Agent.SetDestination(transform.position + invDirPlayer * 20.0f);
            break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Projectile"))
        {
            HbScript.takeDamages(5.0f + Random.Range(0.0f, 5.0f));
        }
    }
}
