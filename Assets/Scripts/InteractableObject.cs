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

	public void Start()
	{
		infoText = GameObject.Find("InfoText").GetComponent<Text>();
	}
	public void Nothing()
	{
		Debug.LogWarning("Objct " + this.gameObject.name + " has no type set");
	}
	public void InfoMessage()
	{
		infoText.text = infoMessage;
	}
}
