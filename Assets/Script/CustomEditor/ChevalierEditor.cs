using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(Chevalier))]

public class ChevalierEditor : Editor
{
    private string[] tavbs = { "Chair", "Bête", "Machine", "Dame", "Masque" };
    private int tabIndex = 0;
    private string[] tabMotiv = { "Mineur 1", "Mineur 2", "Majeur"};
    private int indexMotive = 0;
    private string[] tabArcane = { "Tarot Avantage PJ 1", "Tarot Avantage PJ 2", "Tarot Avantage IA", "Tarot Inconvenient PJ", "Tarot Inconvenient IA" };
    private int indexArcane = 0;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Chevalier chevalier = (Chevalier)target;

       
        EditorGUILayout.BeginVertical();
        tabIndex = GUILayout.Toolbar(tabIndex, tavbs);
        EditorGUILayout.EndVertical();
        switch(tabIndex)
        {
            case 0:
                ChairTab(chevalier);
                break;
            case 1:
                BeteTab(chevalier);
                break;
            case 2:
                MachineTab(chevalier);
                break;
            case 3:
                DameTab(chevalier);
                break;
            case 4:
                MasqueTab(chevalier);
                break;
            default:
                break;
        }

        EditorGUILayout.BeginVertical();
        indexMotive = GUILayout.Toolbar(indexMotive, tabMotiv);
        EditorGUILayout.EndVertical();
        switch (indexMotive)
        {
            case 0:
                Motivation(chevalier, 0);
                break;
            case 1:
                Motivation(chevalier, 1);
                break;
            case 2:
                Motivation(chevalier, 2);
                break;
            default:
                break;
        }

