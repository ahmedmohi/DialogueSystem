using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using GraphProcessor;
using UnityEditor.Callbacks;
using System.IO;
using NodeGraphProcessor.Examples;
using UnityEditor.Graphs;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class GraphAssetCallbacks
{
	[MenuItem("Assets/Create/NodeGraph/GraphProcessor", false, 10)]
	public static void CreateGraphPorcessor()
	{
		var graph = ScriptableObject.CreateInstance< BaseGraph >();
		ProjectWindowUtil.CreateAsset(graph, "GraphProcessor.asset");
		AddStartNode(graph);
    }

    [MenuItem("Assets/Create/NodeGraph/DialogueGraphProcessor", false, 10)]
    public static void CreateDialogueGraphPorcessor()
    {
        var graph = ScriptableObject.CreateInstance<DialogueGraph>();
        ProjectWindowUtil.CreateAsset(graph, "DialogueGraphProcessor.asset");
        AddStartNode(graph);
    }

    static void AddStartNode(BaseGraph graph )
	{
        graph.AddNode(BaseNode.CreateFromType(typeof(StartNode), 
			new Vector2(200 , 300)));
    }

	[OnOpenAsset(0)]
	public static bool OnBaseGraphOpened(int instanceID, int line)
	{
		var asset = EditorUtility.InstanceIDToObject(instanceID) as BaseGraph;

		if (asset != null && AssetDatabase.GetAssetPath(asset).Contains("Examples"))
		{
			EditorWindow.GetWindow<AllGraphWindow>().InitializeGraph(asset as BaseGraph);
			return true;
		}
		return false;
	}
}
