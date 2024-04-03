using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.UI;

using System.Reflection;
using static UnityEngine.GraphicsBuffer;
using System.Linq;
public struct ArmureModuleSlot
{
    public int size;
    public int maxSize;
    public List<Module> modules;
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
    public int Tarot;
    public caract�ristique aspect;

    public caracPerso(int value, caract�ristique aspect)
    {
        this.aspect = aspect;
        this.bonusAPlacer = 0;
        this.archetypeValue = 0;
        this.HautFait = 0;
        this.sectionValue = 0;
        this.baseValue = value;
        this.odValue = 0;
        this.Tarot = 0;
    }

    public int value()
    {
        return baseValue + sectionValue + archetypeValue + HautFait + Tarot;
    }
}

public class CreationPersoManager : MonoBehaviour
{
    public Chevalier newChevalier;
    public TMP_InputField inputMotivMineur1;
    public TMP_InputField inputMotivMineur2;
    public TMP_InputField inputMotivMajeur;

    private SaveManager SM;

    Dictionary<caract�ristique, List<caract�ristique>> caracDict = new Dictionary<caract�ristique, List<caract�ristique>>()
    {
        { caract�ristique.Chair, new List<caract�ristique>() { caract�ristique.Chair, caract�ristique.D�placement, caract�ristique.Force, caract�ristique.Endurance }},
        { caract�ristique.B�te, new List<caract�ristique>() { caract�ristique.B�te, caract�ristique.Hargne, caract�ristique.Combat, caract�ristique.Instinct }},
        { caract�ristique.Machine, new List<caract�ristique>() { caract�ristique.Machine, caract�ristique.Tir, caract�ristique.Savoir, caract�ristique.Technique }},
        { caract�ristique.Dame, new List<caract�ristique>() { caract�ristique.Aura, caract�ristique.Parole, caract�ristique.Dame, caract�ristique.Sang_Froid }},
        { caract�ristique.Masque, new List<caract�ristique>() { caract�ristique.Masque, caract�ristique.Discr�tion, caract�ristique.Dext�rit�, caract�ristique.Perception }}
    };

    public Dictionary<string, Tarot> taroDeck = new()
    {
        { "Avantage Ia", null },
        { "Avantage Joueur", null },
        { "Avantage Joueur 2", null },
        { "Desavantage Joueur", null },
        { "Desavantage IA", null }

    };

    public GameObject ChoixCaracPopup;
    public GameObject ChoixCaracPopupFree;
    public GameObject ChoixCaracPopupFou;
    public GameObject ChoixCaracPopupMaisonDieu;

    public List<Module> modulesHorsSlot; // A paser dans l'armure ?
    public Dictionary<SlotModule, ArmureModuleSlot> armureSlotModule = new ()
    {
        { SlotModule.BradD, new ArmureModuleSlot()},
        { SlotModule.T�te, new ArmureModuleSlot()},
        { SlotModule.BrasG, new ArmureModuleSlot()},
        { SlotModule.Torse, new ArmureModuleSlot()},
        { SlotModule.JambeD, new ArmureModuleSlot()},
        { SlotModule.JambeL, new ArmureModuleSlot()},
    };

    public Image metaArmure;

    List<caract�ristique> ArchetypeValueUpdated = new List<caract�ristique>();
    List<caract�ristique> HautFaitValueUpdated = new List<caract�ristique>();

    List<Module> listModuleToChoice = new List<Module>();

    public Dictionary<string, List<caract�ristique>> TarotDeckValue = new Dictionary<string, List<caract�ristique>>();

    public int CaracToAddPopup;
    public caract�ristique caracPopup;
    //TODO pourquoi pas le convertir avec un dict string sur le type en cl�

    public ArmementShower armementShower;
    public ArmementShower moduleShower;

