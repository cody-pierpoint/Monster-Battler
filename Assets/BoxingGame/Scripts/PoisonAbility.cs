using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAbility : PlayerAbility
{
    public float damageDuration;
    public float damageCooldown;
    public float damageTimer;

    private void Start()
    {
        //damageCooldown = Time.time;
        //damageDuration = Time.time;
        //damageTimer = 0.5f;
    }
    public override void UseAbility()
    {
        if (_turnTimer.IsNextTurn())
        {
            if (damageDuration <= 10 && damageCooldown >= 2)
            {

                int damage = Random.Range(3, 7);
                _enemy.DealDamage(damage);
                damageCooldown = 0;

                //StartCoroutine(PoisonAbilityTimer());
            }
            //damageDuration += damageTimer * Time.deltaTime;
            //damageCooldown += damageTimer * Time.deltaTime;
            EndTurn();
        }
        //damageDuration = 10;
        //damageCooldown = 2;
        

        //if (damageCooldown <= 0 && damageDuration <= 0)
        //{
        //    int damage = Random.Range(3, 7);
        //    _enemy.DealDamage(damage);
        //    damageCooldown = 2;
        //}

    }
    private void Update()
    {
        damageDuration += damageTimer * Time.deltaTime;
        damageCooldown += damageTimer * Time.deltaTime;
        Debug.Log(damageDuration + damageCooldown);
        //if (damageCooldown <= 2 && damageDuration <= 0)
        //{

        //}
    }
    public IEnumerator PoisonAbilityTimer()
    {
        
        UseAbility();
        yield return new WaitForSeconds(damageCooldown);

    }
}
