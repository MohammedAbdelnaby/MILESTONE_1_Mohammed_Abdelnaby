using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVeiw : MonoBehaviour
{
    //https://www.youtube.com/watch?v=j1-OyLo77ss 

    public float Radius;

    [Range(0,360)]
    public float Angle;

    public GameObject PlayerRef;
    public Vector3 OffSet;
    public LayerMask TargetMask;
    public LayerMask ObstructionMask;

    public bool CanSeePlayer;

    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    IEnumerator FOVRoutine()
    {
        while (true)
        {
            FieldOfVeiwCheck();
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void FieldOfVeiwCheck()
    {
        Collider[] RangeChecks = Physics.OverlapSphere(transform.position + OffSet, Radius, TargetMask);

        if (RangeChecks.Length != 0)
        {
            Transform target = RangeChecks[0].transform;
            Vector3 DirectionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, DirectionToTarget) < Angle/2)
            {
                float DistanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position + OffSet, DirectionToTarget, DistanceToTarget, ObstructionMask))
                {
                    CanSeePlayer = true;
                }
                else
                {
                    CanSeePlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
            }
        }
        else if(CanSeePlayer)
        {
            CanSeePlayer = false;
        }
    }
}
