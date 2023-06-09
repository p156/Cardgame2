using UnityEditor;
using UnityEditorInternal;

/// <summary>
/// イベントデータのinspectorを拡張するEditorクラス
/// </summary>
[CustomEditor(typeof(NPCEvent))]
public class EventDataEditor : Editor
{
    private ReorderableList reorderableList;
    private SerializedProperty actionDataList;

    private void OnEnable()
    {
        actionDataList = serializedObject.FindProperty("actionList");

        reorderableList = new ReorderableList(serializedObject, actionDataList);
        reorderableList.drawElementCallback = (rect, index, active, focused) => {
            var actionData = actionDataList.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(rect, actionData);
        };
        reorderableList.drawHeaderCallback = (rect) => EditorGUI.LabelField(rect, "Event List");
        reorderableList.elementHeightCallback = index => EditorGUI.GetPropertyHeight(actionDataList.GetArrayElementAtIndex(index));
    }

    public override void OnInspectorGUI()
    {
        var Myimage = serializedObject.FindProperty("My");
        EditorGUILayout.PropertyField(Myimage);
        var Enemyimage = serializedObject.FindProperty("Enemy");
        EditorGUILayout.PropertyField(Enemyimage);
        serializedObject.ApplyModifiedProperties();

        serializedObject.Update();
        reorderableList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}