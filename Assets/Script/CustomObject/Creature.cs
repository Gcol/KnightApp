using System;
using System.Collections.Generic;
using UnityEngine;

public enum TypeEnemy
{
    Bande,
    Hostile,
    Salopard,
    Colosse,
    Patron,
    Allié
}
public enum Dangerosite
{
    Incarnation,
    Elite,
    Aucun
}

public enum enemiNiveau
{
    recrue,
    initié,
    héros
}

[Serializable]
public class StatE
{
    public int def;
    public int reac;
    public int initative;
    public int ps;
    public int bouclier;
    public int debordement;
    public int cohésion;
    public int pointArmure;
}

[Serializable]
public class CreatureArme
{
    public string name;
    public string degat;
    public PorteArme porte;
    public EffectLvl[] effets;
}

public enum Aspect
{
    Chair,
    Bête,
    Machine,
    Dame,
    Masque
}

[Serializable]
public class AspectMonstre
{
    public Aspect aspect;
    public int valeurAspect;
    public string aspestExceptionel;

    public AspectMonstre(Aspect newAspect)
    {
        aspect = newAspect;
    }
}

[CreateAssetMenu(fileName = "Nouveau Monstre", menuName = "Knight / Creature")]
public class Creature : ScriptableObject
{
    public enemiNiveau enemiNiveau;
    public TypeEnemy typeEnemy;
    public Dangerosite dangerosite;

    public Sprite currentImage;

    public StatE stat;
    public AspectMonstre[] aspect = new AspectMonstre[5] {
        new AspectMonstre(Aspect.Chair),
        new AspectMonstre(Aspect.Bête),
        new AspectMonstre(Aspect.Machine),
        new AspectMonstre(Aspect.Dame),
        new AspectMonstre(Aspect.Masque)
    };

    [Multiline]
    public string pointFaible;
    [TextArea(10, 100)]
    public string description;
    [TextArea(3, 100)]
    public string Tactique;
    [TextArea(10, 100)]
    public string Capacite;
    public CreatureArme[] arme;


}
