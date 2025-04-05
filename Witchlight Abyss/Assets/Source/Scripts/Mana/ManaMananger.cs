using UnityEngine;
using UnityEngine.UI;

public class ManaMananger : MonoBehaviour
{
    [HideInInspector] public int Mana { get; private set; }
    [HideInInspector] public int MaxMana { get; private set; } = 100;
    [SerializeField] private Image _manaBar;
    private void Start()
    {
        Mana = MaxMana;
    }
    public void MinusMana(int count)
    {
        Mana -= count;
        _manaBar.fillAmount = Mana * 0.01f;
    }
    public void Plus(int count)
    {
        if(Mana >= MaxMana) return;
        Mana += count;
        _manaBar.fillAmount = Mana * 0.01f;
    }
}
