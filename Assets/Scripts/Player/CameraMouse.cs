using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouse : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    public Transform gunHolder;
    public GameObject player;
    private float xRotation = 0;
    //[SerializeField] private int sensitivityX = 300;
    //[SerializeField] private int sensitivityY = 300;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turnPlayer();
    }

    private void turnPlayer()
    {
        turn.x = Input.GetAxisRaw("Mouse X");
        turn.y = Input.GetAxisRaw("Mouse Y");

        xRotation -= turn.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        player.transform.Rotate(Vector3.up * turn.x);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        gunHolder.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}
