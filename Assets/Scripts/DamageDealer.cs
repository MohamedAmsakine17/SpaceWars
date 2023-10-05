using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float _damage = 5f;

    public float GetDamage()
    {
        return _damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
