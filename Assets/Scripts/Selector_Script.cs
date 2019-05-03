using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_Script : MonoBehaviour
{
    public GameObject Wizard;
    public GameObject Ninja;
    public GameObject Barbarian;
    public GameObject Pirate;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer WizardRender, NinjaRender, BarbarianRender, PirateRender;
    //private List<GameObject> myChars;
    //private int SelectionIndex = 0;

    //private void Start()
    //{
    //    myChars = new List<GameObject>();
    //    foreach (Transform t in transform)
    //    {
    //        myChars.Add(t.gameObject);
    //        t.gameObject.SetActive = false;

    //    }
    //    SelectionIndex.SetActive = true;



    //}
    private void Awake()
    {
        CharacterPosition = Wizard.transform.position;
        OffScreen = Pirate.transform.position;
        WizardRender = Wizard.GetComponent<SpriteRenderer>();
        NinjaRender = Wizard.GetComponent<SpriteRenderer>();
        BarbarianRender = Wizard.GetComponent<SpriteRenderer>();
        PirateRender = Wizard.GetComponent<SpriteRenderer>();

    }
    public void NextCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                WizardRender.enabled = false;
                Wizard.transform.position = OffScreen;
                Ninja.transform.position = CharacterPosition;
                NinjaRender.enabled = true;
                CharacterInt++;
                break;
            case 2:
                NinjaRender.enabled = false;
                Ninja.transform.position = OffScreen;
                Barbarian.transform.position = CharacterPosition;
                BarbarianRender.enabled = true;
                CharacterInt++;
                break;
            case 3:
                BarbarianRender.enabled = false;
                Barbarian.transform.position = OffScreen;
                Pirate.transform.position = CharacterPosition;
                PirateRender.enabled = true;
                CharacterInt++;
                break;
            case 4:
                PirateRender.enabled = false;
                Pirate.transform.position = OffScreen;
                Wizard.transform.position = CharacterPosition;
                WizardRender.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }
    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                WizardRender.enabled = false;
                Wizard.transform.position = OffScreen;
                Pirate.transform.position = CharacterPosition;
                PirateRender.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                NinjaRender.enabled = false;
                Ninja.transform.position = OffScreen;
                Wizard.transform.position = CharacterPosition;
                WizardRender.enabled = true;
                CharacterInt--;

                break;
            case 3:
                BarbarianRender.enabled = false;
                Barbarian.transform.position = OffScreen;
                Ninja.transform.position = CharacterPosition;
                NinjaRender.enabled = true;
                CharacterInt--;
                break;
            case 4:
                PirateRender.enabled = false;
                Pirate.transform.position = OffScreen;
                Barbarian.transform.position = CharacterPosition;
                BarbarianRender.enabled = true;
                CharacterInt--;

                break;
            default:
                ResetInt();
                break;
        }
    }
    private void ResetInt()
    {
        if (CharacterInt >= 4)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 4;
        }
    }
    public void CharacterSelect()
    {
        SceneManager.LoadScene("MainScreen");
    }

}
