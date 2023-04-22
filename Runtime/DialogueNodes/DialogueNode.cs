using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GraphProcessor;
using System.Linq;
using NodeGraphProcessor.Examples;
using UnityEngine.Rendering;

[System.Serializable]
public struct DialogueSpeechData
{
    public string text;
}


[System.Serializable, NodeMenuItem("Dialogue/Talk")]
public class DialogueNode : WaitableNode
{
    public override string name => "Dialogue";

    [SerializeField, Input(name = "Seconds")]
    public float waitTime = 1f;

    public DialogueSpeechData data;
    private RuntimeConditionalGraph waitMonoBehaviour;

    protected override void Process()
    {
        //	We should check where this Process() called from. But i don't know if this is an elegant and performant way to do that.
        //	If this function is called from other than the ConditionalNode, then there will be problems, errors, unforeseen consequences, tears.
        // var isCalledFromConditionalProcessor = new StackTrace().GetFrame(5).GetMethod().ReflectedType == typeof(ConditionalProcessor);
        // if(!isCalledFromConditionalProcessor) return;

        RuntimeConditionalGraph waitMonoBehaviour = GameObject.FindObjectOfType<RuntimeConditionalGraph>();

        waitMonoBehaviour.PlayDialogue(data, ProcessFinished);

        //waitMonoBehaviour.Process(waitTime, ProcessFinished);
    }
}
