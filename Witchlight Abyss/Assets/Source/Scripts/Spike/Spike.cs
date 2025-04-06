using System.Collections;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private float _duration;
    private void Start()
    {
        StartCoroutine(Activating());
    }
    IEnumerator Activating()
    {
        yield return new WaitForSeconds(_duration);
        _anim.SetTrigger("Activate");
        StartCoroutine(Activating());
    }
}
