using UnityEngine;

public class RoomZone : MonoBehaviour
{
    private ClosingWall[] _walls;
    
    public int _enemyCount;
    private bool _canBeOpened =false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        _walls = GetComponentsInChildren<ClosingWall>();
    }
    private void Update()
    {
        if(_enemyCount == 0 && _canBeOpened)
        {
            for (int i = 0; i < _walls.Length; i++)
            {
                _walls[i].wall.SetActive(false);
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
