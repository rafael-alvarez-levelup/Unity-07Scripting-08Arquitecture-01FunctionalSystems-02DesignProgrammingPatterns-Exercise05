using System.Collections;
using UnityEngine;
//using UnityEditor;

public class EnemyActionsTest : MonoBehaviour
{
    private IActionController[] controllers;

    private void Awake()
    {
        controllers = GetComponentsInChildren<IActionController>();
    }

    public void RandomizeActionsRoutine()
    {
        StartCoroutine(RandomizeActions());
    }

    private IEnumerator RandomizeActions()
    {
        foreach (var controller in controllers)
        {
            controller.ResetAction();
        }

        yield return new WaitForSeconds(1f);

        foreach (var controller in controllers)
        {
            ICommand command = controller.GetCurrentCommand();

            yield return new WaitForSeconds(0.25f);
        }
    }
}

//[CustomEditor(typeof(EnemyActionsTest))]
//public class LevelScriptEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        EnemyActionsTest myTarget = (EnemyActionsTest)target;

//        if (GUILayout.Button("RandomizeActions"))
//        {
//            myTarget.RandomizeActionsRoutine();
//        }
//    }
//}