using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManger : MonoBehaviour
{
    public static BulletManger Instance;
    public List<GameObject> bullets;
    public List<GameObject> ebullets;

    public GameObject PlayerBullets
    {
        set
        {
            bullets.Add(value);
        }
    }
    public GameObject EnemyBullets
    {
        set
        {
            ebullets.Add(value);
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        bullets = new List<GameObject>();
        ebullets = new List<GameObject>();
    }
}
