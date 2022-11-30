using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour
{
    //[Header("Visual Cue")]
    //[SerializeField] private GameObject VisualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInRange;
    public Animator animator;
    

    private void Awake()
    {
        playerInRange = false;
        //VisualCue.SetActive(false);
    }

    private void Update()
    {
        if(playerInRange && !DialogueMenager.GetInstance().dialogueIsPlaying)
        {
            //Debug.Log("Witaj");
            animator.SetBool("IsStay", true);
            DialogueMenager.GetInstance().EnterDialogueMode(inkJSON);
            
        }

        else if(!playerInRange)
        {
            animator.SetBool("IsStay", false);
            //Debug.Log("Ide dalej");
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            //Debug.Log("Wszedl");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            //Debug.Log("Wyszedl");
            playerInRange = false;
            DialogueMenager.GetInstance().ExitDialogueMode();
        }
    }





}
