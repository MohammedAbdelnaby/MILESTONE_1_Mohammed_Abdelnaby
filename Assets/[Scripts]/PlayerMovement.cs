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

    private Vector2 turn;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        turn.x += Input.GetAxis("Mouse X");
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x * turnSpeed, 0);
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && BulletAmount != 0 && ReverseTime != true)
        {
            BulletAmount--;
            GameObject bullet = Instantiate(Bullet, SpawnPointBullet.transform.position, transform.rotation);
            BulletManger.Instance.PlayerBullets = bullet;
            BulletCount++;
        }
        else if (ReverseTime  && Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < BulletCount; i++)
            {
                Debug.Log(i);
                if (BulletManger.Instance.bullets[i] != null && !BulletManger.Instance.bullets[i].GetComponent<Bullet>().Reverse)
                {
                    BulletManger.Instance.bullets[i].GetComponent<Bullet>().ReverseBullet();
                    break;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (ReverseTime == true)
            {
                transform.position = new Vector3(transform.position.x - 40.0f, transform.position.y, transform.position.z);
                ReverseTime = false;
            }
            else
            {
                transform.position = new Vector3(transform.position.x + 40.0f, transform.position.y, transform.position.z);
                ReverseTime = true;
            }

        }

    }
}
