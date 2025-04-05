using UnityEngine;

public class Heal : MonoBehaviour
{
    [SerializeField] private int _healNumber;
    private InventoryMananger _inventoryMananger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _inventoryMananger = FindAnyObjectByType<InventoryMananger>();
            _inventoryMananger.AddHeal(_healNumber);
            Destroy(gameObject);
        }
    }
}
