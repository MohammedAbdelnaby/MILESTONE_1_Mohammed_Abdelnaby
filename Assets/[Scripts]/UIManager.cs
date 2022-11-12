using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text EnemysAlive;

    [SerializeField]
    private TMP_Text health;

    [SerializeField]
    private TMP_Text ammo;

    [SerializeField]
    private PlayerMovement Player;

    // Update is called once per frame
    void Update()
    {
        EnemyAlive();
        Health();
        Ammo();
    }

    private void EnemyAlive()
    {
        EnemysAlive.text = "Enemys Alive: " + EnemyManger.Instance.enemys.Count;
    }

    private void Health()
    {
        health.text = Player.Health.ToString();
    }
    private void Ammo()
    {
        ammo.text = Player.BulletAmount.ToString();
    }
}
