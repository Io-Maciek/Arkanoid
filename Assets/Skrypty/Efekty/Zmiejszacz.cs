using Assets.Skrypty.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zmiejszacz : EffectModel
{
    public override void Effect(GameObject gracz)
    {
        gracz.GetComponent<GraczMovement>().graczSize *= 0.75f;
        gracz.GetComponent<GraczMovement>().Invoke("resetSizeN", CzasTrwaniaEfektu);
    }

}