    [SerializeField]
    public Dictionary<caract�ristique, caracPerso> caracPlayer = new Dictionary<caract�ristique, caracPerso>()
    {
        {caract�ristique.Chair,  new caracPerso(2, caract�ristique.Chair)},
        {caract�ristique.Dame,  new caracPerso(2, caract�ristique.Dame)},
        {caract�ristique.Machine,  new caracPerso(2, caract�ristique.Machine)},
        {caract�ristique.Masque,  new caracPerso(2,caract�ristique.Masque)},
        {caract�ristique.B�te,  new caracPerso(2, caract�ristique.B�te)},
        {caract�ristique.D�placement,  new caracPerso(1, caract�ristique.Chair)},
        {caract�ristique.Force,  new caracPerso(1, caract�ristique.Chair)},
        {caract�ristique.Endurance,  new caracPerso(1, caract�ristique.Chair)},
        {caract�ristique.Hargne,  new caracPerso(1, caract�ristique.B�te)},
        {caract�ristique.Combat,  new caracPerso(1, caract�ristique.B�te)},
        {caract�ristique.Instinct,  new caracPerso(1, caract�ristique.B�te)},
        {caract�ristique.Tir,  new caracPerso(1, caract�ristique.Machine)},
        {caract�ristique.Savoir,  new caracPerso(1, caract�ristique.Machine)},
        {caract�ristique.Technique,  new caracPerso(1, caract�ristique.Machine)},
        {caract�ristique.Aura,  new caracPerso(1, caract�ristique.Dame)},
        {caract�ristique.Parole,  new caracPerso(1, caract�ristique.Dame)},
        {caract�ristique.Sang_Froid,  new caracPerso(1, caract�ristique.Dame)},
        {caract�ristique.Discr�tion,  new caracPerso(1, caract�ristique.Masque)},
        {caract�ristique.Dext�rit�,  new caracPerso(1, caract�ristique.Masque)},
        {caract�ristique.Perception,  new caracPerso(1, caract�ristique.Masque)},
    };


    public void UpdateMotivation(string type)
    {
        if (type == "MotivationMineur1")
            newChevalier.motivation[0] = inputMotivMineur1.text;
        if (type == "MotivationMineur2")
            newChevalier.motivation[1] = inputMotivMineur2.text;
        if (type == "MotivationMajeur")
            newChevalier.motivation[2] = inputMotivMajeur.text;

    }

    // Start is called before the first frame update
    void Start()
    {
        SM = FindAnyObjectByType<SaveManager>();
        newChevalier = new Chevalier();
        newChevalier.allWeapon = new List<Arme>();
        armementShower = transform.Find("Inventaire").Find("Armement").GetComponent<ArmementShower>();
        moduleShower = transform.Find("Inventaire").Find("Module").GetComponent<ArmementShower>();
    }

    public void UpdatePerso(CreaPerso obj)
    {

        Debug.Log("Je recois un obj" + obj);
    }
    public void UpdatePerso(Arme obj)
    {
        newChevalier.allWeapon.Add(obj);
        //TODO ajouter les armes par default
        armementShower.AddItem(obj);
    }

    public void Sell(Arme obj)
    {
        newChevalier.allWeapon.Remove(obj);
        armementShower.RemoveItem(obj);
    }


    public void UpdatePerso(Overdrive obj)
    {
        caracPlayer[obj.caract�ristique].odValue++;
        UpdateCharacPannel(obj.caract�ristique);
    }
    public void UpdatePerso(Module obj)
    {
        newChevalier.armure.modules.Add(obj);
        foreach (SlotModuleSize slotModuleSize in obj.slot)
        {
            if (slotModuleSize.slotModule.ToString().Contains("Choice"))
            {
                PopUpModuleSlotChoice(obj);
                Debug.Log("Ajoute cette feature");

            }
            else
            {
                newChevalier.armure.slot[slotModuleSize.slotModule].modules.Add(obj);
                //this.Armure.slot[slotModuleSize.slotModule].number -= slotModuleSize.size;
            }
        }
        moduleShower.AddItem(obj);
    }

    public void Save()
    {
        newChevalier.UpdateCarac(caracPlayer);
        Player newPlayer = new Player(newChevalier);
        SM.SaveData(newPlayer);
    }

    public void PopUpModuleSlotChoice(Module obj)
    {

    }

    public void Sell(Module obj)
    {
       // armes.Remove(obj);
       moduleShower.RemoveItem(obj);
    }
    public void Sell(Overdrive obj)
    {
        caracPlayer[obj.caract�ristique].odValue--;
        UpdateCharacPannel(obj.caract�ristique);
    }



