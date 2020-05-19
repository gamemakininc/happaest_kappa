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
    private SerializedProperty shift;
    private SerializedProperty yChange;

    private SerializedProperty waitTime;
    private SerializedProperty slideTime;
    private SerializedProperty moveRight;

    private void OnEnable()
    {
        myTarget = (enemyscript)target;
        soTarget = new SerializedObject(target);

        health = soTarget.FindProperty("health");
        deathEffect = soTarget.FindProperty("deathEffect");
        speed = soTarget.FindProperty("speed");
        amplitude = soTarget.FindProperty("amplitude");
        period = soTarget.FindProperty("period");
        shift = soTarget.FindProperty("shift");
        yChange = soTarget.FindProperty("yChange");
        waitTime = soTarget.FindProperty("waitTime");
        slideTime = soTarget.FindProperty("slideTime");
        moveRight = soTarget.FindProperty("moveRight");
    }

    public override void OnInspectorGUI()
    {
        //Uncomment this to restore default editor
        //base.OnInspectorGUI();
        
        EditorGUILayout.PropertyField(health);
        EditorGUILayout.PropertyField(deathEffect);
        EditorGUILayout.PropertyField(speed);

        myTarget.currentTab = GUILayout.Toolbar(myTarget.currentTab, new string[] { "Straight", "Wavy", "Slide" });
        switch (myTarget.currentTab)
        {
            case 0:
                break;
            case 1:
                EditorGUILayout.PropertyField(amplitude);
                EditorGUILayout.PropertyField(period);
                EditorGUILayout.PropertyField(shift);
                EditorGUILayout.PropertyField(yChange);
                break;
            case 2:
                EditorGUILayout.PropertyField(waitTime);
                EditorGUILayout.PropertyField(slideTime);
                EditorGUILayout.PropertyField(moveRight);
                break;
        }

    }

    /*SerializedProperty enemyScript;
    SerializedProperty amplitude;

    private void OnEnable()
    {
        enemyScript = serializedObject.FindProperty("enemyScript");
        amplitude = serializedObject.FindProperty("amplitude");
    }

    public void OnInSpectorGUI()
    {
        enemyscript enemyscript = target as enemyscript;


        switch (enemyscript.currentState)
        {
            case enemyscript.states.wavy:
                enemyscript.amplitude = EditorGUILayout.FloatField("Amplitude:", enemyscript.amplitude);
                enemyscript.shift = EditorGUILayout.FloatField("Shift:", enemyscript.shift);
                enemyscript.yChange = EditorGUILayout.FloatField("y Change:", enemyscript.yChange);
                break;
            case enemyscript.states.slide:
                enemyscript.waitTime = EditorGUILayout.FloatField("Wait Time:", enemyscript.waitTime);
                enemyscript.slideTime = EditorGUILayout.FloatField("Slide Time:", enemyscript.slideTime);
                enemyscript.moveRight = EditorGUILayout.Toggle("Move Right:", enemyscript.moveRight);
                break;
        }

        serializedObject.Update();
        EditorGUILayout.PropertyField(enemyScript);
        EditorGUILayout.PropertyField(amplitude);
        serializedObject.ApplyModifiedProperties();
    }*/
}
