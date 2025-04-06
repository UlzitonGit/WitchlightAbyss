using UnityEngine;

public class ManaPoints : MonoBehaviour
{
    private ManaMananger _manaMananger;
    [SerializeField] private int _plusMana = 3;
    private float _magnetRange = 4;
    private float _flySpeed;
    private void Start()
    {
        _flySpeed = Random.Range(2f, 3.5f);
        _manaMananger = FindAnyObjectByType<ManaMananger>();
    }
    void Update()
    {
        float dist = Vector2.Distance(transform.position, _manaMananger.transform.position);
        if (dist < _magnetRange)
        {
            transform.position = Vector2.Lerp(transform.position, _manaMananger.transform.position, _flySpeed * Time.deltaTime);
        }
        if(dist < 0.5f)
        {
            _manaMananger.Plus(_plusMana);
            Destroy(gameObject);
        }
    }
}