        EditorGUILayout.BeginVertical();
        indexArcane = GUILayout.Toolbar(indexArcane, tabArcane);
        EditorGUILayout.EndVertical();
        switch (indexArcane)
        {
            case 0:
                Arcane(chevalier, 0);
                break;
            case 1:
                Arcane(chevalier, 1);
                break;
            case 2:
                Arcane(chevalier, 2);
                break;
            case 3:
                Arcane(chevalier, 3);
                break;
            case 4:
                Arcane(chevalier, 4);
                break;
            default:
                break;
        }
    }

    private void Motivation(Chevalier chevalier, int indexMotive)
    {
        chevalier.motiv[indexMotive].objectif = EditorGUILayout.TextField("Motivation:", chevalier.motiv[indexMotive].objectif);
    }
    private void Arcane(Chevalier chevalier, int indexArcane)
    {

        // Afficher un champ GameObject avec une étiquette personnalisée
        chevalier.arcanes[indexArcane].card = EditorGUILayout.ObjectField(chevalier.arcanes[indexArcane].card, typeof(Tarot)) as Tarot;

    }

    private void ChairTab(Chevalier chevalier)
    {
        chevalier.allStat["Chair"].value = EditorGUILayout.IntField("Chair:", chevalier.allStat["Chair"].value);
        chevalier.allStat["Déplacement"].value = EditorGUILayout.IntField("Déplacement:", chevalier.allStat["Déplacement"].value);
        chevalier.allStat["Force"].value = EditorGUILayout.IntField("Force:", chevalier.allStat["Force"].value);
        chevalier.allStat["Endurance"].value = EditorGUILayout.IntField("Endurance:", chevalier.allStat["Endurance"].value);
        chevalier.allStat["Déplacement"].overdrive = EditorGUILayout.IntField("Déplacement OD:", chevalier.allStat["Déplacement"].overdrive);
        chevalier.allStat["Force"].overdrive = EditorGUILayout.IntField("Force OD:", chevalier.allStat["Force"].overdrive);
        chevalier.allStat["Endurance"].overdrive = EditorGUILayout.IntField("Endurance OD:", chevalier.allStat["Endurance"].overdrive);

    }
    private void BeteTab(Chevalier chevalier)
    {
        chevalier.allStat["Bête"].value = EditorGUILayout.IntField("Bête:", chevalier.allStat["Bête"].value);
        chevalier.allStat["Hargne"].value = EditorGUILayout.IntField("Hargne:", chevalier.allStat["Hargne"].value);
        chevalier.allStat["Combat"].value = EditorGUILayout.IntField("Combat:", chevalier.allStat["Combat"].value);
        chevalier.allStat["Instinct"].value = EditorGUILayout.IntField("Instinct:", chevalier.allStat["Instinct"].value);
        chevalier.allStat["Combat"].overdrive = EditorGUILayout.IntField("Combat OD:", chevalier.allStat["Combat"].overdrive);
        chevalier.allStat["Hargne"].overdrive = EditorGUILayout.IntField("Hargne OD:", chevalier.allStat["Hargne"].overdrive);
        chevalier.allStat["Instinct"].overdrive = EditorGUILayout.IntField("Instinct OD:", chevalier.allStat["Instinct"].overdrive);

    }
    private void MachineTab(Chevalier chevalier)
    {
        chevalier.allStat["Machine"].value = EditorGUILayout.IntField("Machine:", chevalier.allStat["Machine"].value);
        chevalier.allStat["Tir"].value = EditorGUILayout.IntField("Tir:", chevalier.allStat["Tir"].value);
        chevalier.allStat["Savoir"].value = EditorGUILayout.IntField("Savoir:", chevalier.allStat["Savoir"].value);
        chevalier.allStat["Technique"].value = EditorGUILayout.IntField("Technique:", chevalier.allStat["Technique"].value);
        chevalier.allStat["Tir"].overdrive = EditorGUILayout.IntField("Tir OD:", chevalier.allStat["Tir"].overdrive);
        chevalier.allStat["Savoir"].overdrive = EditorGUILayout.IntField("Savoir OD:", chevalier.allStat["Savoir"].overdrive);
        chevalier.allStat["Technique"].overdrive = EditorGUILayout.IntField("Technique OD:", chevalier.allStat["Technique"].overdrive);
    }
    private void DameTab(Chevalier chevalier)
    {
        chevalier.allStat["Dame"].value = EditorGUILayout.IntField("Dame:", chevalier.allStat["Dame"].value);
        chevalier.allStat["Aura"].value = EditorGUILayout.IntField("Aura:", chevalier.allStat["Aura"].value);
        chevalier.allStat["Parole"].value = EditorGUILayout.IntField("Parole:", chevalier.allStat["Parole"].value);
        chevalier.allStat["Sang-Froid"].value = EditorGUILayout.IntField("Sang-Froid:", chevalier.allStat["Sang-Froid"].value);
        chevalier.allStat["Aura"].overdrive = EditorGUILayout.IntField("Aura OD:", chevalier.allStat["Aura"].overdrive);
        chevalier.allStat["Parole"].overdrive = EditorGUILayout.IntField("Parole OD:", chevalier.allStat["Parole"].overdrive);
        chevalier.allStat["Sang-Froid"].overdrive = EditorGUILayout.IntField("Sang-Froid OD:", chevalier.allStat["Sang-Froid"].overdrive);
    }
    private void MasqueTab(Chevalier chevalier)
    {
        chevalier.allStat["Masque"].value = EditorGUILayout.IntField("Masque:", chevalier.allStat["Masque"].value);
        chevalier.allStat["Discrétion"].value = EditorGUILayout.IntField("Discrétion:", chevalier.allStat["Discrétion"].value);
        chevalier.allStat["Dextérité"].value = EditorGUILayout.IntField("Dextérité:", chevalier.allStat["Dextérité"].value);
        chevalier.allStat["Perception"].value = EditorGUILayout.IntField("Perception:", chevalier.allStat["Perception"].value);
        chevalier.allStat["Discrétion"].overdrive = EditorGUILayout.IntField("Discrétion OD:", chevalier.allStat["Discrétion"].overdrive);
        chevalier.allStat["Dextérité"].overdrive = EditorGUILayout.IntField("Dextérité OD:", chevalier.allStat["Dextérité"].overdrive);
        chevalier.allStat["Perception"].overdrive = EditorGUILayout.IntField("Perception OD:", chevalier.allStat["Perception"].overdrive);

    }
}
#endif
