using TMPro;
using UnityEngine;

public class InventoryMananger : MonoBehaviour
{
    [SerializeField] private GameObject[] _cellsOutline;
    [SerializeField] private TextMeshProUGUI[] _cellsText;
    private PlayerHealth _health;
    [SerializeField] private int[] _healsCount;
    private int _currentCell = 0;
    public bool InInteractiveZone = false;
    private void Start()
    {
        _health = FindAnyObjectByType<PlayerHealth>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowCell(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowCell(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowCell(2);
        }
        if(Input.GetKeyDown(KeyCode.F) && !InInteractiveZone)
        {
            if (_healsCount[_currentCell] > 0)
            {
                _healsCount[_currentCell]--;
                _health.GetHealth((_currentCell + 1) * 10);
                _cellsText[_currentCell].text = _healsCount[_currentCell].ToString();
            }
        }
    }
    private void ShowCell(int cell)
    {
        _currentCell = cell;
        for (int i = 0; i < _cellsOutline.Length; i++)
        {
            if(i == _currentCell)
            {
                _cellsOutline[i].gameObject.SetActive(true);
            }
            else _cellsOutline[i].gameObject.SetActive(false);
        }
    }
    public void AddHeal(int heal)
    {
        _healsCount[heal]++;
        _cellsText[heal].text = _healsCount[heal].ToString();
    }
}