    public void UpdatePerso(Tarot tarot, string emplacement)
    {
        if (emplacement == "Avantage Joueur" && taroDeck[emplacement] != null)
            emplacement += " 2";
        taroDeck[emplacement] = tarot;
        /*
        if (TarotDeckValue.ContainsKey(emplacement))
        {
            Debug.Log("Supprime ancienne valeur");
            foreach (caract�ristique CP in TarotDeckValue[emplacement])
                SupCarac(CP, "Tarot" + tarot.name, -1);
            TarotDeckValue[emplacement].Clear();
        }*/
        string from = "Tarot:" + tarot.name + "=" + emplacement;
        UpdateTarotInfo(tarot, emplacement);
        FindAnyObjectByType<TarotManager>().UpdateObjectif(emplacement);

        if (tarot.name == "0 - Le Fou")
        {
            CaracToAddPopup = 6;
            CallTarotPopup(from);

        }
        else if (tarot.name == "16 - La Maison-Dieu")
        {

            CaracToAddPopup = 2;
            CallTarotPopup(from);
        }
        else
        {
            CaracToAddPopup = 3;
            caracPopup = tarot.caract;
            AddCarac(caracPopup, from);
        }

    }
    void CallTarotPopup(string nameCard)
    {
        if (nameCard.Contains("Fou"))
            UpdateTarotFou();
        else if (nameCard.Contains("Maison-Dieu"))
            UpdateTaroMaisonDieu();
        else
            ApplyHautFaitBonusCarac(nameCard);
    }


    void UpdateTarotInfo(Tarot tarot, string emplacement)
    {
        Type type = tarot.GetType();
        FieldInfo fieldInfo = type.GetField(emplacement.Replace("2", "").Replace("Joueur", "Pj").Replace("Avantage", "avantage").Replace("Desavantage", "desavantage").Replace(" ", ""));
        Debug.Log("|" + emplacement+ "|");
        string nameEmplace = emplacement.Replace("Desavantage", "Trait N�gatif ").Replace("avantage", "Trait Positif ").Replace("Pj", "");
        string nameTrait = ((string)fieldInfo.GetValue(tarot)).Split(':')[0];
        newChevalier.tarots.Add(nameTrait);
        transform.Find("RecapInfo").Find(emplacement).GetComponent<TextMeshProUGUI>().text = nameEmplace + " : " + nameTrait;
    }

    public void UpdateTaroMaisonDieu()
    {
        if (CaracToAddPopup > 0)
        {
            CaracToAddPopup -= 1;
            ChoixCaracPopupMaisonDieu.SetActive(true);
        }
    }

    public void UpdateTarotFou()
    {
        if (CaracToAddPopup > 0)
        {
            CaracToAddPopup -= 1;
            ChoixCaracPopupFou.SetActive(true);
        }
    }

    public void UpdatePerso(Archetype archetype)
    {
        if (newChevalier.archetype != null)
            foreach(caract�ristique CP in ArchetypeValueUpdated)
                SupCarac(CP, "Archetype", 0);
        ArchetypeValueUpdated.Clear();
        ApplyArchetypeBonus(archetype);
        newChevalier.archetype = archetype;

        UPdateRecapInfo(archetype);
    }
    public void UpdatePerso(SectionKnight section)
    {
        if (newChevalier.section != null)
            UpdateSectionCarac(newChevalier.section.caract, -1);

        newChevalier.section = section;
        UpdateSectionCarac(section.caract, 1);

        foreach (ShopItem shopItem in section.shopItems)
        {
            if (shopItem is Overdrive)
                UpdatePerso((Overdrive)shopItem);
            if (shopItem is Module)
                UpdatePerso((Module)shopItem);
        }

        UPdateRecapInfo(section);
    }

    void UpdateSectionCarac(caract�ristique aspect, int value)
    {
        foreach(caract�ristique caract�ristique in caracDict[aspect])
            AddCarac(caract�ristique, "Section", value);
    }

