using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float turnSpeed = 5.0f;


    [SerializeField]
    private GameObject Bullet;

    [SerializeField]
    private int BulletAmount = 5;

    [SerializeField]
    private GameObject SpawnPointBullet;

    private bool ReverseTime = false;

    private int BulletCount = 0;

    private Camera camera;
    private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        Fire();
        Reverse();
    }

    private void Movement()
    {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        float x = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
        camera.transform.localRotation = Quaternion.Euler(Mathf.Clamp(-turn.y * turnSpeed, -45.0f, 45.0f), turn.x * turnSpeed, 0);
        transform.localRotation = Quaternion.Euler(0.0f, turn.x * turnSpeed, 0);
        transform.Translate(transform.right * x + transform.forward * z);
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0) && BulletAmount != 0 && ReverseTime != true)
        {
            BulletAmount--;
            GameObject bullet = Instantiate(Bullet, SpawnPointBullet.transform.position, camera.transform.rotation);
            BulletManger.Instance.PlayerBullets = bullet;
            BulletCount++;
        }
        else if (ReverseTime && Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < BulletCount; i++)
            {
                if (BulletManger.Instance.bullets[i] != null && !BulletManger.Instance.bullets[i].GetComponent<Bullet>().Reverse)
                {
                    BulletManger.Instance.bullets[i].GetComponent<Bullet>().ReverseBullet();
                    break;
                }
            }
        }
    }

    private void Reverse()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (ReverseTime == true)
            {
                transform.position = new Vector3(transform.position.x - ReverseOffset.X, transform.position.y, transform.position.z);
                ReverseTime = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x + ReverseOffset.X, transform.position.y, transform.position.z);
                ReverseTime = true;
            }
        }
    }
}
