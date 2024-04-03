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

    public Dictionary<caractéristique, CharacValue> allStat = new Dictionary<caractéristique, CharacValue>() {
        {caractéristique.Chair, new CharacValue(0,0)},
        {caractéristique.Déplacement, new CharacValue(0,0)},
        {caractéristique.Force, new CharacValue(0,0)},
        {caractéristique.Endurance, new CharacValue(0,0)},
        {caractéristique.Bête, new CharacValue(0,0)},
        {caractéristique.Hargne, new CharacValue(0,0)},
        {caractéristique.Combat, new CharacValue(0,0)},
        {caractéristique.Instinct, new CharacValue(0,0)},
        {caractéristique.Machine, new CharacValue(0,0)},
        {caractéristique.Tir, new CharacValue(0,0)},
        {caractéristique.Savoir, new CharacValue(0,0)},
        {caractéristique.Technique, new CharacValue(0,0)},
        {caractéristique.Dame, new CharacValue(0,0)},
        {caractéristique.Aura, new CharacValue(0,0)},
        {caractéristique.Parole, new CharacValue(0,0)},
        {caractéristique.Sang_Froid, new CharacValue(0,0)},
        {caractéristique.Masque, new CharacValue(0,0)},
        {caractéristique.Discrétion, new CharacValue(0,0)},
        {caractéristique.Dextérité, new CharacValue(0,0)},
        {caractéristique.Perception, new CharacValue(0,0)}
    };


   


    [HideInInspector]
    public string description;

    public void Init()
    {
    }

    public void UpdateCarac(Dictionary<caractéristique, caracPerso> caracPlayer)
    {
        foreach(KeyValuePair<caractéristique, caracPerso> keyValuePair in caracPlayer)
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
            Debug.LogError("On as pas trouvé la section " + newPlayer.section);

        foreach (Armure currentArmure in allArmure)
        {
            if (currentArmure.name == newPlayer.armure)
            {
                this.armure = currentArmure;
                break;
            }
        }

        if (armure == null)
            Debug.LogError("On as pas trouvé l'armure " + newPlayer.armure);

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
            Debug.LogError("On as pas trouvé l'arme " + name);



        foreach (Module currentModule in allModule)
        {
            while (modules.Contains(currentModule.name))
            {
                this.armure.modules.Add(currentModule);
                modules.Remove(currentModule.name);
            }
        }

        foreach (String name in modules)
            Debug.LogError("On as pas trouvé le module " + name);

        foreach (CaracSave caracSave in newPlayer.allCarac)
            allStat[(caractéristique)Enum.Parse(typeof(caractéristique), caracSave.name)] = new CharacValue(caracSave.value, caracSave.od);

    }
    int maxOfCarac(caractéristique carac1, caractéristique carac2, caractéristique carac3, bool odInclus = false)
    {
        int max = Math.Max(allStat[carac1].value + (odInclus ? allStat[carac1].overdrive : 0), allStat[carac2].value + (odInclus ? allStat[carac2].overdrive : 0));
        return Math.Max(max, allStat[carac3].value + (odInclus ? allStat[carac3].overdrive : 0));
    }

    public int PointDeVie()
    {
        return 10 + 6 * maxOfCarac(caractéristique.Déplacement, caractéristique.Force, caractéristique.Endurance);
    }
    public int Défense()
    {
        return maxOfCarac(caractéristique.Hargne, caractéristique.Combat, caractéristique.Instinct, true);
    }
    public int Reaction()
    {
        return maxOfCarac(caractéristique.Tir, caractéristique.Savoir, caractéristique.Technique, true);
    }
    public int Iniative()
    {
        return maxOfCarac(caractéristique.Discrétion, caractéristique.Dextérité, caractéristique.Perception, true);
    }
    public int Contact()
    {
        return maxOfCarac(caractéristique.Aura, caractéristique.Parole, caractéristique.Sang_Froid, true);
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
