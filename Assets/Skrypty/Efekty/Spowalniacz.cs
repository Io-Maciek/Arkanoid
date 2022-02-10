using Assets.Skrypty.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spowalniacz: EffectModel
{
    public override void Effect(GameObject gracz)
    {
        gracz.GetComponent<GraczMovement>().speed *= 0.75f;
        gracz.GetComponent<GraczMovement>().Invoke("resetBoostN", CzasTrwaniaEfektu);
    }
}
