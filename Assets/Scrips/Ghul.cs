using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Ghul : BTAgent
{
    public GameObject[] patrolPoints;
    public GameObject talkingToCemeteryPoints;
    public Animator animator;
    public AudioSource roar;
    public AudioSource runSound;
    public AudioSource walkSound;
    public AudioSource magicSpel;
    public AudioSource thunder;
    public AudioSource gunSound;
    public AudioSource laughing;
    public GameObject LeftEye;
    public GameObject RightEye;
    public Animator teaPot;
    public GameObject redBackground;
    public GameObject rain;
    public GameObject head;
    public Transform player;
    public Animator playerAnimator;
    public GameObject bodyGhul;
    public bool kneling = false;
    public GameObject tablet;
    public Animator flowersAnimator;
    public GameObject dialogue1;
    public GameObject dialogue2;

    private string info = "";
    private string oldInfo = "";
    private GameObject gameMenager;
    public bool goToCemetery = false;
    public bool talkingToCemetery = false;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        Leaf ghulWaiting = new Leaf("Ghul Waiting", GhulWaiting);
   
        Sequence goToCemetery = new Sequence("Select Patrol Point2");
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            Leaf pp = new Leaf("Go to " + patrolPoints[i].name, i, GoToCemetery);
            goToCemetery.addChild(pp);
        }

        BehaviourTree waiting = new BehaviourTree();
        waiting.addChild(ghulWaiting);

        DepSequence moveToCemetery = new DepSequence("Move to Patron", waiting, agent);
        moveToCemetery.addChild(goToCemetery);

        tree.addChild(moveToCemetery);

    }
    public Node.Status GoToCemetery(int i)
    {
        animator.SetBool("IsWalk", true);
        Node.Status s = GoToLocation(patrolPoints[i].transform.position);
        if (s == Node.Status.SUCCESS)
        {
            if(i == (patrolPoints.Length-1))
            {
                goToCemetery = false;
                animator.SetBool("IsWalk", false);
                animator.SetTrigger("KnelingDown");
            }
        }
        return s;
    }

    public void TalkingToCemetery()
    {
        animator.SetBool("IsWalk", true);
        Node.Status s = GoToLocation(talkingToCemeteryPoints.transform.position);
        if (s == Node.Status.SUCCESS)
        { 
            animator.SetBool("IsWalk", false);
            talkingToCemetery = false;
            dialogue2.SetActive(true);
            
        }
    }

    public Node.Status GhulWaiting()
    {
        if (goToCemetery)
            return Node.Status.SUCCESS;
        return Node.Status.FAILURE;
    }


    public Node.Status GoToPoint(int i)
    {
        if(goToCemetery)
        {
            Node.Status s = GoToLocation(patrolPoints[i].transform.position);
            animator.SetBool("IsWalk", true);
            return s;
        }
        return Node.Status.RUNNING;
    }

    public void PlayRoar()
    {
        roar.Play();
    }

    public void PlayRunSound()
    {
        walkSound.Play();
    }

    public void PlayWalkSound()
    {
        walkSound.Play();
    }

    public void PlayMagicSpell()
    {
        magicSpel.Play();
    }

    public void LightingEye(int intensity)
    {
        if(intensity > 0)
        {
            LeftEye.SetActive(true);
            RightEye.SetActive(true);
            Light LightRightEye = RightEye.GetComponent<Light>();
            Light LightLeftEye = LeftEye.GetComponent<Light>();
            LightLeftEye.intensity = 10;
            LightRightEye.intensity = 10;
        }
        else
        {
            LeftEye.SetActive(false);
            RightEye.SetActive(false);
        } 
    }

    public void PlayTeaServing()
    {
        animator.SetTrigger("TeaServing");
        teaPot.SetTrigger("GoTea");
    }

    public void PlayRedLight(int intensity)
    {
        //redBackground.SetActive(true);
        Light redLight = redBackground.GetComponent<Light>();
        redLight.intensity = intensity;
    }
    public void PlayLaughing()
    {
        laughing.Play();
    }
    public void PlayThunder()
    {
        thunder.Play();
    }
    public void PlayYes()
    {
        animator.SetTrigger("Yes");
    }
    public void PlayNo()
    {
        animator.SetTrigger("No");
    }
    public void ActiveRain()
    {
        rain.SetActive(true);
    }
    public void DeactiveRain()
    {
        rain.SetActive(false);
    }
    public void DeactiveTablet()
    {
        tablet.SetActive(false);
    }
    public void LoadScane(int scane)
    {
        string nameScane = "FirstHome";
        switch (scane)
        {
            case 1:
                SceneManager.LoadScene("Scene1");
                break;
            case 2:
                SceneManager.LoadScene("Scene2");
                break;
            case 3:
                SceneManager.LoadScene("Scene3");
                break;
            case 4:
                SceneManager.LoadScene("Scene4");
                break;
            case 6:
                SceneManager.LoadScene("Scene6");
                break;
            case 7:
                SceneManager.LoadScene("ExitGame1");
                break;
            case 8:
                SceneManager.LoadScene("ExitGame2");
                break;
        }
    }
    public void PlayerDeath()
    {
        playerAnimator.SetTrigger("death");
    }
    public void DeactiveBodyGhul()
    {
        bodyGhul.SetActive(false);
    }
    public void ScaringPlayer()
    {
        animator.SetTrigger("Scaring");
    }
    public void ScaringPlayer2()
    {
        animator.SetTrigger("Scaring2");
    }
    public void ScaringPlayer3()
    {
        animator.SetTrigger("Scaring3");
    }
    public void ScaringPlayer4()
    {
        animator.SetTrigger("Scaring4");
    }
    public void GhulDeath()
    {
        animator.SetTrigger("Death");
    }
    public void KnelingDown()
    {
        animator.SetTrigger("Down");
    }
    public void PoisoningPlayer()
    {
        playerAnimator.SetTrigger("poisoned");
        animator.SetTrigger("poisoningPlayer");
    }
    public void PlayTransformFlowers()
    {
        flowersAnimator.SetTrigger("TransformFlower");
        animator.SetTrigger("TeaServing");
    }
    public void PlayToCementaryPlace()
    {
        goToCemetery = true;
        dialogue1.SetActive(false);
    }
    public void PlayTalkingToPlayer()
    {
        talkingToCemetery = true;
    }
    public void PlayGunSound()
    {
        gunSound.Play();
    }

    private void ActionMenager(string action)
    {
        switch(action)
        {
            case "death":
                ScaringPlayer();
                break;
            case "death2":
                ScaringPlayer2();
                break;
            case "death3":
                ScaringPlayer3();
                break;
            case "death4":
                ScaringPlayer4();
                break;
            case "servingTea":
                PlayTeaServing();
                break;
            case "poisoned":
                PoisoningPlayer();
                break;
            case "go":
                goToCemetery = true;
                break;
            case "stop":
                goToCemetery = false;
                break;
            case "yes":
                PlayYes();
                break;
            case "no":
                PlayNo();
                break;
            case "flowers":
                PlayTransformFlowers();
                break;
            case "goToCemetery":
                PlayToCementaryPlace();
                break;
            case "rain":
                ActiveRain();
                break;
            case "soldiers":
                PlayGunSound();
                break;
            case "endStory":
                LoadScane(8);
                break;
        }
    
    }

    void Update()
    {
        info = ((Ink.Runtime.StringValue)DialogueMenager.GetInstance().GetVariableState("feedback")).value;
        if (info != oldInfo)
        {
            ActionMenager(info);
        }
        oldInfo = info;
        if(kneling)
        {
            kneling = false;
            KnelingDown();
        }
            

        if (talkingToCemetery)
            TalkingToCemetery();
    }


}
