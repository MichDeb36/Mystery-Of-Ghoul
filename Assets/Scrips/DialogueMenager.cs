using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.UnityIntegration;
using Ink.Runtime;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class DialogueMenager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;
    private static DialogueMenager instance;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private DialogueVariables dialogueVariables;
    private Coroutine displayLineCoroutine;

    public float typingSpeed = 0.04f;
    public int voicesLong = 5;
    public AudioClip[] voices;
    public AudioSource voic;
    public XRController controller;
    public Button[] but;


    private List<int> queueVoices = new List<int>();
    private int voicesCount = 0;
    private bool playDiologue = false;
    private InputDevice device;
    private bool rightHandState = false;
    private bool conStory = true;
    private Button[] buttons;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Wiecej Dialogue Manager ni¿ jednen");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
        ClearVoices();

        

    }

    public static DialogueMenager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach(GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
        rightHandState = false;
}

    // Update is called once per frame
    void Update()
    {
        device = controller.inputDevice;
        if (!dialogueIsPlaying)
        {
            return;
        }
        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out bool buttonValue))
        {
            if(buttonValue && conStory)
            {
                ClearVoices();
                ContinueStory();

                conStory = false;
            }    
        }
        if (voicesCount <= voicesLong && playDiologue)
        {
            PlayGeneratingVoices();
        }
    }

    /*public void TaskOnClick()
    {
        if (conStory)
        {
            ClearVoices();
            ContinueStory();

            conStory = false;
        }
        Debug.Log("Klikn¹³eœ przycisk!");
    }*/

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        //yield return new WaitForSeconds(0.2f);

        dialogueVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if(displayLineCoroutine != null)
            {
               StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
            DisplayChoice();
            playDiologue = true;
        }
        else
        {
            //StartCoroutine(ExitDialogueMode());
            ExitDialogueMode();
        }
    }

    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = "";
        foreach(char latter in line.ToCharArray())
        {
            dialogueText.text += latter;
            yield return new WaitForSeconds(typingSpeed);
        }
        conStory = true;
    }

    private void DisplayChoice()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("Liczba wyborów" + currentChoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for(int i = index; i<choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
    
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null; 
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if(variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }

    private void ClearVoices()
    {
        voic.Stop();
        queueVoices.Clear();
        GeneratingVoices();
        voicesCount = 0;
    }

    private void GeneratingVoices()
    {
        int num;
        for (int i = 0; i <= voicesLong; i++)
        {
            num = Random.Range(0, voices.Length);
            queueVoices.Add(num);
        }
    }

    private void PlayGeneratingVoices()
    {
        if (!voic.isPlaying)
        {
            voic.clip = voices[queueVoices[voicesCount]];
            voic.Play();
            voicesCount++;
        }

    }
}
