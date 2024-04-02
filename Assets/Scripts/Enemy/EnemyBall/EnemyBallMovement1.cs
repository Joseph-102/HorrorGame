using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallMovement : MonoBehaviour
{
    public Transform playerTransform;
    public int enemySpeed = 10;
    bool isOnGround = true;
    bool isMoving = false;
    private Rigidbody rb;
    public Transform gizmo;
    //public Animator animator;
    private Vector3 playerPos;
    //public int enemy_radius = 10;
    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log(isOnGround);

        

        gizmo.transform.LookAt(new Vector3(playerTransform.position.x,0,playerTransform.position.z), Vector3.up);
        rb.AddForce(gizmo.transform.forward * 100 * Time.deltaTime);
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, 0, playerTransform.position.z), enemySpeed * Time.deltaTime);
        //playerPos = new Vector3(playerTransform.position.x, 0, playerTransform.position.z);
        //if (isMoving)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, 0, playerTransform.position.z), enemySpeed * Time.deltaTime);
        //}
        //if (isOnGround )
        //{
        //    animator.SetInteger("Transition", 0);
        //}
        //else
        //{
        //    animator.SetInteger("Transition", 1);
        //}
        //if((playerTransform.position - transform.position)
        //if(Vector3.Magnitude(new Vector3(playerTransform.position.x, 0, playerTransform.position.z) - transform.position) < enemy_radius)
        //{
        //    animator.SetInteger("Transition", 0);
        //    isMoving = false;
        //}
        //else
        //{
        //    animator.SetInteger("Transition", 1);
        //    isMoving = true;
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(transform.forward) * -10000);
            //Debug.Log("Collided");
        }
        

        //if (collision.gameObject.CompareTag("Bullet"))
        //{
        //    animator.SetInteger("Transition", 3);
        //}
    }

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("MoonSurface"))
    //    {
    //        isOnGround = false;
    //    }
    //    Debug.Log("Exited");

    //    if (collision.gameObject.CompareTag("Bullet"))
    //    {
    //        animator.SetInteger("Transition", 3);
    //    }
    //}
}
