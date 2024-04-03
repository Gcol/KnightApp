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

    public Player currentUser = null;
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
        currentUser = currentSM.LoadCaracter(FindObjectOfType<SaveManager>().LoadGlobalInfo().lastChevalier);
        ModuleManager currentMM = FindObjectOfType<ModuleManager>();
        WeaponManager currentWM = FindObjectOfType<WeaponManager>();

        note.LoadNote(currentSM.LoadNote());

        Debug.Log(currentUser);
        currentChevalier = new Chevalier(currentUser);
        
        FindObjectOfType<MjSendInformation>().SetName(currentChevalier.name);
        currentFichePerso.InsertNewPerso(currentChevalier);
        currentSI.InsertNewPerso(currentChevalier);
        currentCM.InitCapacite(currentChevalier);
        currentMM.currentInit(currentChevalier);
        currentWM.currentInit(currentChevalier);
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
        //currentUser.UpdateUser(currentChevalier);
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

    public void ChooseAChevalier(Chevalier newChevalier, string name)
    {
        choicePannel.SetActive(false);
        jeuxStdPannel.SetActive(true);
        currentChevalier = newChevalier;
        currentFichePerso.InsertNewPerso(currentChevalier);
        currentUser = new Player(currentChevalier);
        currentSM.SaveData(currentUser);
    }
}
