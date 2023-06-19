using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAbility : PlayerAbility
{
    public GameObject RunDialogue;
    public override void UseAbility()
    {
        if (_turnTimer.IsNextTurn())
        {
            StartCoroutine(RunCoroutine());

            EndTurn();
        }
    }
    IEnumerator RunCoroutine()
    {
        RunDialogue.SetActive(true);

        yield return new WaitForSeconds(5);

        RunDialogue.SetActive(false);
    }
}
