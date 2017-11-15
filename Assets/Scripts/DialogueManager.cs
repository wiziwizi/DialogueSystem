using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	[SerializeField] private Text _nameText, _dialogueText;

	[SerializeField] private GameObject _dialogueBox;
	
	[SerializeField] private GameObject _continue;
	[SerializeField] private Queue<string> _sentences;
	private Dialogue _dialogue;

	private void Start () {
		_sentences = new Queue<string>();
	}

	public void StartDialogue (Dialogue dialogue)
	{
		_continue.SetActive(true);
		_dialogue = dialogue;
		_nameText.text = dialogue.Name;
		_sentences.Clear();

		foreach (var sentence in dialogue.Lines)
		{
			_sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (_sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		
		var sentence = _sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	private IEnumerator TypeSentence (string sentence)
	{
		_dialogueText.text = "";
		foreach (var letter in sentence.ToCharArray())
		{
			_dialogueText.text += letter;
			yield return null;
		}
	}

	private void EndDialogue()
	{
		_continue.SetActive(false);
		if (_dialogue.NextDialogue.Length == 0)
		{
			_dialogueBox.SetActive(false);
		}
		else
		{
			_dialogue.NextDialogue[0].SetActive(true);
		}
		
	}

}
