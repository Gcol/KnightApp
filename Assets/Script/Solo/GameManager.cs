using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string GameVersion = "1.6";
    public GameObject choicePannel;
    public GameObject jeuxStdPannel;

    public SaveManager currentSM;

    public StatInfo currentSI;
    public CapacitéManager currentCM;
    public FichePerso currentFichePerso;

    [SerializeField]
    public Chevalier currentChevalier;

    public User currentUser;
    public string currentNote;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CheckVersion>().SearchVersion(GameVersion);
        currentCM = FindObjectOfType<CapacitéManager>();
        currentFichePerso = FindObjectOfType<FichePerso>();
        currentSI = FindObjectOfType<StatInfo>();
        currentSM = FindObjectOfType<SaveManager>();
        currentUser = currentSM.LoadUser();
        ModuleManager currentMM = FindObjectOfType<ModuleManager>();
        WeaponManager currentWM = FindObjectOfType<WeaponManager>();

        FindObjectOfType<NoteManager>().LoadNote(currentSM.LoadNote());

        if (currentUser == null )
            ActiveChoicePannel();
        else
        { 
            Chevalier[] allChevalier = Resources.LoadAll<Chevalier>("Chevalier"); 
            foreach(Chevalier currCheval in allChevalier)
            {
                if (currCheval.name == currentUser.name)
                {
                    if (currentUser.currentCDF == 0)
                    {
                        LoadChevalierCurrent(currCheval, currCheval.armure.ChampDeForce, currCheval.pe, currCheval.pv, currCheval.armure.PointEnergie, currCheval.armure.PointArmure);
                        currentSM.SaveData(new User(currCheval));
                    }
                    else
                    {
                        LoadChevalierCurrent(currCheval, currentUser.currentCDF, currentUser.currentPe, currentUser.currentPv, currentUser.currentPen, currentUser.currentPa);
                    }
                    currentChevalier = currCheval;
                    break;
                }
            }

            if (currentChevalier == null)
                Debug.LogError("Chevalier " + currentUser.name + " not found");
            currentFichePerso.InsertNewPerso(currentChevalier);
            currentSI.InsertNewPerso(currentChevalier);
            currentCM.InitCapacite(currentChevalier);
            currentMM.currentInit(currentChevalier);
            currentWM.currentInit(currentChevalier);
        }
    }

    public void LoadChevalierCurrent(Chevalier currentChevalier, int newCdf, int newPe, int newPv, int newPen, int newPa)
    {
        currentChevalier.currentCDF = newCdf;
        currentChevalier.currentPen = newPen;
        currentChevalier.currentPv = newPv;
        currentChevalier.currentPe = newPe;
        currentChevalier.currentPa = newPa;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveNote(string NewNote)
    {
        if (NewNote != null)
        {
            currentSM.SaveNote(NewNote);
        }
    }


    public void Quit()
    {
        FindObjectOfType<StatInfo>().UpdateChevalierInfo(currentChevalier);
        currentUser.UpdateUser(currentChevalier);
        currentSM.SaveNote(FindObjectOfType<NoteManager>().GetText());
        currentSM.SaveData(currentUser);
        Application.Quit();
    }

    void ActiveChoicePannel()
    {
        jeuxStdPannel.SetActive(false);
        choicePannel.SetActive(true);
    }

    public void ChooseAChevalier(Chevalier newChevalier)
    {
        choicePannel.SetActive(false);
        jeuxStdPannel.SetActive(true);
        currentChevalier = newChevalier;
        currentFichePerso.InsertNewPerso(currentChevalier);
        currentUser = new User(currentChevalier);
        currentSM.SaveData(currentUser);
    }
}
