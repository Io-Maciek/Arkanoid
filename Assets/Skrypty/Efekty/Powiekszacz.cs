using Assets.Skrypty.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powiekszacz : EffectModel
{
    public override void Effect(GameObject gracz)
    {
        gracz.GetComponent<GraczMovement>().graczSize *= 1.5f;
        gracz.GetComponent<GraczMovement>().Invoke("resetSize", CzasTrwaniaEfektu);
    }

}
