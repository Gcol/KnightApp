using UnityEngine;
using System.Collections.Generic;
using System.Collections;

using System;
using UnityEditor;
using System.Linq;
using Unity.VisualScripting;
using System.IO;



[Serializable]
public class Chevalier : ScriptableObject
{
    public string fullname;
    public bool isArmure;
    public string alias;
    // valuer calculer 

    public Armure armure;
    public SectionKnight section;

    public int currentVie;
    public int currentEspoir;
    public int currentEnergie;
    public int currentArmor;

    [HideInInspector]
    public int currentCDF;

    public HautFait hautFait;
    public Archetype archetype;
    public Blason blason;


    public Dictionary<string, int> currentStat;

    public String[] motivation = new string[3] {"","",""};

    public List<Arme> allWeapon;
    public List<string> tarots = new List<string>();

    public Dictionary<caract�ristique, CharacValue> allStat = new Dictionary<caract�ristique, CharacValue>() {
        {caract�ristique.Chair, new CharacValue(0,0)},
        {caract�ristique.D�placement, new CharacValue(0,0)},
        {caract�ristique.Force, new CharacValue(0,0)},
        {caract�ristique.Endurance, new CharacValue(0,0)},
        {caract�ristique.B�te, new CharacValue(0,0)},
        {caract�ristique.Hargne, new CharacValue(0,0)},
        {caract�ristique.Combat, new CharacValue(0,0)},
        {caract�ristique.Instinct, new CharacValue(0,0)},
        {caract�ristique.Machine, new CharacValue(0,0)},
        {caract�ristique.Tir, new CharacValue(0,0)},
        {caract�ristique.Savoir, new CharacValue(0,0)},
        {caract�ristique.Technique, new CharacValue(0,0)},
        {caract�ristique.Dame, new CharacValue(0,0)},
        {caract�ristique.Aura, new CharacValue(0,0)},
        {caract�ristique.Parole, new CharacValue(0,0)},
        {caract�ristique.Sang_Froid, new CharacValue(0,0)},
        {caract�ristique.Masque, new CharacValue(0,0)},
        {caract�ristique.Discr�tion, new CharacValue(0,0)},
        {caract�ristique.Dext�rit�, new CharacValue(0,0)},
        {caract�ristique.Perception, new CharacValue(0,0)}
    };


   


    [HideInInspector]
    public string description;

    public void Init()
    {
    }

    public void UpdateCarac(Dictionary<caract�ristique, caracPerso> caracPlayer)
    {
        foreach(KeyValuePair<caract�ristique, caracPerso> keyValuePair in caracPlayer)
            allStat[keyValuePair.Key] = new CharacValue(keyValuePair.Value.value(), keyValuePair.Value.odValue);
    }
    
    public Chevalier()
    {
    }

    public Chevalier(Player newPlayer)
    {
        currentStat = new Dictionary<string, int>();

        allWeapon = new List<Arme>();
        foreach(StatSave statsave in newPlayer.stat)
            currentStat[statsave.name] = statsave.currentValue;


        SectionKnight[] section = Resources.LoadAll<SectionKnight>("CreationPerso/Section");
        Armure[] allArmure = Resources.LoadAll<Armure>("CreationPerso/Armure");
        Arme[] allArme = Resources.LoadAll<Arme>("Arme");
        Module[] allModule = Resources.LoadAll<Module>("Module");

        foreach (SectionKnight currentSection in section)
        {
            if (currentSection.name == newPlayer.section)
            {
                this.section = currentSection;
                break;
            }
        }
        if (this.section == null)
            Debug.LogError("On as pas trouv� la section " + newPlayer.section);

        foreach (Armure currentArmure in allArmure)
        {
            if (currentArmure.name == newPlayer.armure)
            {
                this.armure = currentArmure;
                break;
            }
        }

        if (armure == null)
            Debug.LogError("On as pas trouv� l'armure " + newPlayer.armure);

        List<String> armes = new List<String>(newPlayer.allWeapon);
        List<String> modules = new List<String>(newPlayer.allModule);

        foreach (Arme currentArme in allArme)
        {
            while(armes.Contains(currentArme.name))
            {
                allWeapon.Add(currentArme);
                armes.Remove(currentArme.name);
            }
        }
        foreach (String name in armes)
            Debug.LogError("On as pas trouv� l'arme " + name);



        foreach (Module currentModule in allModule)
        {
            while (modules.Contains(currentModule.name))
            {
                this.armure.modules.Add(currentModule);
                modules.Remove(currentModule.name);
            }
        }

        foreach (String name in modules)
            Debug.LogError("On as pas trouv� le module " + name);

        foreach (CaracSave caracSave in newPlayer.allCarac)
            allStat[(caract�ristique)Enum.Parse(typeof(caract�ristique), caracSave.name)] = new CharacValue(caracSave.value, caracSave.od);

    }
    int maxOfCarac(caract�ristique carac1, caract�ristique carac2, caract�ristique carac3, bool odInclus = false)
    {
        int max = Math.Max(allStat[carac1].value + (odInclus ? allStat[carac1].overdrive : 0), allStat[carac2].value + (odInclus ? allStat[carac2].overdrive : 0));
        return Math.Max(max, allStat[carac3].value + (odInclus ? allStat[carac3].overdrive : 0));
    }

    public int PointDeVie()
    {
        return 10 + 6 * maxOfCarac(caract�ristique.D�placement, caract�ristique.Force, caract�ristique.Endurance);
    }
    public int D�fense()
    {
        return maxOfCarac(caract�ristique.Hargne, caract�ristique.Combat, caract�ristique.Instinct, true);
    }
    public int Reaction()
    {
        return maxOfCarac(caract�ristique.Tir, caract�ristique.Savoir, caract�ristique.Technique, true);
    }
    public int Iniative()
    {
        return maxOfCarac(caract�ristique.Discr�tion, caract�ristique.Dext�rit�, caract�ristique.Perception, true);
    }
    public int Contact()
    {
        return maxOfCarac(caract�ristique.Aura, caract�ristique.Parole, caract�ristique.Sang_Froid, true);
    }
    public int Espoir()
    {
        return 50 + (tarots.Contains("Forteresse spirituelle") ? 5 : 0);
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