    public void UpdatePerso(HautFait hautFait)
    {
        if (newChevalier.hautFait != null)
        {
            foreach (caract�ristique CP in HautFaitValueUpdated)
                SupCarac(CP, "HautFait", 0); ;
        }
        newChevalier.hautFait = hautFait;
        HautFaitValueUpdated.Clear();
        ApplyHautFaitBonus(hautFait);
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
                ChoixCaracPopup.transform.Find("Image").Find("Button (1)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[0], "HautFait");
                ChoixCaracPopup.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[1], "HautFait");
                ChoixCaracPopup.SetActive(true);
            }
            else
            {
                AddCarac(choixCarac.choixCarac[0], "HautFait");
            }
        }
    }

    public void ApplyHautFaitBonusCarac(string from= "HautFaitBonus")
    {
        if (CaracToAddPopup > 0)
        {
            CaracToAddPopup -= 1;
            ChoixCaracPopupFree.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(caracDict[caracPopup][3], from);
            ChoixCaracPopupFree.transform.Find("Image").Find("Button (3)").GetComponent<AddCaracButton>().InitCarac(caracDict[caracPopup][2], from);
            ChoixCaracPopupFree.transform.Find("Image").Find("Button (4)").GetComponent<AddCaracButton>().InitCarac(caracDict[caracPopup][1], from);
            ChoixCaracPopupFree.SetActive(true);
        }
    }


    public void UpdatePerso(Blason blason)
    {
        newChevalier.blason = blason;
        UPdateRecapInfo(blason);
    }

    public void ApplyArchetypeBonus(Archetype archetype)
    {
        foreach (ChoixCarac choixCarac in archetype.bonusCarac)
        {
            if(choixCarac.choixCarac.Count > 1)
            {
                ChoixCaracPopup.transform.Find("Image").Find("Button (1)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[0], "Archetype");
                ChoixCaracPopup.transform.Find("Image").Find("Button (2)").GetComponent<AddCaracButton>().InitCarac(choixCarac.choixCarac[1], "Archetype");
                ChoixCaracPopup.SetActive(true);
            }
            else
            {
                AddCarac(choixCarac.choixCarac[0], "Archetype");
            }
        }
    }

    public void AddCarac(caract�ristique caracName, string from, int value=1)
    {
        if (from == "Section")
            caracPlayer[caracName].sectionValue += value;
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
        else if (from.Contains("Taro"))
        {
            string dicKey = from;
            if (from.Contains("="))
                dicKey = from.Split("=")[1];

            if (!TarotDeckValue.ContainsKey(dicKey))
                TarotDeckValue[dicKey] = new List<caract�ristique>();

            Debug.Log(dicKey);
            TarotDeckValue[dicKey].Add(caracName);

            caracPlayer[caracName].Tarot += value;
            CallTarotPopup(from);
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
        if (from.Contains("Tarot"))
            caracPlayer[caracName].sectionValue -= value;
        UpdateCharacPannel(caracName);
    }
    public void UpdateCharacPannel(caract�ristique caracName)
    {
        foreach (KeyValuePair<caract�ristique , List<caract�ristique>> keyValuePair in caracDict) 
            if (keyValuePair.Value.Contains(caracName))
                UpdateCharacPannelText(keyValuePair.Key.ToString(), caracName);
    }

    public void UpdateCharacPannelText(string categoryName, caract�ristique caracName)
    {
        transform.Find("CharacPannel").Find(categoryName).Find(caracName.ToString()).Find("Value").GetComponent<TextMeshProUGUI>().text = caracPlayer[caracName].value().ToString();
        if (transform.Find("CharacPannel").Find(categoryName).Find(caracName.ToString()).Find("OverDrive"))
            transform.Find("CharacPannel").Find(categoryName).Find(caracName.ToString()).Find("OverDrive").GetComponent<OverdriveShower>().UpdateOdd(caracPlayer[caracName].odValue);
    }
    public void UPdateRecapInfo(CreaPerso obj)
    {
        transform.Find("RecapInfo").Find(obj.GetType().ToString()).GetComponent<TextMeshProUGUI>().text = obj.GetType() + " : " + obj.name;
    }

    public void UpdatePerso(Armure armure)
    {
        if (newChevalier.armure)
            foreach (caract�ristique carr in newChevalier.armure.overdrive)
            {
                caracPlayer[carr].odValue--;
                UpdateCharacPannel(carr);
            }
                
        newChevalier.armure = armure;
        Transform stat = transform.Find("MetaArmureInfo").Find("Stat");
        Transform module = transform.Find("MetaArmureInfo").Find("MetaArmure");

        UpdateStat(stat, "PA", armure.PointArmure.ToString());
        UpdateStat(stat, "PE", armure.PointEnergie.ToString());
        UpdateStat(stat, "CdF", armure.ChampDeForce.ToString());
        UpdateStat(stat, "Gen", armure.generationMetaArmure.ToString());

        metaArmure.gameObject.SetActive(true);
        module.GetComponent<Image>().sprite = armure.currentSprite;
        foreach (caract�ristique carr in armure.overdrive)
        {
            caracPlayer[carr].odValue++;
            UpdateCharacPannel(carr);
        }

        //foreach (moduleSlot currMs in armure.slot)
        //    module.Find(currMs.nameSlot).GetComponent<TextMeshProUGUI>().text = currMs.number.ToString();
    }

    public void UpdateStat(Transform stat, string statName, string valueStat)
    {
        stat.Find(statName).Find("Value").Find("Value").GetComponent<TextMeshProUGUI>().text = valueStat;
    }
}
