using UnityEngine;
using UnityEditor;

public class StarAnimator : MonoBehaviour
{
    public int starType;
    [HideInInspector]
    public bool randomSprite;
    public GameObject[] sprites;

    void Start()
    {
        if(GetComponent<Animator>() != null)
            GetComponent<Animator>().SetInteger(0, starType);

        if (starType == 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length - 1)].GetComponent<SpriteRenderer>().sprite;
            GetComponent<Animator>().enabled = false;
            Invoke("EnableAnim", Random.Range(0.0f, 0.25f));
        }
    }

    void EnableAnim() //Adds random delay to the start of Fade animation
    {
        GetComponent<Animator>().enabled = true;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

#if UNITY_EDITOR
//The Custom Editor
[CustomEditor(typeof(StarAnimator))]
[CanEditMultipleObjects]
public class StarAnimatorEditor : Editor
{
    private StarAnimator myTarget;
    private SerializedObject soTarget;

    private SerializedProperty starType;
    private SerializedProperty randomSprite;
    private SerializedProperty sprites;

    private void OnEnable()
    {
        myTarget = (StarAnimator)target;
        soTarget = new SerializedObject(target);

        starType = soTarget.FindProperty("starType");
        randomSprite = soTarget.FindProperty("randomSprite");
        //sprites = soTarget.FindProperty("sprites");
    }

    public override void OnInspectorGUI()
    {
        //Shows the base editor
        base.OnInspectorGUI();

        soTarget.Update();
        EditorGUI.BeginChangeCheck();

#region Render Properties
        Undo.RecordObject(target, "Changes made");

        if (EditorGUI.EndChangeCheck())
        {
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }
        EditorGUI.BeginChangeCheck();

        //Conditions for showing variables
       if (myTarget.starType == 0)
        {
            EditorGUILayout.PropertyField(randomSprite);

        }
        /*if (randomSprite.boolValue)
            EditorGUILayout.PropertyField(sprites);*/

        if (EditorGUI.EndChangeCheck())
            soTarget.ApplyModifiedProperties();
#endregion
    }
}
#endif