using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Dialogue2 : MonoBehaviour
{

   // public TextMeshProUGUI textDisplay;
    public Text DialogueTxt;
   // public string[] sentences;
    public Queue<string> Sentences;
    //private int index;
     public float typingSpeed;
    public Queue<AudioClip> AudioClips;
    public AudioSource audioSource;

    //public GameObject AnswerPanel;
    //private AudioSource source;

    public Animator talker;
    public bool haveTalkerModel;

    void Start()
    {
        //source = GetComponent<AudioSource>();
        Sentences = new Queue<string>();
        AudioClips = new Queue<AudioClip>();
        //StartCoroutine(Type());
    }

    void Update()
    {
       /* if (textDisplay.text == sentences[index])
        {
            AnswerPanel.SetActive(true);
        }
       */
    }
    /*
    IEnumerator Type()
    {
        foreach (char letter in Sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }
   */

    IEnumerator TypeSentence(string sentence)
    {
        DialogueTxt.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            DialogueTxt.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void StartDialog(Dialogue dialogue)
    {
        if (haveTalkerModel)
        {
            talker.SetBool("Talk", true);
        }

        Sentences.Clear();
        AudioClips.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            Sentences.Enqueue(sentence);
        }

        foreach (AudioClip audioClip in dialogue.audioClips) //play next audio clip
        {
            AudioClips.Enqueue(audioClip);
        }
        NextSentence();
    }
    public void NextSentence()
    {
        if (Sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //Play Audio Clip Here
        AudioClip audioclip = AudioClips.Dequeue();
        audioSource.Stop();
        audioSource.clip = audioclip;
        audioSource.Play();

        /* if (index < sentences.Length - 1)
         {
             index++;
             textDisplay.text = "";
             StartCoroutine(Type());
         }
        */
        /* else
         {
             textDisplay.text = "";
             AnswerPanel.SetActive(false);
         }
        */
    }
    void EndDialogue()
    {
        Debug.Log("End Of Conversation");

        if (haveTalkerModel)
        {
            talker.SetBool("Talk", false);
        }

    }
}
