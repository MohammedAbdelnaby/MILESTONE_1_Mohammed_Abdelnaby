using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private GameObject BulletImpactPrefab;

    private GameObject BulletImpactNormal;

    private GameObject BulletImpactReverse;

    private string ObstacleName;

    private bool reverse = false;

    public bool Reverse
    {
        get { return reverse; }
        set { reverse = value; }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      
        if (!reverse)
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
        if (reverse)
        {
            return;
        }
        Destroy(BulletImpactNormal);
        Destroy(BulletImpactReverse);
        gameObject.SetActive(true);
        transform.position = new Vector3(transform.position.x + 40.0f, transform.position.y, transform.position.z);
        reverse = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle" && reverse != true)
        {
            BulletImpactNormal = Instantiate(BulletImpactPrefab, transform.position, transform.rotation);
            BulletImpactReverse = Instantiate(BulletImpactPrefab, new Vector3(transform.position.x + 40.0f, transform.position.y, transform.position.z), transform.rotation);
            ObstacleName = collision.gameObject.name;
            gameObject.SetActive(false);
        }
        else if (reverse == true && ObstacleName != collision.gameObject.name)
        {
            Destroy(gameObject);
        }

    }

}
