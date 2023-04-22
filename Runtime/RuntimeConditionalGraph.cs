using UnityEngine;
using GraphProcessor;
using NodeGraphProcessor.Examples;
using System;

public class RuntimeConditionalGraph : MonoBehaviour
{
	[Header("Graph to Run on Start")]
	public BaseGraph graph;
	public DialogueGlobalData dialogueGlobalData;
	private ConditionalProcessor processor;
	private GameObject dialogueBubbleInstance;
	private DialogueBubbleWriter dialogueBubbleWriter;

	private void Start()
	{
		if(graph != null)
			processor = new ConditionalProcessor(graph);

		processor.Run();
	}

	public void PlayDialogue(DialogueSpeechData dialogueSpeechData , Action OnFinished)
	{
		CreateDialogueBubbleInstance();
		dialogueBubbleWriter.WriteNewText(dialogueSpeechData);
    }

	private void CreateDialogueBubbleInstance()
	{
		if (dialogueBubbleInstance == null)
		{
			dialogueBubbleInstance = Instantiate(dialogueGlobalData.DialoguePrefab);
            dialogueBubbleWriter = dialogueBubbleInstance.GetComponent<DialogueBubbleWriter>();
        }
        dialogueBubbleInstance.SetActive(true);
    }
}