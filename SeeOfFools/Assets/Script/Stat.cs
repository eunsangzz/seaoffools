using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public EnemyType type { get; }
    public string name { get; set; }
    public int maxHp { get; set; }
    public int curhp { get; set; }
    public int Damage { get; set; }

    public Stat()
    {

    }

    public Stat(EnemyType type,string name, int maxHp, int Damage)
    {
        this.type = type;
        this.name = name;
        this.maxHp = maxHp;
        curhp = maxHp;
        this.Damage = Damage;
    }

    public Stat SetEnemyStat(EnemyType type)
    {
        Stat stat = null;

        switch(type)
        {
            case EnemyType.Elite:
                stat = new Stat(type, "Elite", 3, 5);
                break;
            case EnemyType.Midium:
                stat = new Stat(type, "Midium", 2, 3);
                break;
            case EnemyType.Small:
                stat = new Stat(type, "Small", 1, 1);
                break;
        }
        return stat;
    }

}
