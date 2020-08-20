using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class verticesAsBilboards : MonoBehaviour {

    public GameObject target;

    public GameObject cameraMain;

    public Vector2 brushThresh = new Vector2(0, 10f);

    int[] triangles;
    MeshFilter mf;
    Vector3[] vertices;
    Color[] vertColors;

    int[] vertLabel;



    bool[] selectedVerts;


    bool[] isChecked;

    bool addRemove = true;

    int selectLabel = 1;

    float brushSize = 0f;

    Texture2D tex;

    


	// Use this for initialization
	void Start () {

        GameObject bilboardHolder = GameObject.Find("BilboardHolder");

        mf = target.GetComponent<MeshFilter>();

        triangles = mf.mesh.triangles;
        vertices = mf.mesh.vertices;
        vertColors = new Color[vertices.Length];

        vertLabel = new int[vertices.Length];

        selectedVerts = new bool[vertices.Length];

        isChecked = new bool[vertices.Length];


        //tex = new Texture2D((int)(imageDim[0] * imageScale), (int)(imageDim[1] * imageScale), TextureFormat.RGB24, false);


        for (int i = 0; i < vertices.Length; i++)
        {
            vertColors[i] = new Color(1f, 1f, 1f);

            vertLabel[i] = 0;

            selectedVerts[i] = false;

            

        }

	}


    Color getLabelColor(int label)
    {
        Color outputColor = Color.white;
        switch (label)
        {
            case 0:
                outputColor = Color.white;
                break;
            case 1:
                outputColor = Color.red;
                break;
            case 2:
                outputColor = Color.green;
                break;
            case 3:
                outputColor = Color.blue;
                break;
            default:
                outputColor = Color.white;
                break;
        }

        return outputColor;
    }
	
	// Update is called once per frame


    void Update()
    {
        Ray test1 = cameraMain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(test1.origin, test1.direction * 10, Color.red);
        if (Input.GetMouseButton(0))
        {
            //Ray ray = cameraMain.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;




            Vector3 currMouse = Input.mousePosition;

            for (float i = currMouse.x - brushSize; i <= currMouse.x + brushSize; i++)
            {
                for (float j = currMouse.y - brushSize; j <= currMouse.y + brushSize; j++)
                {

                    Ray ray = cameraMain.GetComponent<Camera>().ScreenPointToRay(new Vector3(i,j,0f));
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {


                        for (int m = 0; m < 3; m++)
                        {




                            var test = triangles[hit.triangleIndex * 3 + m];

                            if (addRemove)
                            {

                                vertColors[test] = getLabelColor(selectLabel);

                                vertLabel[test] = selectLabel;
                            }
                            else
                            {
                                vertColors[test] = Color.white;
                            }



                        }



                    }

                }
            }
            

            //if (Physics.Raycast(ray, out hit))
            //{

            //    int numCheck = 0;
            //    if (selectFaces)
            //    {
            //        numCheck = 3;
            //    }
            //    else
            //    {
            //        numCheck = 1;
            //    }

            //    for (int m = 0; m < numCheck; m++)
            //    {

                    


            //        var test = triangles[hit.triangleIndex * 3 + m];

            //        if (addRemove)
            //        {

            //            vertColors[test] = getLabelColor(selectLabel);

            //            vertLabel[test] = selectLabel;
            //        }
            //        else
            //        {
            //            vertColors[test] = Color.white;
            //        }
                    


            //    }

               

            //}


        }

        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {


            brushSize = Mathf.Clamp(brushSize - 0.5f, brushThresh[0], brushThresh[1]);

            Debug.Log(brushSize);
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {


            brushSize = Mathf.Clamp(brushSize + 0.5f, brushThresh[0], brushThresh[1]);
            Debug.Log(brushSize);
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            addRemove = !addRemove;
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectLabel = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectLabel = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectLabel = 3;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            
            StreamWriter streamWriter = new StreamWriter("Assets\\labeledPointCloud.txt");
            string output = "";

            for (int i = 0; i < vertLabel.Length; i++)
            {
                output = vertLabel[i].ToString();

                streamWriter.WriteLine(output);

            }

            streamWriter.Close();

            Debug.Log("SAVED");
        }



        //if (Input.GetMouseButtonUp(0))
        //{
        //    isChecked = new bool[vertices.Length];
        //}
        mf.mesh.colors = vertColors;



       


    }


}
