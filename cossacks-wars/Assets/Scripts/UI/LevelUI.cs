using Assets.Scripts.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public int LevelIndex;
    public string SceneName;

    public GameObject Marker;

    public Material PassedMaterial;
    public Material CurrentMaterial;
    public Material FutureMaterial;

    private void Start()
    {
        var renderer = Marker.GetComponent<MeshRenderer>();
        var level = PlayerPrefs.GetInt(PlayerPrefsKeys.LevelReached, 1);
        if (renderer != null)
        {
            if (level == LevelIndex)
            {
                renderer.material = CurrentMaterial;
            }
            else if (level > LevelIndex)
            {
                renderer.material = PassedMaterial;
            }
            else
            {
                renderer.material = FutureMaterial;
            }
        }
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene(SceneName);
    }
}
