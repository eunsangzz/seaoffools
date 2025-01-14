using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stat
{
    public EnemyType type { get; }
    public string name { get; set; }
    public float maxHp { get; set; }
    public float curhp { get; set; }
    public int Damage { get; set; }
    public int Gold { get; set; }
    public int Score { get; set; }

    public Stat()
    {

    }

    public Stat(EnemyType type,string name, int maxHp, int Damage, int Gold, int Score)
    {
        this.type = type;
        this.name = name;
        this.maxHp = maxHp;
        curhp = maxHp;
        this.Damage = Damage;
        this.Gold = Gold;
        this.Score = Score;
    }

    public Stat SetEnemyStat(EnemyType type)
    {
        Stat stat = null;

        switch(type)
        {
            case EnemyType.Elite:
                stat = new Stat(type, "Elite", 24, 10, 50, 300);
                break;
            case EnemyType.Midium:
                stat = new Stat(type, "Midium", 16, 5, 15, 100);
                break;
            case EnemyType.Small:
                stat = new Stat(type, "Small", 8, 5, 10, 50);
                break;
        }
        return stat;
    }

}
