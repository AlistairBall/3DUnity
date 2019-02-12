using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies
{
    // Var
    public float ammo;
    public float bandages;
    public float weight;

    public Supplies(int size)
    {
        bandages = size;
        ammo = size * 5;
        weight = bandages * 0.2f + ammo * 0.8f;
    }

    public static Supplies operator +(Supplies lhs, Supplies rhs)
    {
        Supplies s = new Supplies(0);
        s.bandages = lhs.bandages + rhs.bandages;
        s.ammo = lhs.ammo + rhs.ammo;
        s.weight = lhs.ammo + rhs.ammo;
        return s;
    }

    public static bool operator <(Supplies lhs, Supplies rhs)
    {
        return lhs.weight < rhs.weight;
    }

    public static bool operator >(Supplies lhs, Supplies rhs)
    {
        return lhs.weight > rhs.weight;
    }

}

