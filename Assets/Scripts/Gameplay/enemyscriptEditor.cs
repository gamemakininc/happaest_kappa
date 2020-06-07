using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(enemyscript))]
[CanEditMultipleObjects]
public class enemyScriptEditor : Editor
{
    private enemyscript myTarget;
    private SerializedObject soTarget;

    private SerializedProperty health;
    private SerializedProperty deathEffect;
    private SerializedProperty speed;

    private SerializedProperty amplitude;
    private SerializedProperty period;
    private SerializedProperty yChange;

    private SerializedProperty waitTime;
    private SerializedProperty slideTime;
    private SerializedProperty moveRight;

    private SerializedProperty maxRadians;

    private void OnEnable()
    {
        myTarget = (enemyscript)target;
        soTarget = new SerializedObject(target);

        health = soTarget.FindProperty("health");
        deathEffect = soTarget.FindProperty("deathEffect");
        speed = soTarget.FindProperty("speed");
        amplitude = soTarget.FindProperty("amplitude");
        period = soTarget.FindProperty("period");
        yChange = soTarget.FindProperty("yChange");
        waitTime = soTarget.FindProperty("waitTime");
        slideTime = soTarget.FindProperty("slideTime");
        moveRight = soTarget.FindProperty("moveRight");
        maxRadians = soTarget.FindProperty("maxRadians");
    }

    public override void OnInspectorGUI()
    {
        //Uncomment this to restore default editor
        //base.OnInspectorGUI();

        soTarget.Update();
        EditorGUI.BeginChangeCheck();

        #region Render Properties
        EditorGUILayout.PropertyField(health);
        EditorGUILayout.PropertyField(deathEffect);
        EditorGUILayout.PropertyField(speed);
        EditorGUILayout.PropertyField(waitTime);

        Undo.RecordObject(target, "Changes made");

        myTarget.currentTab = GUILayout.Toolbar(myTarget.currentTab, new string[] { "Straight", "Wavy", "Slide", "Kamikaze" });
        switch (myTarget.currentTab)
        {
            case 0:
                myTarget.currentField = "Straight";
                myTarget.currentState = enemyscript.states.straight;
                break;
            case 1:
                myTarget.currentField = "Wavy";
                myTarget.currentState = enemyscript.states.wavy;
                break;
            case 2:
                myTarget.currentField = "Slide";
                myTarget.currentState = enemyscript.states.slide;
                break;
            case 3:
                myTarget.currentField = "Kamikaze";
                myTarget.currentState = enemyscript.states.kamikaze;
                break;
            default:
                break;
        }

        if (EditorGUI.EndChangeCheck()) {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
        EditorGUI.BeginChangeCheck();

        switch (myTarget.currentField)
        {
            case "Straight":
                break;
            case "Wavy":
                EditorGUILayout.PropertyField(amplitude);
                EditorGUILayout.PropertyField(period);
                //EditorGUILayout.PropertyField(yChange);
                break;
            case "Slide":
                EditorGUILayout.PropertyField(slideTime);
                EditorGUILayout.PropertyField(moveRight);
                break;
            case "Kamikaze":
                EditorGUILayout.PropertyField(maxRadians);
                break;
            default:
                break;
        }

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
        }
    }
    #endregion
}
