using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
    List<caract�ristique> chairCarac = new List<caract�ristique>() { caract�ristique.Chair, caract�ristique.D�placement, caract�ristique.Force, caract�ristique.Endurance };
    List<caract�ristique> BeteCarac = new List<caract�ristique>() { caract�ristique.B�te, caract�ristique.Hargne, caract�ristique.Combat, caract�ristique.Instinct };
    List<caract�ristique> MachineCarac = new List<caract�ristique>() { caract�ristique.Machine, caract�ristique.Tir, caract�ristique.Savoir, caract�ristique.Technique };
    List<caract�ristique> DameCarac = new List<caract�ristique>() { caract�ristique.Aura, caract�ristique.Parole, caract�ristique.Dame, caract�ristique.Sang_Froid };
    List<caract�ristique> MasqueCarac = new List<caract�ristique>() { caract�ristique.Masque, caract�ristique.Discr�tion, caract�ristique.Dext�rit�, caract�ristique.Perception };

    public TaroDeck taroDeck = new TaroDeck();
    public Archetype archetype;
    public HautFait HautFait;
    public Blason Blason;
    public SectionKnight section;
    public Armure Armure;
    public GameObject ChoixCaracPopup;
    public GameObject ChoixCaracPopupFree;

    public Image metaArmure;

    public List<caract�ristique> SectionValueUpdate = new List<caract�ristique>();
    public List<caract�ristique> ArchetypeValueUpdated = new List<caract�ristique>();
    public List<caract�ristique> HautFaitValueUpdated = new List<caract�ristique>();

    public int CaracToAddPopup;
    public caract�ristique caracPopup;
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
                SupCarac(CP, "Archetype", 0);
        }
        ArchetypeValueUpdated.Clear();
        ApplyArchetypeBonus(archetype);
        this.archetype = archetype;

        UPdateRecapInfo(archetype);
    }
    public void UpdatePerso(SectionKnight sectionKnight)
    {
        if (this.section != null)
        {
            foreach (caract�ristique CP in SectionValueUpdate)
                SupCarac(CP, "Section", 0);
        }
        SectionValueUpdate.Clear();
        section = sectionKnight;
        AddCarac(section.caract, "Section");
        switch(section.caract)
        {
            case caract�ristique.B�te:
                AddCarac(caract�ristique.Hargne, "Section");
                AddCarac(caract�ristique.Combat, "Section");
                AddCarac(caract�ristique.Instinct, "Section");
                break;
            case caract�ristique.Machine:
                AddCarac(caract�ristique.Tir, "Section");
                AddCarac(caract�ristique.Savoir, "Section");
                AddCarac(caract�ristique.Technique, "Section");
                break;
            case caract�ristique.Masque:
                AddCarac(caract�ristique.Discr�tion, "Section");
                AddCarac(caract�ristique.Dext�rit�, "Section");
                AddCarac(caract�ristique.Perception, "Section");
                break;
            case caract�ristique.Dame:
                AddCarac(caract�ristique.Aura, "Section");
                AddCarac(caract�ristique.Parole, "Section");
                AddCarac(caract�ristique.Sang_Froid, "Section");
                break;
            case caract�ristique.Chair:
                AddCarac(caract�ristique.D�placement, "Section");
                AddCarac(caract�ristique.Force, "Section");
                AddCarac(caract�ristique.Endurance, "Section");
                break;
            default:
                break;
        }
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
        CaracToAddPopup = 2;
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
            {
                AddCarac(choixCarac.choixCarac[0], "HautFait");
            }
        }
    }

    public void ApplyHautFaitBonusCarac()
    {
        if (CaracToAddPopup > 0)
        {
            CaracToAddPopup -= 1;
            ChoixCaracPopupFree.SetActive(true);
            switch(caracPopup)
            {
                case caract�ristique.B�te:
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Hargne, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Combat, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Instinct, "HautFaitBonus");
                    break;
                case caract�ristique.Machine:
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Tir, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Savoir, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Technique, "HautFaitBonus");
                    break;
                case caract�ristique.Masque:
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Discr�tion, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Dext�rit�, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Perception, "HautFaitBonus");
                    break;
                case caract�ristique.Dame:
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Aura, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Parole, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Sang_Froid, "HautFaitBonus");
                    break;
                case caract�ristique.Chair:
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.D�placement, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Force, "HautFaitBonus");
                    ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caract�ristique.Endurance, "HautFaitBonus");
                    break;
                default:
                    break;
            }
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
            {
                AddCarac(choixCarac.choixCarac[0], "Archetype");
            }
        }
    }

    public void AddCarac(caract�ristique caracName, string from, int value=1, int od = 0)
    {
        if (from == "Section")
        {
            SectionValueUpdate.Add(caracName);
            caracPlayer[caracName].sectionValue += value;
        }
        else if (from == "Archetype")
        {
            ArchetypeValueUpdated.Add(caracName);
            caracPlayer[caracName].archetypeValue += value;
        }
        else if (from == "HautFait" || from == "HautFaitBonus")
        {
            if (from == "HautFait")
                caracPopup = caracName;
            HautFaitValueUpdated.Add(caracName);
            caracPlayer[caracName].HautFait += value;
            ApplyHautFaitBonusCarac();
        }
        else
        {
            Debug.LogError(from + " dans AddCaracButton non reconnue");
        }
        UpdateCharacPannel(caracName);
    }

    public void SupCarac(caract�ristique caracName, string from, int value = 1, int od = 0)
    {
        if (from == "Archetype")
            caracPlayer[caracName].archetypeValue = value;
        if (from == "HautFait")
            caracPlayer[caracName].HautFait = value;
        if (from == "Section")
            caracPlayer[caracName].sectionValue = value;
        UpdateCharacPannel(caracName);
    }
    public void UpdateCharacPannel(caract�ristique caracName)
    {
        if (chairCarac.Contains(caracName))
            UpdateCharacPannelText("Chair", caracName);
        if (BeteCarac.Contains(caracName))
            UpdateCharacPannelText("B�te", caracName);
        if (MachineCarac.Contains(caracName))
            UpdateCharacPannelText("Machine", caracName);
        if (DameCarac.Contains(caracName))
            UpdateCharacPannelText("Dame", caracName);
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

        metaArmure.gameObject.SetActive(true);
        module.GetComponent<Image>().sprite = armure.currentSprite;
        foreach (moduleSlot currMs in armure.slot)
            module.Find(currMs.nameSlot).GetComponent<TextMeshProUGUI>().text = currMs.number.ToString();
    }

    public void UpdateStat(Transform stat, string statName, string valueStat)
    {
        stat.Find(statName).Find("Value").Find("Value").GetComponent<TextMeshProUGUI>().text = valueStat;
    }
}
