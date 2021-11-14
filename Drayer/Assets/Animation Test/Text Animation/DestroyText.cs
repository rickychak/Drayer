using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText :MonoBehaviour
{
    // Start is called before the first frame update
    public void destroyingText(){
	GameObject parent = gameObject.transform.parent.gameObject;
	Destroy(parent);
    }	
}
