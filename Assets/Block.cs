using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
	
	//	public GameObject pair;
	public Material mat;
    // Start is called before the first frame update
    void Start()
    {
	    mat = gameObject.GetComponent<MeshRenderer>().material;
	    Color col = mat.color;
	    col.a = 0.0f;
	    mat.color = col;
	    gameObject.GetComponent<MeshRenderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void CheckPair(GameObject obj)
	{
		
		if(obj.name == gameObject.name)
		{
			obj.SetActive(false);
			mat = gameObject.GetComponent<MeshRenderer>().material;
			Color col = mat.color;
			col.a = 1f;
			mat.color = col;
			gameObject.GetComponent<MeshRenderer>().material = mat;
			gameObject.name = "DONE";
		}
	}
}
