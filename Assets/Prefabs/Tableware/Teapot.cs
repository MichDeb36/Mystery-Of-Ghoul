using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Teapot : MonoBehaviour
{
    public AudioSource pouringTea;
    public GameObject tea;

    public void PlayPouringTea()
    {
        pouringTea.Play();
    }
    public void ActiveTea()
    {
        tea.SetActive(true);
    }
}
