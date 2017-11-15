using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	[SerializeField] private GameObject _dialogueBox;
	[SerializeField] private Dialogue _dialogue;
	[SerializeField] private GameObject _menu;

	public void TriggerDialogue ()
	{
		_dialogueBox.SetActive(true);
		FindObjectOfType<DialogueManager>().StartDialogue(_dialogue);
		_menu.SetActive(false);
	}
}