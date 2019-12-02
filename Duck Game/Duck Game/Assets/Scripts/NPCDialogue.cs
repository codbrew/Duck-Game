using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCDialogue : MonoBehaviour
{
    public Transform player;
    float distance;
    public float maxAllowedDistance = 3f;

    public GameObject talkToMe;
    public DisplayText myText;
    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        myText = GameObject.FindWithTag("TextManager").GetComponent<DisplayText>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        if (distance < maxAllowedDistance)
        {
            Debug.Log("Player in Talking Distance");
            //  talkToMe.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerUnitInfo>().npcTalkCounter == 0)
                {
                    myText.AddToQueue("Oi! You think your duck is good enough for my precious baby?");
                    myText.AddToQueue("Good luck with that!");

                }
                if(GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerUnitInfo>().npcTalkCounter == 1)
                {
                    myText.AddToQueue("Well, well, well. Look who's back!");
                    myText.AddToQueue("You better stop pestering my little child!");
                }
                if(GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerUnitInfo>().npcTalkCounter >= 2)
                {
                    myText.AddToQueue("Don't you ever give up?!");
                    myText.AddToQueue("My duck will never love yours! Hmph!");
                }
                GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerUnitInfo>().npcTalkCounter++;
                myText.initiateBattleAfterText = true;

            }
        }
        else
        {
            Debug.Log("Player Not in Talking Distance");
          //  talkToMe.gameObject.SetActive(false);
        }


    }
}
