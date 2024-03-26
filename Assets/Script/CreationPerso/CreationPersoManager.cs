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

    public List<caract�ristique> ArchetypeValueUpdated;
    public List<caract�ristique> HautFaitValueUpdated;
    //TODO pourquoi pas le convertir avec un dict string sur le type en cl�

    [SerializeField]
    public Dictionary<caract�ristique, caracPerso> caracPlayer = new Dictionary<caract�ristique, caracPerso>()
    {
        {caract�ristique.Chair,  new caracPerso(2,0)},
        {caract�ristique.Dame,  new caracPerso(2,0)},
        {caract�ristique.Machine,  new caracPerso(2,0)},
        {caract�ristique.Masque,  new caracPerso(2,0)},
        {caract�ristique.B�te,  new caracPerso(2,0)},
        {caract�ristique.D�placement,  new caracPerso(1,0)},
        {caract�ristique.Force,  new caracPerso(1,0)},
        {caract�ristique.Endurance,  new caracPerso(1,0)},
        {caract�ristique.Hargne,  new caracPerso(1,0)},
        {caract�ristique.Combat,  new caracPerso(1,0)},
        {caract�ristique.Instinct,  new caracPerso(1,0)},
        {caract�ristique.Tir,  new caracPerso(1,0)},
        {caract�ristique.Savoir,  new caracPerso(1,0)},
        {caract�ristique.Technique,  new caracPerso(1,0)},
        {caract�ristique.Aura,  new caracPerso(1,0)},
        {caract�ristique.Parole,  new caracPerso(1,0)},
        {caract�ristique.Sang_Froid,  new caracPerso(1,0)},
        {caract�ristique.Discr�tion,  new caracPerso(1,0)},
        {caract�ristique.Dext�rit�,  new caracPerso(1,0)},
        {caract�ristique.Perception,  new caracPerso(1,0)},
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
            foreach(caract�ristique CP in ArchetypeValueUpdated)
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
            foreach (caract�ristique CP in HautFaitValueUpdated)
                SupCarac(CP, "HautFait", 0); ;
        }
        HautFaitValueUpdated.Clear();
        ApplyHautFaitBonus(hautFait);
        this.HautFait = hautFait;
        UPdateRecapInfo(hautFait);
    }
    public void ApplyHautFaitBonus(HautFait hautFait)
    {
        //Todo standadis� cette fonction avec un if type pour donn�e le string, peux �tre cr�er une autre classe parente avec le bonus Carac
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

    public void AddCarac(caract�ristique caracName, string from, int value=1, int od = 0)
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

    public void SupCarac(caract�ristique caracName, string from, int value = 1, int od = 0)
    {
        if (from == "Archetype")
            caracPlayer[caracName].archetypeValue = value;
        if (from == "HautFait")
            caracPlayer[caracName].HautFait = value;
        UpdateCharacPannel(caracName);
    }
    public void UpdateCharacPannel(caract�ristique caracName)
    {
        List<caract�ristique> chairCarac = new List<caract�ristique>() { caract�ristique.Chair, caract�ristique.D�placement, caract�ristique.Force, caract�ristique.Endurance };
        if (chairCarac.Contains(caracName))
            UpdateCharacPannelText("Chair", caracName);
        List<caract�ristique> BeteCarac = new List<caract�ristique>() { caract�ristique.B�te, caract�ristique.Hargne, caract�ristique.Combat, caract�ristique.Instinct };
        if (BeteCarac.Contains(caracName))
            UpdateCharacPannelText("B�te", caracName);
        List<caract�ristique> MachineCarac = new List<caract�ristique>() { caract�ristique.Machine, caract�ristique.Tir, caract�ristique.Savoir, caract�ristique.Technique };
        if (MachineCarac.Contains(caracName))
            UpdateCharacPannelText("Machine", caracName);
        List<caract�ristique> DameCarac = new List<caract�ristique>() { caract�ristique.Aura, caract�ristique.Parole, caract�ristique.Dame, caract�ristique.Sang_Froid };
        if (DameCarac.Contains(caracName))
            UpdateCharacPannelText("Dame", caracName);
        List<caract�ristique> MasqueCarac = new List<caract�ristique>() { caract�ristique.Masque, caract�ristique.Discr�tion, caract�ristique.Dext�rit�, caract�ristique.Perception };
        if (MasqueCarac.Contains(caracName))
            UpdateCharacPannelText("Masque", caracName);

    }

    public void UpdateCharacPannelText(string categoryName, caract�ristique caracName)
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
