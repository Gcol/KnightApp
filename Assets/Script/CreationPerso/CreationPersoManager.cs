using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class TaroDeck : MonoBehaviour 
{
    public List<Tarot> avJ = new List<Tarot>();
    public Tarot DavJ;
    public Tarot avIa;
    public Tarot DavIa;
}

[Serializable]
public class caracPerso
{
    public int sectionValue;
    public int archetypeValue;
    public int baseValue;
    public int odValue;
    public int bonusAPlacer;
    public int HautFait;

    public caracPerso(int value, int odValue)
    {
        this.bonusAPlacer = 0;
        this.archetypeValue = 0;
        this.HautFait = 0;
        this.sectionValue = 0;
        this.baseValue = value;
        this.odValue = odValue;
    }

    public int value()
    {
        return baseValue + sectionValue + archetypeValue + HautFait;
    }
}

public class CreationPersoManager : MonoBehaviour
{
    public TaroDeck taroDeck = new TaroDeck();
    public Archetype archetype;
    public HautFait HautFait;
    public Blason Blason;
    public SectionKnight section;
    public Armure Armure;
    public GameObject ChoixCaracPopup;

    public Image metaArmure;

    public List<caractéristique> ArchetypeValueUpdated;
    public List<caractéristique> HautFaitValueUpdated;
    //TODO pourquoi pas le convertir avec un dict string sur le type en clé

    [SerializeField]
    public Dictionary<caractéristique, caracPerso> caracPlayer = new Dictionary<caractéristique, caracPerso>()
    {
        {caractéristique.Chair,  new caracPerso(2,0)},
        {caractéristique.Dame,  new caracPerso(2,0)},
        {caractéristique.Machine,  new caracPerso(2,0)},
        {caractéristique.Masque,  new caracPerso(2,0)},
        {caractéristique.Bête,  new caracPerso(2,0)},
        {caractéristique.Déplacement,  new caracPerso(1,0)},
        {caractéristique.Force,  new caracPerso(1,0)},
        {caractéristique.Endurance,  new caracPerso(1,0)},
        {caractéristique.Hargne,  new caracPerso(1,0)},
        {caractéristique.Combat,  new caracPerso(1,0)},
        {caractéristique.Instinct,  new caracPerso(1,0)},
        {caractéristique.Tir,  new caracPerso(1,0)},
        {caractéristique.Savoir,  new caracPerso(1,0)},
        {caractéristique.Technique,  new caracPerso(1,0)},
        {caractéristique.Aura,  new caracPerso(1,0)},
        {caractéristique.Parole,  new caracPerso(1,0)},
        {caractéristique.Sang_Froid,  new caracPerso(1,0)},
        {caractéristique.Discrétion,  new caracPerso(1,0)},
        {caractéristique.Dextérité,  new caracPerso(1,0)},
        {caractéristique.Perception,  new caracPerso(1,0)},
    };


    // Start is called before the first frame update
    void Start()
    {
        taroDeck = new TaroDeck();
    }

    public void UpdatePerso(CreaPerso obj)
    {

        Debug.Log("Je recois un obj" + obj);
    }

    public void UpdatePerso(Archetype archetype)
    {
        if (this.archetype != null)
        {
            foreach(caractéristique CP in ArchetypeValueUpdated)
                SupCarac(CP, "Archetype", 0);;
        }
        ArchetypeValueUpdated.Clear();
        ApplyArchetypeBonus(archetype);
        this.archetype = archetype;

        UPdateRecapInfo(archetype);
    }
    public void UpdatePerso(SectionKnight sectionKnight)
    {
        section = sectionKnight; 
        UPdateRecapInfo(section);
    }
    public void UpdatePerso(HautFait hautFait)
    {
        if (this.HautFait != null)
        {
            foreach (caractéristique CP in HautFaitValueUpdated)
                SupCarac(CP, "HautFait", 0); ;
        }
        HautFaitValueUpdated.Clear();
        ApplyHautFaitBonus(hautFait);
        this.HautFait = hautFait;
        UPdateRecapInfo(hautFait);
    }
    public void ApplyHautFaitBonus(HautFait hautFait)
    {
        //Todo standadisé cette fonction avec un if type pour donnée le string, peux être créer une autre classe parente avec le bonus Carac
        foreach (ChoixCarac choixCarac in hautFait.bonusCarac)
        {
            if (choixCarac.choixCarac.Count > 1)
            {
                ChoixCaracPopup.SetActive(true);
                ChoixCaracPopup.transform.Find("Image").Find("Button (1)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[0], "HautFait");
                ChoixCaracPopup.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[1], "HautFait");
            }
            else
                AddCarac(choixCarac.choixCarac[0], "HautFait");
        }
    }


