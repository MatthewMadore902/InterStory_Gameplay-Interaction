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
    private Queue<string> dialogue;

    public void Start()
    {
        dialogue = new Queue<string>();
    }
    
    public void StartDialogue(string[] sentance)
    {
        dialogue.Clear();
        dialogueUI.SetActive(true);

        Player.GetComponent<PlayerMovement_2D>().enabled = false;
        Player.GetComponent<PlayerInteraction>().enabled = false;
        aniamtor.SetFloat("Speed", 0);
        Player.GetComponent<Rigidbody>().velocity = Vector2.zero;

        foreach (string currentLine in sentance)
        {
            dialogue.Enqueue(currentLine);

        }
        DisplayNextSentance();
    }
    public void DisplayNextSentance()
    {
        if (dialogue.Count == 0)
        {
            EndDialouge();
            return;
        }
        string currentLine = dialogue.Dequeue();
        dialogueText.text = currentLine;
    }
    void EndDialouge()
    {
        dialogueUI.SetActive(false);
        Player.GetComponent<PlayerMovement_2D>().enabled = true;
        Player.GetComponent<PlayerInteraction>().enabled = true;
    }
}
