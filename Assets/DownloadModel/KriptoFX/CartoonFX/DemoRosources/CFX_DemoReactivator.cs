using UnityEngine;
using System.Collections;
using System;

public class CFX_DemoReactivator : MonoBehaviour {

	public float TimeDelayToReactivate = 3;
	
	void Start () {
		
	}
	public void ShowThis(GameObject GO) 
	{
		StartCoroutine(DelayMethod(0.01f, () =>
		{
			this.transform.position = GO.transform.position;
			this.gameObject.SetActive(false);
			this.gameObject.SetActive(true);
			Destroy(GO);
		}));
		Invoke("subDes", TimeDelayToReactivate);
	}
	void subDes() 
	{
		Destroy(this.gameObject);

	}
	private IEnumerator DelayMethod(float waitTime, Action action)
	{
		yield return new WaitForSeconds(waitTime);
		action();
	}
}
