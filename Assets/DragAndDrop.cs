using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{   
	public GameObject target,dragObjTarget,current_obj;
	public 	bool isMouseDragging;
	Vector3 screenPosition,offset;
	Vector3 targetInitialPos;
	public LayerMask mask;

	

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
		
			RaycastHit hitInfo;
			target = ReturnClickedObject(out hitInfo);
			if (target != null)
			{
				isMouseDragging = true;
			
				screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
				offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			
			isMouseDragging = false;
	        
			if(target != null)
			{
				Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
				Vector3 MousePos = Camera.main.ScreenToWorldPoint (currentScreenSpace);
				target.transform.position = targetInitialPos;
				target.layer = 8;
				target = null;
			}
		
		}
		RaycastHit hits;
		if (isMouseDragging)
		{
			if (target  == null)
			{
				return;
			}
			//tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) ;
			target.transform.position = Vector3.MoveTowards(target.transform.position,currentPosition,10);
			
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray.origin, ray.direction * 10, out hits,Mathf.Infinity , mask))
			{
				current_obj = hits.collider.gameObject;
			
				if(target !=  null)
				{
					
					if(	hits.collider.gameObject.name == target.gameObject.name)
					{
						hits.collider.gameObject.GetComponent<Block>().CheckPair(target.gameObject);
						isMouseDragging = false;
					}
					
				
				}
		
			}
		}
	
	
	}
	int found;
	GameObject ReturnClickedObject(out RaycastHit hit)
	{
		GameObject targetObject = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray.origin, ray.direction * 10, out hit,Mathf.Infinity , mask))
		{
			current_obj = hit.collider.gameObject;
			
			if(target !=  null)
			{
				hit.collider.gameObject.GetComponent<Block>().CheckPair(target.gameObject);
				return null;;
			}
			
		
			targetObject = hit.collider.gameObject;
			targetInitialPos = targetObject.transform.position;
			targetObject.layer = 0;
		
            
		   
		}
		return targetObject.gameObject;
	}
    
    

}
