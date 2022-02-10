using Assets.Skrypty.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NowaPilka : EffectModel
{
    public override void Effect(GameObject gracz)
    {
        Spawner s = gracz.transform.parent.GetComponent<Spawner>();
        s.a.SetBool("Added", true);
        s.Zycia++;
    }
}
