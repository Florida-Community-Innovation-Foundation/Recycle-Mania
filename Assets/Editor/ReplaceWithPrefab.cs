using UnityEngine;
using UnityEditor;

public class ReplaceWithPrefab : EditorWindow
{
    private GameObject prefabToUse;
    private bool keepName = true;

    [MenuItem("Tools/Replace Selected With Prefab")]
    public static void ShowWindow()
    {
        GetWindow<ReplaceWithPrefab>("Replace With Prefab");
    }

    void OnGUI()
    {
        GUILayout.Label("Replace selected scene objects with a prefab", EditorStyles.boldLabel);

        prefabToUse = (GameObject)EditorGUILayout.ObjectField(
            "Prefab",
            prefabToUse,
            typeof(GameObject),
            false
        );

        keepName = EditorGUILayout.Toggle("Keep original names", keepName);

        GUI.enabled = prefabToUse != null && Selection.gameObjects.Length > 0;

        if (GUILayout.Button("Replace Selected"))
        {
            ReplaceSelected();
        }

        GUI.enabled = true;
    }

    void ReplaceSelected()
    {
        GameObject[] selected = Selection.gameObjects;

        Undo.IncrementCurrentGroup();
        int undoGroup = Undo.GetCurrentGroup();

        foreach (GameObject oldObj in selected)
        {
            if (EditorUtility.IsPersistent(oldObj))
                continue; // skip assets in Project window

            Transform oldTransform = oldObj.transform;
            Transform oldParent = oldTransform.parent;
            int siblingIndex = oldTransform.GetSiblingIndex();

            GameObject newObj = (GameObject)PrefabUtility.InstantiatePrefab(prefabToUse, oldObj.scene);

            Undo.RegisterCreatedObjectUndo(newObj, "Create prefab replacement");

            Transform newTransform = newObj.transform;
            newTransform.SetParent(oldParent, false);
            newTransform.SetSiblingIndex(siblingIndex);

            newTransform.position = oldTransform.position;
            newTransform.rotation = oldTransform.rotation;
            newTransform.localScale = oldTransform.localScale;

            if (keepName)
                newObj.name = oldObj.name;

            Undo.DestroyObjectImmediate(oldObj);
        }

        Undo.CollapseUndoOperations(undoGroup);
    }
}