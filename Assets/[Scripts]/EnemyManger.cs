using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public static EnemyManger Instance;
    public List<GameObject> enemys;

    public GameObject Enemy
    {
        set
        {
            enemys.Add(value);
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

        enemys = new List<GameObject>();
    }
}
