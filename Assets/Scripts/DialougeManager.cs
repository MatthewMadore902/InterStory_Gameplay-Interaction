using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public GameObject dialogueUI;
    public Text dialogueText;
    public GameObject Player;
    public Animator aniamtor;
    private Queue<string> sentences;

    public void Start()
    {
        sentences = new Queue<string>();
    }
    
    public void StartDialogue(string[] sentance)
    {
        sentences.Clear();
        dialogueUI.SetActive(true);

        Player.GetComponent<PlayerMovement_2D>().enabled = false;
        Player.GetComponent<PlayerInteraction>().enabled = false;
        aniamtor.SetFloat("Speed", 0);
        Player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        Debug.Log("Start");
        foreach (string currentLine in sentance)
        {
            sentences.Enqueue(currentLine);

        }
        DisplayNextSentance();
    }
    public void DisplayNextSentance()
    {
        if (sentences.Count == 0)
        {
            EndDialouge();
            return;
        }
        string currentLine = sentences.Dequeue();
        dialogueText.text = currentLine;
        Debug.Log("Next");
    }
    void EndDialouge()
    {
        dialogueUI.SetActive(false);
        Player.GetComponent<PlayerMovement_2D>().enabled = true;
        Player.GetComponent<PlayerInteraction>().enabled = true;
    }
}
