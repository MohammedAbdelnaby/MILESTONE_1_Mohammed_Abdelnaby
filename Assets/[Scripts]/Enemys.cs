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

    [SerializeField]
    private Material blue;

    [SerializeField]
    private Material orange;

    [SerializeField]
    private SkinnedMeshRenderer body;

    [SerializeField]
    private MeshRenderer hair;

    private bool ReverseTime;

    // Start is called before the first frame update
    void Start()
    {
        body.material = blue;
        hair.material = blue;
        EnemyManger.Instance.Enemy = gameObject;
        GameObject bullet = Instantiate(Bullet, SpawnPointBullet.transform.position, transform.rotation);
        BulletManger.Instance.EnemyBullets = bullet;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(Player.transform); // we rotate the rotationAngle 
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0.0f);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            if (ReverseTime == true)
            {
                body.material = blue;
                hair.material = blue;
                transform.position = new Vector3(transform.position.x - ReverseOffset.X, transform.position.y, transform.position.z);
                ReverseTime = false;
            }
            else
            {
                body.material = orange;
                hair.material = orange;
                transform.position = new Vector3(transform.position.x + ReverseOffset.X, transform.position.y, transform.position.z);
                ReverseTime = true;
            }

        }
    }
}
