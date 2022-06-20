using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MonsterCtrl : MonoBehaviour
{
    //monster state info enum
    public enum State
    {
        IDLE,
        TRACE,
        ATTACK,
        DIE,
        PLAYERDIE
    }
    [SerializeField]
    private EndingSO endingSO;
    //monster's current state
    public State state = State.IDLE;
    //trace length
    public float traceDist = 10f;
    //attack length
    public float attackDist = 2f;
    //monster dead bool
    public bool isDie = false;

    private Transform monsterTransform;
    private Transform targetTransform;
    private NavMeshAgent agent;
    private Animator anim;

    //Get Animator Hash Value
    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");
    private readonly int hashHit = Animator.StringToHash("Hit");
    private readonly int hashPlayerDie = Animator.StringToHash("PlayerDie");
    private readonly int hashSpeed = Animator.StringToHash("Speed");
    private readonly int hashDie = Animator.StringToHash("Die");

    //blood Effect Prefab
    private GameObject bloodEffect;
    //monster's Hp
    private int initHp = 100;
    private int currentHp;
    void Awake()
    {
        monsterTransform = GetComponent<Transform>();
        targetTransform = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        bloodEffect = Resources.Load<GameObject>("BloodSprayEffect");
    }
    private void Update()
    {
        if (agent.remainingDistance >= 2f)
        {
            Vector3 dir = agent.desiredVelocity;
            Quaternion rot = Quaternion.LookRotation(dir);
            //monsterTransform.rotation =
        }
    }
    private void OnEnable()
    {
        currentHp = initHp;
        //check monster state function
        StartCoroutine(CheckMonsterState());
        //manage monster behaviour by state
        StartCoroutine(MonsterAction());
        state = State.IDLE;
        currentHp = initHp;
        isDie = false;
        agent.isStopped = false;
        GetComponent<CapsuleCollider>().enabled = true;
        Component[] components = GetComponentsInChildren<SphereCollider>();
        foreach (SphereCollider collider in components)
        {
            collider.enabled = true;
        }
        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());

    }
    IEnumerator CheckMonsterState()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if (state == State.DIE)
                yield break;
            //check monster and player distance
            float distance = Vector3.Distance(monsterTransform.position, targetTransform.position);

            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance <= traceDist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }

    }
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    agent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;
                case State.TRACE:
                    agent.SetDestination(targetTransform.position);
                    agent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;
                case State.ATTACK:
                    anim.SetBool(hashAttack, true);
                    break;
                case State.DIE:
                    isDie = true;
                    agent.isStopped = true;
                    anim.SetTrigger(hashDie);
                    GetComponent<CapsuleCollider>().enabled = false;
                    Component[] components = GetComponentsInChildren<SphereCollider>();
                    foreach (SphereCollider collider in components)
                    {
                        collider.enabled = false;
                    }
                    endingSO.killMonster++;
                    yield return new WaitForSeconds(3f);
                    this.gameObject.SetActive(false);
                    break;
                case State.PLAYERDIE:
                    StopAllCoroutines();

                    //추적정지
                    agent.isStopped = true;
                    anim.SetFloat(hashSpeed, Random.Range(0.8f, 1.3f));
                    anim.SetTrigger(hashPlayerDie);
                    break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BULLET"))
        {
            Destroy(collision.gameObject);
            anim.SetTrigger(hashHit);

            //attack collision position
            Vector3 pos = collision.GetContact(0).point;
            //총알 충돌 지점의 법선 백터
            Quaternion rot = Quaternion.LookRotation(-collision.GetContact(0).normal);

            ShowBlood(pos, rot);

            currentHp -= 10;
            if (currentHp <= 0)
            {
                state = State.DIE;
                GameMgr.GetInstance().DisplayScore(50);
            }
        }
    }

    void ShowBlood(Vector3 pos, Quaternion rot)
    {
        GameObject blood = Instantiate<GameObject>(bloodEffect, pos, rot, monsterTransform);
        Destroy(blood, 1f);
    }
    public void OnPlayerDie()
    {
        state = State.PLAYERDIE;
    }
    private void OnDrawGizmos()
    {
        if (state == State.TRACE)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(monsterTransform.position, traceDist);
        }
        if (state == State.ATTACK)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(monsterTransform.position, attackDist);
        }
    }
}
