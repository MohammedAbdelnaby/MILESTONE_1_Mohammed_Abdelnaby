using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(FieldOfVeiw))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfVeiw fov = (FieldOfVeiw)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position + fov.OffSet, Vector3.up, Vector3.forward, 360, fov.Radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.transform.eulerAngles.y, -fov.Angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.transform.eulerAngles.y, fov.Angle / 2);

        Handles.color = Color.yellow;
        Handles.DrawLine(fov.transform.position + fov.OffSet, fov.transform.position + fov.OffSet + viewAngle01 * fov.Radius);
        Handles.DrawLine(fov.transform.position + fov.OffSet, fov.transform.position + fov.OffSet + viewAngle02 * fov.Radius);

        if (fov.CanSeePlayer)
        {
            Handles.color = Color.green;
            Handles.DrawLine(fov.transform.position + fov.OffSet, fov.PlayerRef.transform.position + fov.OffSet);
        }
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDeg)
    {
        angleInDeg += eulerY;

        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
    }
}
