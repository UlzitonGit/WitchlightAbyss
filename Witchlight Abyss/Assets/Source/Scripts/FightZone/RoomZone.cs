using UnityEngine;

public class RoomZone : MonoBehaviour
{
    private ClosingWall[] _walls;
    
    public int _enemyCount;
    private bool _canBeOpened = false;
    public bool _open;
    private LevelZone _levelZone;
    void Start()
    {
        _open = false;
        _levelZone = GetComponentInParent<LevelZone>();
        _walls = GetComponentsInChildren<ClosingWall>();
    }
    private void Update()
    {
        if(_enemyCount == 0 && _canBeOpened)
        {
            for (int i = 0; i < _walls.Length; i++)
            {
                _walls[i].wall.SetActive(false);
                _open = true;
                _levelZone.CheckClearLevel();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < _walls.Length; i++)
            {
                _walls[i].wall.SetActive(true);
            }
            _canBeOpened = true;
        }
        
    }

}
