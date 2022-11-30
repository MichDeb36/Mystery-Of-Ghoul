using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : BTAgent
{
    public GameObject[] patrolPoints;
    public GameObject player;
    public AudioSource walkSound;
    public AudioSource howlSound;
    public Animator animator;

    private bool howl = false;
    private int oldPoint = -1;


    public override void Start()
    {
        base.Start();

        Leaf wolfHowl = new Leaf("Wol fHowl", WolfHowl);

        RSelector goToPatrol = new RSelector("Select Patrol Point");
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Leaf pp = new Leaf("Go to " + patrolPoints[i].name, i, GoToPatrol);
            goToPatrol.addChild(pp);
        }

        BehaviourTree waiting = new BehaviourTree();
        waiting.addChild(wolfHowl);

        DepSequence moveToPatrol = new DepSequence("Move to Patron", waiting, agent);
        moveToPatrol.addChild(goToPatrol);

        tree.addChild(moveToPatrol);

    }

    public Node.Status GoToPatrol(int i)
    {
        animator.SetBool("Run", true);
        Node.Status s = GoToLocation(patrolPoints[i].transform.position);
        if (s == Node.Status.SUCCESS)
        {
            if(oldPoint != i)
            {
                animator.SetBool("Run", false);
                howl = true;
                oldPoint = i;
                PlayHowl();
            }
        }
        return s;
    }

    public Node.Status WolfHowl()
    {
        if (!howl)
        {
            return Node.Status.SUCCESS;
        }   
        return Node.Status.FAILURE;
    }

    public void StopHowl()
    {
        howl = false;
    }

    public void PlayWalkSound()
    {
        walkSound.Play();
    }

    public void PlayHowl()
    {
        animator.SetTrigger("Howl");
    }
    public void PlayHowlSound()
    {
        howlSound.Play();
    }
}
