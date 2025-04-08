using Unity.VisualScripting;
using UnityEngine;

public class LevelZone : MonoBehaviour
{
    private RoomZone[] _rooms;
    [SerializeField] private ClosingWall[] _walls;

    private int count = 0;
    void Start()
    {
        _rooms = GetComponentsInChildren<RoomZone>();
        for (int i = 0; i < _walls.Length; i++)
        {
            _walls[i].wall.SetActive(true);
        }
    }

    public void CheckClearLevel()
    {
        for (int i = 0; i < _rooms.Length; i++)
        {
            if (_rooms[i]._open)
            {
                count ++;
            }
        }
        if (count == _rooms.Length)
        {
            for (int j = 0; j < _walls.Length; j++)
            {
                _walls[j].wall.SetActive(false);
            }
        }
        count = 0;
        
    }
}
