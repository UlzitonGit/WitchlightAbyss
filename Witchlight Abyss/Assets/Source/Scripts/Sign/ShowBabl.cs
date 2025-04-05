using UnityEngine;
using UnityEngine.InputSystem;

public class ShowBabl : MonoBehaviour
{
    [SerializeField] private GameObject bablCanvas;
    private bool isPlayerInTrigger = false;

    void Start()
    {
        bablCanvas.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
            {
                bablCanvas.SetActive(true);
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
        bablCanvas.SetActive(false);
    }
}
