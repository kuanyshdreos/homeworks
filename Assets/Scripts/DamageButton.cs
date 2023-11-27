using UnityEngine;
using UnityEngine.UI;

public class DamageButton : MonoBehaviour
{
    public SimpleHealthSystem healthSystem;

    public void InflictDamage()
    {
        healthSystem.TakeDamage(10f);
    }
}