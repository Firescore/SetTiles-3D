using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
	public GameObject[] tiles;
	public Color col;
	public GameObject white_img;
	public GameObject green_tiles,parent_tiles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public void CheckONLevelComplete()
	{
		int j  = gameObject.transform.childCount;
		Debug.Log(j);
		if( j == 1)
		{
			parent_tiles.SetActive(true);
			green_tiles.SetActive(true);
			
			//for(int i = 0; i <tiles.Length;i++)
			//{
			//	tiles[i].GetComponent<MeshRenderer>().material.color = col;
			//}
			
			StartCoroutine("Effect");
		}
	}
	
	IEnumerator Effect()
	{
		for(int i =0; i<4;i++)
		{
			GameObject temp_obj = Instantiate(white_img,white_img.transform.position,white_img.transform.rotation);
			
			temp_obj.SetActive(true);
			
			yield return new WaitForSeconds(0.5f);
		}
	}
}
