using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    private PlayerMovement _player;
    void Start()
    {
        _player = FindAnyObjectByType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.transform.position);
        transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, 0);
    }
}
