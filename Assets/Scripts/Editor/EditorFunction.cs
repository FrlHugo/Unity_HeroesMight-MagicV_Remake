using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorFunction : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EditorFunction>("Edit Mode Functions");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Run Function"))
        {
            FunctionToRun();
        }
    }

    private void FunctionToRun()
    {


        Debug.Log("The function Start.");
        var matGrey = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Grey2");
        var matBlue = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Blue2");
        var matOrange = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Orange");
        var matYellow = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Yellow");
        var matGreen = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Green1");
        var matBlack = Resources.Load<Material>("Thirdparty/Ciathyza/Gridbox_Prototype_Materials/Materials/Standard/Prototype_512x512_Grey4");

        Material[] tabMat = new Material[6];
        tabMat[0] = matGrey;
        tabMat[1] = matGreen;
        tabMat[2] = matBlue;
        tabMat[3] = matYellow;
        tabMat[4] = matOrange;
        tabMat[5] = matBlack;

        Material mat = tabMat[0];

        for (int i = 0; i < 24; i++)
        {
            if( i < 6)
            {
                mat = tabMat[i];

            }
           
            else if( i < 12)
            {
               mat = tabMat[i-6];
            }
            else if (i < 18)
            {
               mat = tabMat[i-12];
            }
            else if(i < 24)
            {
               mat = tabMat[i-18];
            }

            for(int j = 0; j< 24; j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(i, 0, j);
                cube.GetComponent<MeshRenderer>().material = mat;
            }
        }




      



   



        Debug.Log("The function Ended.");
    }
}
