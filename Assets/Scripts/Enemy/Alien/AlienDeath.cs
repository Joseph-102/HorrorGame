using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AlienDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 5;
    public bool isDead = false;
    public RectTransform healthBar;
    private RagDoll ragdoll;
    //public GameObject[] Explosions;
    //private int ExpoNo; 
    void Start()
    {
        ragdoll = GetComponent<RagDoll>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && health > 0)
        {
            //Debug.Log("health reduced Alien");
            health--;
            healthBar.localScale -= new Vector3(0.2f,0,0);
            if (health <= 0)
            {
                Death();
            }
        }
    }

    private void Death()
    {
        ragdoll.RigidBodyActivate();
        //Debug.Log("Dies");
        //GetComponent<Animator>().SetBool("isAlive", false);
        isDead = true;
        //Invoke("DestroyObjectDelayed", 3f);
    }
    void DestroyObjectDelayed()
    {
        Destroy(gameObject);
    }
}