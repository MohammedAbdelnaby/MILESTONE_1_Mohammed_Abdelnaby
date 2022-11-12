using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private GameObject BulletImpactPrefab;

    private GameObject BulletImpactNormal;

    private GameObject BulletImpactReverse;

    private string ObstacleName;

    private bool PlayerReveresed = false;

    public bool Reverse
    {
        get { return PlayerReveresed; }
        set { PlayerReveresed = value; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (!PlayerReveresed)
        {
            transform.Translate(Vector3.forward * Time.fixedDeltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.back * Time.fixedDeltaTime * speed);
        }

    }

    public void ReverseBullet()
    {
        if (PlayerReveresed)
        {
            return;
        }
        Destroy(BulletImpactNormal);
        Destroy(BulletImpactReverse);
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x + 40.0f, transform.position.y, transform.position.z);
        PlayerReveresed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerReveresed != true)
        {
            BulletImpactNormal = Instantiate(BulletImpactPrefab, transform.position, transform.rotation);
            BulletImpactReverse = Instantiate(BulletImpactPrefab, new Vector3(transform.position.x + ReverseOffset.X, transform.position.y, transform.position.z), transform.rotation);
            ObstacleName = collision.gameObject.name;
            gameObject.SetActive(false);
        }
        else if (PlayerReveresed == true && ObstacleName != collision.gameObject.name)
        {
            Destroy(gameObject);
        }

    }

}
