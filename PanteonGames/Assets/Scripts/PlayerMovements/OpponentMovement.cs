using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using  DG.Tweening;

public class OpponentMovement : MonoBehaviour
{
    private NavMeshAgent _opponent;
    private Vector3 _target;
    private Rigidbody _rb;
   
    [SerializeField] private Animator animator;
    private static readonly int İsGameStart = Animator.StringToHash("isGameStart");

    private void Start()
    {
        
        _rb = GetComponent<Rigidbody>();
        _opponent = GetComponent<NavMeshAgent>();
        animator.SetBool(İsGameStart,false);
        _opponent.speed = 0;


    }

    private void Update()
    {
        if (_opponent.remainingDistance <= _opponent.stoppingDistance && UIManager.instance.isGameStart)
        {
            SetRandomTarget();
        }

        if (Mathf.Abs(transform.position.x)>8.35f)
        {
            StartAgain();
            Debug.Log("kız değdi");
        }
        
    }

    private void SetRandomTarget()
    {
        _target = new Vector3(Random.Range(-7, 7), transform.position.y, transform.position.z + 20);

        _opponent.SetDestination(_target);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StartAgain();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             Vector3 dir = transform.position + (collision.contacts[0].normal * 5f);
             transform.DOMove(dir, 2f);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
           
            animator.SetBool(İsGameStart,false);
            GetComponent<CapsuleCollider>().enabled = false;
            _rb.velocity = new Vector3(0, 0, 0);
            _opponent.speed = 0;
        }

    }
    public void OpponentGameStart()
    {
        animator.SetBool(İsGameStart,true);
        SetRandomTarget();
        _opponent.speed = 3.5f;
    }
    
    public void StartAgain()
    {
        Vector3 dir = new Vector3(0, 0.55f, -28f);
        _opponent.SetDestination(dir);
           
        transform.position = dir;
    }
    
    
}
