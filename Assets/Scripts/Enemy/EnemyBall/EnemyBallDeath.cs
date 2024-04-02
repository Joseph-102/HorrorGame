using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyBallDeath : MonoBehaviour
{
    // Start is called before the first frame update
    private int health = 5;
    public GameObject[] Explosions;
    private int ExpoNo; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Debug.Log("health reduced");
            health--;
            if (health <= 0)
            {
                Explosion();
            }
        }
    }

    private void Explosion()
    {
        //int expoNo = ExpoNo;
        ExpoNo = Random.Range(0,5);
        Instantiate(Explosions[ExpoNo], transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
