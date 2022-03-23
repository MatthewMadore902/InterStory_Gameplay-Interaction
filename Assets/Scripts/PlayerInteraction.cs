using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	public GameObject currentInterObj = null;
	public InteractableObject currentInteractObjScript = null;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && currentInterObj == true)
		{
			Checkinteraction();
		}
	}
	void Checkinteraction()
	{
		Debug.Log("This is a " + currentInterObj.name);

		if (currentInteractObjScript.interType == InteractableObject.InteractionType.nothing)
		{ currentInteractObjScript.Nothing(); }

		else if(currentInteractObjScript.interType == InteractableObject.InteractionType.nothing)
		{ currentInteractObjScript.InfoMessage(); }
	}


	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("InterObject") == true)
		{
			currentInterObj = other.gameObject;
			currentInteractObjScript = currentInterObj.GetComponent<InteractableObject>();
		}
	}
	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("InterObject") == true)
		{
			currentInterObj = null;
			currentInteractObjScript = null;
		}
	}

}
