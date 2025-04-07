using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private CinemachineVirtualCamera _camera;
    [SerializeField] private Animator _anim;
    bool _done = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_done)
        {
            _done = true;
            _anim.SetTrigger("Play");
            _movement._canWalk = false;
            _movement.enabled = false;
            _camera.Follow = _target.transform;
        }
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

}
