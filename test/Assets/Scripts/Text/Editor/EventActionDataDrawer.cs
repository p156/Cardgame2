using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �C�x���g�f�[�^�̊e�v�f��inspector�\�����J�X�^�}�C�Y���邽�߂�Drawer�N���X
/// </summary>
[CustomPropertyDrawer(typeof(EventActionData))]
public class EventActionDataDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // List�p��1�̃v���p�e�B�ł��邱�Ƃ���������PropertyScope�ň͂�
        using (new EditorGUI.PropertyScope(position, label, property))
        {
            // 0�w�肾��ReorderableList�̃h���b�O�Ɣ��̂�LineHeight���w��
            position.height = EditorGUIUtility.singleLineHeight;

            //�|�W�V��������
            var actionTypeRect = new Rect(position)
            {
                y = position.y
            };

            var actionTypeProperty = property.FindPropertyRelative("actionType");
            actionTypeProperty.enumValueIndex = EditorGUI.Popup(actionTypeRect, "�A�N�V����", actionTypeProperty.enumValueIndex, Enum.GetNames(typeof(EventActionType)));

            switch ((EventActionType)actionTypeProperty.enumValueIndex)
            {
                case EventActionType.Talk:
                    var talkNameRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var talkNameProperty = property.FindPropertyRelative("Who");
                    talkNameProperty.intValue = EditorGUI.IntField(talkNameRect, " �N 1PL 0Enemy " , talkNameProperty.intValue);

                    var speechRect = new Rect(talkNameRect)
                    {
                        y = talkNameRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var speechProperty = property.FindPropertyRelative("speech");
                    speechProperty.intValue = EditorGUI.IntField(speechRect, " �����o�� ", speechProperty.intValue);

                    var talkTextLabelRect = new Rect(speechRect)
                    {
                        y = speechRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    EditorGUI.LabelField(talkTextLabelRect, "�e�L�X�g");

                    var talkTextRect = new Rect(talkTextLabelRect)
                    {
                        // TextArea�Ȃ̂�3�s���m��
                        y = talkTextLabelRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 3)
                    };
                    var talkTextProperty = property.FindPropertyRelative("talkText");
                    talkTextProperty.stringValue = EditorGUI.TextArea(talkTextRect, talkTextProperty.stringValue);

                    var RubytalkTextLabelRect = new Rect(talkTextRect)
                    {
                        y = talkTextRect.y + EditorGUIUtility.singleLineHeight * 3f + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 1)
                    };
                    EditorGUI.LabelField(RubytalkTextLabelRect, "���r�e�L�X�g");

                    var RubytalkTextRect = new Rect(RubytalkTextLabelRect)
                    {
                        // TextArea�Ȃ̂�3�s���m��
                        y = RubytalkTextLabelRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 3)
                    };
                    var RubytalkTextProperty = property.FindPropertyRelative("RubytalkText");
                    RubytalkTextProperty.stringValue = EditorGUI.TextArea(RubytalkTextRect, RubytalkTextProperty.stringValue);

                    var Shakeflag = new Rect(RubytalkTextRect)
                    {
                        y = RubytalkTextLabelRect.y + EditorGUIUtility.singleLineHeight * 4 + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 1)
                    };
                    var ShakeflagProperty = property.FindPropertyRelative("Shakeflag");
                    ShakeflagProperty.boolValue = EditorGUI.Toggle(Shakeflag,"�c�h��",ShakeflagProperty.boolValue);

                    break;


                case EventActionType.Choices:

                    var Choices1NameRect = new Rect(actionTypeRect)
                    {
                        y = actionTypeRect.y + EditorGUIUtility.singleLineHeight + 2f
                    };
                    var Choices1NameProperty = property.FindPropertyRelative("Choices1Name");
                    Choices1NameProperty.stringValue = EditorGUI.TextField(Choices1NameRect, "�I����1", Choices1NameProperty.stringValue);

                    var Choices1Rect = new Rect(Choices1NameRect)
                    {
                        // TextArea�Ȃ̂�3�s���m��
                        y = Choices1NameRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 3)
                    };
                    var Choices1Property = property.FindPropertyRelative("Choices1");
                    Choices1Property.stringValue = EditorGUI.TextArea(Choices1Rect, Choices1Property.stringValue);

                    var Choices2NameRect = new Rect(Choices1Rect)
                    {
                        y = Choices1Rect.y + EditorGUIUtility.singleLineHeight * 3 + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 1)
                    };
                    var Choices2NameProperty = property.FindPropertyRelative("Choices2Name");
                    Choices2NameProperty.stringValue = EditorGUI.TextField(Choices2NameRect, "�I����2", Choices2NameProperty.stringValue);

                    var Choices2Rect = new Rect(Choices2NameRect)
                    {
                        // TextArea�Ȃ̂�3�s���m��
                        y = Choices2NameRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 3)
                    };
                    var Choices2Property = property.FindPropertyRelative("Choices2");
                    Choices2Property.stringValue = EditorGUI.TextArea(Choices2Rect, Choices2Property.stringValue);

                    var Choices3NameRect = new Rect(Choices2Rect)
                    {
                        y = Choices2Rect.y + EditorGUIUtility.singleLineHeight * 3 + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 1)
                    };
                    var Choices3NameProperty = property.FindPropertyRelative("Choices3Name");
                    Choices3NameProperty.stringValue = EditorGUI.TextField(Choices3NameRect, "�I����3", Choices3NameProperty.stringValue);

                    var Choices3Rect = new Rect(Choices3NameRect)
                    {
                        // TextArea�Ȃ̂�3�s���m��
                        y = Choices3NameRect.y + EditorGUIUtility.singleLineHeight + 2f,
                        height = (EditorGUIUtility.singleLineHeight * 3)
                    };
                    var Choices3Property = property.FindPropertyRelative("Choices3");
                    Choices3Property.stringValue = EditorGUI.TextArea(Choices3Rect, Choices3Property.stringValue);

                    break;
            }
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = EditorGUIUtility.singleLineHeight;

        var actionTypeProperty = property.FindPropertyRelative("actionType");
        switch ((EventActionType)actionTypeProperty.enumValueIndex)
        {
            case EventActionType.Talk:
                height = 260f;
                break;
            case EventActionType.Choices:
                height = 260f;
                break;
        }

        return height;
    }
}