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

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);

        if (distance < maxAllowedDistance)
        {
            Debug.Log("Player in Talking Distance");
            talkToMe.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Player Not in Talking Distance");
            talkToMe.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //call Adny's Function
        }
    }
}
