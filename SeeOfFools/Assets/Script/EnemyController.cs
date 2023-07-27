using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{ 
    public enum Type { Elite, Midium, Small }
    public Type enemyType;

    public int maxHealth;
    public int curHealth;

    public bool isDead = false;

    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(Behavior());
    }

    void Update()
    {
        if(curHealth <= 0 || isDead == true)
        {
            StopCoroutine(Behavior());
        }
    }

    IEnumerator Behavior()
    {
        StartCoroutine(Attack());

        yield return new WaitForSeconds(17f);

        isDead = true;
    }

    IEnumerator Attack()
    {

        yield return new WaitForSeconds(8f);
    }
}
