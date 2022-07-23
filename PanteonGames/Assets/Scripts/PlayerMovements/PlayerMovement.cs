using System.Collections;
using UnityEngine;
using  DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    private SwerveInputSystem _swerveInputSystem;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject paintWall;
    
    private Transform _p;
    private static readonly int İsGameStart = Animator.StringToHash("isGameStart");
    void Start()
    {
        _swerveInputSystem =GetComponent<SwerveInputSystem>();
        DOTween.Init();
    }


    void Update()
    {
        var velo = rb.velocity;
        velo.z = speed;
        velo.x = _swerveInputSystem.MoveFactorX;
        
        if (animator.GetBool(İsGameStart))
        {
            rb.velocity = velo;
        }
        if (Mathf.Abs(transform.position.x)>8.35f || transform.position.y<-1f)
        {

            transform.position= new Vector3(-0.3f, 0, -25f);
        }
        
    }
   

    private void OnTriggerStay(Collider other)
    {
        if (_p != other.transform && other.CompareTag("RotatingPlatform"))
        {
           
           
            var delta = other.transform.position - transform.position;
            var angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

            var transform1 = transform;
            var euler = transform1.eulerAngles;
            euler.z = angle + 90;
            transform1.eulerAngles = euler;
            
            transform1.parent = other.transform;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 dir = transform.position + (collision.contacts[0].normal * 10f);
            
            transform.DOMove(dir,2f);
    
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position= new Vector3(-0.3f, 0, -25f);
        }
        if (collision.gameObject.CompareTag("Finish"))
        {
            animator.SetBool(İsGameStart,false);
            paintWall.SetActive(true);
            UIManager.instance.isPlayerFinishedGame = true;
            StartCoroutine(WaitForAnimation());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RotatingPlatform"))
        {
            var transform1 = transform;
            var euler = transform1.eulerAngles;
            euler.z = 0;
            transform1.eulerAngles = euler;
            _p = null;
            transform1.parent = null;
            
        }
    }

    IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(5f);
        UIManager.instance.GameFinished();
    }
    
   
}
