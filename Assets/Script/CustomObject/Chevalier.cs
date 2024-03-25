using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using System;
using UnityEditor;
using System.Linq;



[Serializable]
[CreateAssetMenu(fileName = "Nouveau Chevalier", menuName = "Knight / Chevalier")]
public class Chevalier : ScriptableObject
{
    public string fullname;
    public string alias;
    // valuer calculer 

    [HideInInspector]
    public int pv = 0;

    [HideInInspector]
    public int pe = 50;

    public Armure armure;
    public SectionKnight section;

    [HideInInspector]
    public int currentVie;
    [HideInInspector]
    public int currentEspoir;
    [HideInInspector]
    public int currentEnergie;
    [HideInInspector]
    public int currentArmor;

    [HideInInspector]
    public int currentCDF;

    public HautFait hautFait;
    public Archetype archetype;
    public Blason blason;


    public List<ModuleBase> allModule;
    [HideInInspector]
    public Motivation[] motiv = new Motivation[]
    {
        new Motivation("", true, false),
        new Motivation("", true, false),
        new Motivation("", false, true),
    };

    [HideInInspector]
    public TarotEffet[] arcanes = new TarotEffet[]
    {
        new TarotEffet(false, false, true),
        new TarotEffet(false, false, true),
        new TarotEffet(true),
        new TarotEffet(false, false, false, true),
        new TarotEffet(false, true)
    };

    public Dictionary<string, CharacValue> allStat = new Dictionary<string, CharacValue>() {
        {"Chair", new CharacValue(0,0)},
        {"Déplacement", new CharacValue(0,0)},
        {"Force", new CharacValue(0,0)},
        {"Endurance", new CharacValue(0,0)},
        {"Bête", new CharacValue(0,0)},
        {"Hargne", new CharacValue(0,0)},
        {"Combat", new CharacValue(0,0)},
        {"Instinct", new CharacValue(0,0)},
        {"Machine", new CharacValue(0,0)},
        {"Tir", new CharacValue(0,0)},
        {"Savoir", new CharacValue(0,0)},
        {"Technique", new CharacValue(0,0)},
        {"Dame", new CharacValue(0,0)},
        {"Aura", new CharacValue(0,0)},
        {"Parole", new CharacValue(0,0)},
        {"Sang-Froid", new CharacValue(0,0)},
        {"Masque", new CharacValue(0,0)},
        {"Discrétion", new CharacValue(0,0)},
        {"Dextérité", new CharacValue(0,0)},
        {"Perception", new CharacValue(0,0)}
    };

    public List<Weapon> allWeapon;

    [HideInInspector]
    public string description;

    public void Init()
    {
        pe = 50;
    }

}

public class Motivation
{
    public string objectif;
    public bool motivationMineur;
    public bool motivationMajeur;

    public Motivation(string nObjective, bool nMotivationMineur, bool nMotivationMajeur)
    {
        objectif = nObjective;
        motivationMineur = nMotivationMineur;
        motivationMajeur = nMotivationMajeur;
    }
}


[Serializable]
public class TarotEffet
{
    public bool IaAvantage;
    public bool IaDesavantage;
    public bool PjAvantage;
    public bool PjDesavantage;
    public Tarot card;

    public TarotEffet(bool iaAv=false, bool iaD=false, bool pjAv=false, bool pjD=false)
    {
        IaAvantage = iaAv;
        IaDesavantage = iaD;
        PjAvantage = pjAv;
        PjDesavantage= pjD;
    }

}


[Serializable]
public class CharacValue
{
    [SerializeField]
    public int value;
    public int overdrive;

    public CharacValue(int nValue, int nOverdrive)
    {
        value = nValue;
        overdrive = nOverdrive;
    }
}
