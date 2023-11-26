using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Letter))]
public class LetterInspectorOverride : Editor
{
    LetterDisplay letters;

    public override VisualElement CreateInspectorGUI()
    {
        // Create a new VisualElement to be the root of our inspector UI
        VisualElement myInspector = new VisualElement();

        // Add a simple label
        myInspector.Add(new Label("This is a custom inspector"));

        // Return the finished inspector UI
        return myInspector;
    }
}
