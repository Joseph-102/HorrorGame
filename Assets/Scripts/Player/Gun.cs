using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput input = null;
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private void Awake()
    {
        input = new PlayerInput();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Fire.performed += GunFiredPerformed;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Fire.performed -= GunFiredPerformed;
    }

    private void GunFiredPerformed(InputAction.CallbackContext value)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.transform.forward * 1000);
        StartCoroutine(DestroyBulletAfterTimelimit(bullet));
    }

    private IEnumerator DestroyBulletAfterTimelimit(GameObject bullet)
    {
        yield return new WaitForSeconds(4);
        Destroy(bullet);
    }
}
