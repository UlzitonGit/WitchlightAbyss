using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    private int _currentLevel;
    private void Start()
    {
        _currentLevel = PlayerPrefs.GetInt("Level");
        if( _currentLevel == 0 )
        {
            _currentLevel = 1;
            PlayerPrefs.SetInt("Level", _currentLevel);
        }
    }
    public void PlayNew(int scene)
    {
        _currentLevel = scene;
        PlayerPrefs.SetInt("Level", _currentLevel);
        SceneManager.LoadScene(scene);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(_currentLevel);
    }
}
