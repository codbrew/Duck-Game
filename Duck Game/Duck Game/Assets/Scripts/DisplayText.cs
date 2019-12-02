using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayText : MonoBehaviour
{
    public Queue<string> myStrings;
    public GameObject textbox;
    public Text text;
    bool firstDisplay = false;
    public CharacterController characterController;
    public NPCDialogue npcDialogue;
    public bool initiateBattleAfterText = false;
    private void Start()
    {
        myStrings = new Queue<string>();
    }
    private void Update()
    {
        if (myStrings.Count != 0)
        {
            characterController.enabled = false;
            npcDialogue.enabled = false;
            if (firstDisplay == true)
            {
                
                textbox.SetActive(true);
                StartCoroutine(DisplayString(myStrings.Peek()));
                print(myStrings.Peek());
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                myStrings.Dequeue();
               
                clearText();
                if (myStrings.Count > 0)
                {
                    StartCoroutine(DisplayString(myStrings.Peek()));
                    print(myStrings.Peek());
                }
                else
                {
                    textbox.SetActive(false);
                }
                print("next Display");
            }
            firstDisplay = false;
        }
        else
        {
            if(initiateBattleAfterText == true)
            {
                SceneManager.LoadScene("Battle Scene");
            }
            firstDisplay = true;
            characterController.enabled = true; ;
            npcDialogue.enabled = true;
        }
    }
    public void AddToQueue(string mystring)
    {
        myStrings.Enqueue(mystring);
        print("added");
    }
    IEnumerator DisplayString(string mystring)
    {
        yield return new WaitForSeconds(.0001f);
        for (int i = 0; i < mystring.Length; i++)
        {
           /* if(Input.GetKeyDown(KeyCode.E))
            {
                clearText();
                yield break;
            }*/
            text.text += mystring[i];
            yield return new WaitForSeconds(.05f);

        }
    }
    void clearText()
    {
        text.text = "";
    }
}
