using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gracz : IComparable
{

    public string nick { get; set; }
    public long punkty { get; set; }



    public Gracz(string nick, long punkty)
    {
        this.punkty = punkty;
        this.nick = nick;
    }

    public Gracz()
    {
        nick = "---";
        punkty = 0;
    }





    public int CompareTo(object obj)
    {
        return punkty.CompareTo(((Gracz)obj).punkty);
    }
}
