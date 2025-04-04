using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
   
    public void Play(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
