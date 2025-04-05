using UnityEngine;

public class TotemRecovery : MonoBehaviour
{
    private PlayerHealth playerHp;
    private ManaMananger playerMn;
    void Start()
    {
        playerHp = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();
        playerMn = GameObject.FindWithTag("Player").transform.Find("GunMain").GetComponent<ManaMananger>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHp.GetHealth(100);
            playerMn.Plus(100);
        }
    }
}
