using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject choicePannel;
    public GameObject jeuxStdPannel;

    public SaveManager currentSM;

    public StatInfo currentSI;
    public CapacitéManager currentCM;
    public FichePerso currentFichePerso;
    public NoteManager note;

    [SerializeField]
    public Chevalier currentChevalier;

    public User currentUser;
    public string currentNote;

    public GameObject JoueurPannel;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<TwitchChatClient>().Init();
        currentCM = FindObjectOfType<CapacitéManager>();
        currentFichePerso = FindObjectOfType<FichePerso>();
        currentSI = FindObjectOfType<StatInfo>();
        currentSM = FindObjectOfType<SaveManager>();
        currentUser = currentSM.LoadUser();
        ModuleManager currentMM = FindObjectOfType<ModuleManager>();
        WeaponManager currentWM = FindObjectOfType<WeaponManager>();

        note.LoadNote(currentSM.LoadNote());

        if (currentUser == null )
            ActiveChoicePannel();
        else
        { 
            Chevalier[] allChevalier = Resources.LoadAll<Chevalier>("Chevalier"); 
            //  
            foreach(Chevalier currCheval in allChevalier)
            {
                if (currCheval.name == currentUser.name)
                {
                    if (currentUser.chevalier == null)
                    {
                        LoadChevalierCurrent(currCheval, currCheval.armure.ChampDeForce, currCheval.pe, currCheval.pv, currCheval.armure.PointEnergie, currCheval.armure.PointArmure);
                        currentSM.SaveData(new User(currCheval));
                    }
                    currentChevalier = currCheval;
                    break;
                }
            }

            if (currentChevalier == null)
                Debug.LogError("Chevalier " + currentUser.name + " not found");
            FindObjectOfType<MjSendInformation>().SetName(currentChevalier.name);
            currentFichePerso.InsertNewPerso(currentChevalier);
            currentSI.InsertNewPerso(currentChevalier);
            currentCM.InitCapacite(currentChevalier);
            currentMM.currentInit(currentChevalier);
            currentWM.currentInit(currentChevalier);
        }
    }

    public void LoadChevalierCurrent(Chevalier currentChevalier, int newCdf, int newPe, int newPv, int newPen, int newPa)
    {
        currentChevalier.currentEnergie = newPen;
        currentChevalier.currentVie = newPv;
        currentChevalier.currentEspoir = newPe;
        currentChevalier.currentArmor = newPa;

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
        currentSM.SaveNote(note.GetText());
        currentSM.SaveData(currentUser);
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
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
