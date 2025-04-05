using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject[] textNps;
    private bool isPlayerInTrigger = false;
    private int count = 1;
    void Start()
    {
        foreach (var t in textNps)
        { 
            t.SetActive(false); 
        }
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < textNps.Length; i++)
            {
                if (count == i)
                {
                    textNps[i].SetActive(true);
                }
                else if (count > textNps.Length)
                {
                    textNps[i].SetActive(false);
                }
                else
                {
                    textNps[i].SetActive(false);
                }
            }
            count++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
        textNps[0].SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isPlayerInTrigger = false;
        count = 1;
        foreach (var t in textNps)
        { 
            t.SetActive(false); 
        }
    }
}
