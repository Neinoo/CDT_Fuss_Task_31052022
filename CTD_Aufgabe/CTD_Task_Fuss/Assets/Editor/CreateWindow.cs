using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


// welcome to my attempt to solve the task given by CTD, thank you very much for the chance! The provided document and demonstration video were very usefull to understand the task and work on this little project. 
// Since this was the first time working with an editor window and more behind the scene stuff, I could witness the depths of unity.
// I learned a lot and tried my best but ultimately was not able to finish. I scratched the surface a bit and slowly got the hang of it but would need more time to provide a satisfying result


public class MyCustomEditor : EditorWindow
{

    //private SerializedObject serializedObject;
    //private SerializedProperty serializedProperty;

    //protected CTDGrabbable[] prefabs;

    // adding prefabs to a list or array from a folder and instantiating them https://answers.unity.com/questions/711778/adding-prefabs-to-a-list-or-an-array-from-a-folder.html 
    // defining the array for our prefabs
    public static GameObject[] prefabs;
    // tracking number of objects spawned
    public static int numSpawned = 0;

    // defining our list
    public static List<GameObject> prefabList = new List<GameObject>();

    // dummy gameobject
    GameObject objectToSpawn;

    // find object by name variable
    private string observedName = "";

    // variable to store positions of objects
    private Vector3 location = Vector3.zero;

    // creating a new menu item under tools, called CTD .... 
    [MenuItem("Tools/CTD Hand Poser editor")]



    // creating our window
    public static void CreateEditorWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<MyCustomEditor>();
        wnd.titleContent = new GUIContent("CTD Hand Poser editor");
    }


    // since the OnGUI does not have a split view function like the CreateGUI i used the split view from https://github.com/miguel12345/EditorGUISplitView 
    // I wasted too much time to find out how to make it work with the CreateGUI methods because all tutorials I found used it 
    // I also saw the option to use the unity feature UI toolkit but was not able to learn about that so quickly
    EditorGUISplitView horizontalSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Horizontal);
    EditorGUISplitView verticalSplitView = new EditorGUISplitView(EditorGUISplitView.Direction.Vertical);


    void Start()
    {
        createObjectList();
    }

    // creating a list of all prefabs in the prefab folder within the resources, I wanted to save them as Gameobjects with their components into each slot of the array
    void createObjectList()
    {
        Object[] subListOBjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        foreach (GameObject subListObject in subListOBjects)
        {
            GameObject list = (GameObject)subListObject;
            prefabList.Add(list);
            Debug.Log("Object List loaded");
        }
    }


    public void OnGUI()
    {
        // adding a little space before label
        EditorGUILayout.Space();
        // label at the top to tell the user what we want him to do
        GUILayout.Label("Please select an item you want to edit from the list", EditorStyles.boldLabel);

        // opening methods, creating the split view
        horizontalSplitView.BeginSplitView();
        DrawView1(); // draw view1 for the left side
        horizontalSplitView.Split();
        DrawView2(); // draw view2 for the right side
        horizontalSplitView.EndSplitView();

        // object to spawn
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;


        
        // I could not figure out how to properly use the SerializedObjects to create a list in the left pannel and draw the values of the selected items on the right pannel
        //serializedObject = new SerializedObject(newPrefab);
        //serializedProperty = serializedObject.GetIterator();
        //serializedProperty.NextVisible(true);
        //DrawProperties(serializedProperty);



        //button to close the window
        if (GUILayout.Button("close window"))
        {
            Close();
            Debug.Log("closing window");
        }

        // left side of the window
        void DrawView1()
        {
            EditorGUILayout.LabelField("List with prefabs");

            findGameObjectsInScene();

            // Button to load the prefab list
            // the idea was to be able to reload the list in case new objects would be added and list them anew 
            if (GUILayout.Button("Reload Prefab List"))
            {
                Debug.Log("Following Prefabs were found" + prefabList);
            }

            // instantiate a new prefab 
            if (GUILayout.Button("Spaw a Prefab"))
            {
                if (objectToSpawn == null)
                {
                    Debug.LogError("Please assign an object to be spawned");
                    return;
                }
                GameObject newObject = Instantiate(objectToSpawn);
                Debug.Log("Spawned the Object");

            }


            // find object by name and adjust its position with a vector 3 field
            observedName = EditorGUILayout.TextField("Name", observedName);
            GameObject foundObject = GameObject.Find(observedName);
            if (foundObject)
            {
                foundObject.transform.position = EditorGUILayout.Vector3Field("Location", foundObject.transform.position);
                
                if (GUILayout.Button("Save location"))
                {
                    location = foundObject.transform.position;
                    Debug.Log("Location saved");
                }
            }
            else
            {
                EditorGUILayout.HelpBox("Please enter the name of the object you want to find", MessageType.Warning);
            }
            

         }

        // right side of the window split horizontally
        void DrawView2()
        {
            EditorGUILayout.LabelField("Property window");
            GUILayout.Button("Left Hand");
            GUILayout.Button("Right Hand");
        }


        void findGameObjectsInScene()
        {
            //Finding all objects in the scene with the CTD tag
            prefabs = GameObject.FindGameObjectsWithTag("CTD");

            for (int i = 0; i < prefabs.Length; i++)
            {
                Debug.Log("Prefab Number " + i + " is named " + prefabs[i].name);
                createObjectList();
            }
        }

        
        
    }


}