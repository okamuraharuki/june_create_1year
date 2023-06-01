using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_bullet : MonoBehaviour, Istatus
{
    [SerializeField] int MaxHp = 200;
    [SerializeField]int FullEnergy = 100;
    int hp;
    int Energy;
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = Mathf.Clamp(value, 0, MaxHp);

            if (hp <= 0)
            {
                Death();
            }
        }
    }
    public void Start()
    {
        Hp = MaxHp;
        Energy = FullEnergy;
    }
    public void Damage(int damage)
    {
        Hp -= damage;  
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    public void Electric(int energy) 
    {
        Energy -= energy;
    }
}
