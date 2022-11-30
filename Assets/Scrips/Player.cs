using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameObject ghul;
    public GameObject poisoning;
    public GameObject camera;




    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveGhul()
    {
        ghul.SetActive(true);
    }
    public void DctiveGhul()
    {
        ghul.SetActive(false);
    }

    public void poisoningEffect()
    {
        poisoning.SetActive(true);
        camera.SetActive(false);
    }



}
