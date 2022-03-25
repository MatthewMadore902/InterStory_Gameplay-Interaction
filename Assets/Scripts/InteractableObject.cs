using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObject : MonoBehaviour
{
	public enum InteractionType
	{
		nothing,
		info,
		pickup,
		dialouge
	}

	[Header("Type of interactions")]
	public InteractionType interType;

	[Header("Simple Info Message")]
	public string infoMessage;
	private Text infoText;

	[Header("Dialouge Text")]
	[TextArea(3, 10)]
	public string[] sentance;


	public GameObject dialogueBox;
	public DialougeManager dialogue;
	public bool disabled;

	public void Start()
	{
		infoText = GameObject.Find("infoText").GetComponent<Text>();
	}
	public void Nothing()
	{
		Debug.LogWarning("Object " + this.gameObject.name + " has no type set");
	}
	public void PickUp()
	{
		gameObject.SetActive(false);
	}
	public void InfoMessage()
	{
		StartCoroutine(ShowInfo(infoMessage, 2.5f));
		infoText.text = infoMessage;
	}
	public void Dialogue()
	{
		FindObjectOfType<DialougeManager>().StartDialogue(sentance);
		dialogueBox.SetActive(true);
	}
	IEnumerator ShowInfo(string message, float delay)
	{
		infoText.text = message;
		yield return new WaitForSeconds(delay);
		infoText.text = null;
	}
}
