using UnityEngine;

public class OverlappingObjects : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
}
