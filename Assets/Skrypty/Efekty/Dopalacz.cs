using Assets.Skrypty.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dopalacz : EffectModel
{
    public override void Effect(GameObject gracz)
    {
        gracz.GetComponent<GraczMovement>().speed *= 2;
        gracz.GetComponent<GraczMovement>().Invoke("resetBoost", CzasTrwaniaEfektu);
    }
}
