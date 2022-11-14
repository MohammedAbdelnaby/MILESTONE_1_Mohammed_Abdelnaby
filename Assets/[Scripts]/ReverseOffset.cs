using UnityEngine.SceneManagement;
[System.Serializable]
public struct ReverseOffset
{
    public static float X = (SceneManager.GetActiveScene().name == "Level_1") ? 28.09f : 137.5f;
}
