using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private GameObject SpawnPointBullet;

    [SerializeField]
    private GameObject Bullet;

    private bool ReverseTime;

    // Start is called before the first frame update
    void Start()
    {
        EnemyManger.Instance.Enemy = gameObject;
        GameObject bullet = Instantiate(Bullet, SpawnPointBullet.transform.position, transform.rotation);
        BulletManger.Instance.EnemyBullets = bullet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player.transform);
    }

    private void Update()
    {
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