    public void UpdatePerso(Blason blason)
    {
        UPdateRecapInfo(blason);
    }

    public void ApplyArchetypeBonus(Archetype archetype)
    {
        foreach (ChoixCarac choixCarac in archetype.bonusCarac)
        {
            if(choixCarac.choixCarac.Count > 1)
            {
                ChoixCaracPopup.SetActive(true);
                ChoixCaracPopup.transform.Find("Image").Find("Button (1)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[0], "Archetype");
                ChoixCaracPopup.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[1], "Archetype");
            }
            else
                AddCarac(choixCarac.choixCarac[0], "Archetype");
        }
    }

    public void AddCarac(caractéristique caracName, string from, int value=1, int od = 0)
    {
        if (from == "Archetype")
        {
            ArchetypeValueUpdated.Add(caracName);
            caracPlayer[caracName].archetypeValue = value;
            UpdateCharacPannel(caracName);
        }
        else if (from == "HautFait")
        {
            HautFaitValueUpdated.Add(caracName);
            caracPlayer[caracName].HautFait = value;
            UpdateCharacPannel(caracName);
        }
        else
        {
            Debug.LogError(from + " dans AddCaracButton non reconnue");
        }
    }

    public void SupCarac(caractéristique caracName, string from, int value = 1, int od = 0)
    {
        if (from == "Archetype")
            caracPlayer[caracName].archetypeValue = value;
        if (from == "HautFait")
            caracPlayer[caracName].HautFait = value;
        UpdateCharacPannel(caracName);
    }
    public void UpdateCharacPannel(caractéristique caracName)
    {
        List<caractéristique> chairCarac = new List<caractéristique>() { caractéristique.Chair, caractéristique.Déplacement, caractéristique.Force, caractéristique.Endurance };
        if (chairCarac.Contains(caracName))
            UpdateCharacPannelText("Chair", caracName);
        List<caractéristique> BeteCarac = new List<caractéristique>() { caractéristique.Bête, caractéristique.Hargne, caractéristique.Combat, caractéristique.Instinct };
        if (BeteCarac.Contains(caracName))
            UpdateCharacPannelText("Bête", caracName);
        List<caractéristique> MachineCarac = new List<caractéristique>() { caractéristique.Machine, caractéristique.Tir, caractéristique.Savoir, caractéristique.Technique };
        if (MachineCarac.Contains(caracName))
            UpdateCharacPannelText("Machine", caracName);
        List<caractéristique> DameCarac = new List<caractéristique>() { caractéristique.Aura, caractéristique.Parole, caractéristique.Dame, caractéristique.Sang_Froid };
        if (DameCarac.Contains(caracName))
            UpdateCharacPannelText("Dame", caracName);
        List<caractéristique> MasqueCarac = new List<caractéristique>() { caractéristique.Masque, caractéristique.Discrétion, caractéristique.Dextérité, caractéristique.Perception };
        if (MasqueCarac.Contains(caracName))
            UpdateCharacPannelText("Masque", caracName);

    }

    public void UpdateCharacPannelText(string categoryName, caractéristique caracName)
    {
        transform.Find("CharacPannel").Find(categoryName).Find(caracName.ToString()).Find("Value").GetComponent<TextMeshProUGUI>().text = caracPlayer[caracName].value().ToString();
        if (caracPlayer[caracName].odValue > 0)
            transform.Find("CharacPannel").Find(categoryName).Find(caracName.ToString()).Find("OverDrive").Find("Nv" + caracPlayer[caracName].odValue).Find("Check").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "X";
    }
    public void UPdateRecapInfo(CreaPerso obj)
    {
        transform.Find("RecapInfo").Find(obj.GetType().ToString()).GetComponent<TextMeshProUGUI>().text = obj.GetType() + " :\n" + obj.name;
    }

    public void UpdatePerso(Armure armure)
    {

        Transform stat = transform.Find("Stat").Find("Stat");
        Transform module = transform.Find("Stat").Find("MetaArmure");


        UpdateStat(stat, "PA", armure.PointArmure.ToString());
        UpdateStat(stat, "PE", armure.PointEnergie.ToString());
        UpdateStat(stat, "CdF", armure.ChampDeForce.ToString());
        UpdateStat(stat, "Gen", armure.generationMetaArmure.ToString());

        module.GetComponent<Image>().sprite = armure.currentSprite;
        foreach (moduleSlot currMs in armure.slot)
            module.Find(currMs.nameSlot).GetComponent<TextMeshProUGUI>().text = currMs.number.ToString();
    }


    public void UpdateStat(Transform stat, string statName, string valueStat)
    {
        stat.Find(statName).Find("Value").Find("Value").GetComponent<TextMeshProUGUI>().text = valueStat;
    }
}
