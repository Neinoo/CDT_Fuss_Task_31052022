//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.UIElements;
//// when programming for the editor we have a seperate namespace thats why we add the UnityEditor
//using UnityEditor;


//// to commend blocks Ctrl+K+C,  
//// since we dont want to put this script on a game object, we want unity to recognize it as an editor script, therefor we remove MonoBehaviour and add EditorWindow
//public class CTDCreateWindow : EditorWindow
//{
//    // we create a menu item to call our ShowWindow Method to open it
//    // we create an attribute with []
//    // we want the "CTD Hand Poser editor" to appear under window if we want it in Tools we use that instead
//    float posX, posY, posZ;
//    private GameObject cubeCTD;
//    GameObject objectToSpawn;

//    public GameObject[] listOfPrefabs = new GameObject[3];

//    private string objectFinder = "";
//    private Vector3 location = Vector3.zero;

//    [MenuItem("Tools/CTD Hand Poser editor")]
//    // we create a menu item to call our ShowWindow Method to open it
//    // we create an attribute with []
//    // we want the "CTD Hand Poser editor" to appear under window if we want it in Tools we use that instead

//    public static void ShowWindow()
//    {
//        // if the window isn't already shown on the screen we want to create one, since we want to open our script window we use "EditorWindow"
//        EditorWindow window = GetWindow<CTDCreateWindow>();
//        window.titleContent = new GUIContent("CTD_Grab_Adjustment");
//        // we can also delete EditorWindow. because it is available in the public class
//        // Limit size of the window
//        window.minSize = new Vector2(450, 200);
//        window.maxSize = new Vector2(920, 420);
//    }


//    //void Start ()
//    //{
//    //    listOfPrefabs = GameObject.FindGameObjectsWithTag("CTD");

//    //    for (int i = 0; i< listOfPrefabs.Length; i++)
//    //    {
//    //        Debug.Log("Object number " + i + " is called " + listOfPrefabs[i].name);
//    //    }
//    //}


//    private void OnGUI()
//    {   
//        // adding a little space before label
//        EditorGUILayout.Space();
//        // label at the top to tell the user what we want him to do
//        GUILayout.Label("Please select an item you want to edit from the list", EditorStyles.boldLabel);

//        // Create a two-pane view with the left pane being fixed with
//        var splitView = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);

//        // Add the panel to the visual tree by adding it as a child to the root element
//        rootVisualElement.Add(splitView);

//        // A TwoPaneSplitView always needs exactly two child elements
//        var leftPane = new ListView();
//        splitView.Add(leftPane);
//        var rightPane = new VisualElement();
//        splitView.Add(rightPane);



































//        //// Spawn object using a prefab 
//        //objectToSpawn = EditorGUILayout.ObjectField("Prefab to spawn", objectToSpawn, typeof(GameObject), false) as GameObject;

//        //// adjusting the positions using sliders
//        //posX = EditorGUILayout.Slider("Change Position X", posX, -100, 100);
//        //posY = EditorGUILayout.Slider("Change Position Y", posY, -100, 100);
//        //posZ = EditorGUILayout.Slider("Change Position Z", posZ, -100, 100);

//        //// finding objects by name
//        //objectFinder = EditorGUILayout.TextField("Name of the object", objectFinder);
//        //GameObject foundObject = GameObject.Find(objectFinder);
//        //if (foundObject)
//        //{
//        //    foundObject.transform.position = EditorGUILayout.Vector3Field("Location", foundObject.transform.position);

//        //}
//        //else
//        //{
//        //    EditorGUILayout.HelpBox("Enter the name of an object to find", MessageType.Info);
//        //}



//        //location = EditorGUILayout.Vector3Field("Location", location);

//        //// button to start the method to safe changed values
//        //if (GUILayout.Button("Save Values"))
//        //{
//        //    Debug.Log("Saved");
//        //}


//        // button to close the window
//        //if (GUILayout.Button("Close Window"))
//        //{
//        //    Close();
//        //    Debug.Log("Closing Window");
//        //}


//    }


//}
