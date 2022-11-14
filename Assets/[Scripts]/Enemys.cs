using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemys : MonoBehaviour
{

    [SerializeField]
    private GameObject Player;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private FieldOfVeiw Fov;

    [SerializeField]
    private int Health;

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
        animator = GetComponent<Animator>();
        Fov = GetComponent<FieldOfVeiw>();
        InvokeRepeating("Fire", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetBool("CanSeePlayer", Fov.CanSeePlayer);
        if (Fov.CanSeePlayer)
        {
            transform.LookAt(Player.transform); // we rotate the rotationAngle 
            transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0.0f); 
        }
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

    private void Fire()
    {
        if (Fov.CanSeePlayer)
        {
            if (!ReverseTime)
            {
                GameObject bullet = Instantiate(Bullet, SpawnPointBullet.transform.position, transform.rotation);
                BulletManger.Instance.EnemyBullets = bullet;
            }
            else if (ReverseTime)
            {
                for (int i = 0; i < BulletManger.Instance.ebullets.Count; i++)
                {
                    if (BulletManger.Instance.ebullets[i] != null && !BulletManger.Instance.ebullets[i].GetComponent<Bullet>().Reverse)
                    {
                        BulletManger.Instance.ebullets[i].GetComponent<Bullet>().ReverseBullet();
                        break;
                    }
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Debug.Log(Health);
            if (Health <= 0)
            {
                EnemyManger.Instance.enemys.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
            Health -= 25;
        }
    }
}
