using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DestroyEffect : MonoBehaviour
{

	public int effectTypeP1 = 0;
	public float effectColorP1 = 0;
	public int effectTypeP2 = 0;
	public float effectColorP2 = 0;

	


	public Texture HUETexture;
	public Material mat;
	public GameObject[] Prefabs;

	public GameObject currentInstance;

	[SerializeField] GameObject HC;
	[SerializeField] GameObject DEC;

	[SerializeField] Slider colorSliderP1;
	[SerializeField] Slider colorSliderP2;

	[SerializeField] GameObject[] P1DEButton;
	[SerializeField] GameObject[] P2DEButton;
	[SerializeField] GameObject cameraObj;

	void Start(){
		resetSlection();
	}

	public void resetSlection(){
		string datastr = "";
        StreamReader reader;
        reader = new StreamReader(Application.dataPath + "/jsonfiles/HomeData.json");
        datastr = reader.ReadToEnd();
        reader.Close();
        HomeDataClass tempJson = new HomeDataClass();
        tempJson = JsonUtility.FromJson<HomeDataClass>(datastr);


		effectColorP1 = tempJson.DEP1Color;
		effectTypeP1 = tempJson.DEP1Type;
		effectColorP2 = tempJson.DEP2Color;
		effectTypeP2 = tempJson.DEP2Type;

		selectEffectP1(effectTypeP1);
		selectEffectP2(effectTypeP2);
		
		P1DEButton[effectTypeP1].GetComponent<RawImage>().color = Hue(effectColorP1 * 6);
		colorSliderP1.value = effectColorP1;

		P2DEButton[effectTypeP2].GetComponent<RawImage>().color = Hue(effectColorP2 * 6);
		colorSliderP2.value = effectColorP2;
	}



	public void showDE(int n)
	{	
		cameraObj.GetComponent<CameraCont>().resetCamera();
		float colorHUE = 0;
		int tempeffectType = 0;
		if (n == 1) { colorHUE = effectColorP1 * 6; tempeffectType = effectTypeP1; }
		if (n == 2) { colorHUE = effectColorP2 * 6; tempeffectType = effectTypeP2; }

		if (tempeffectType != 0)
		{
			currentInstance = Instantiate(Prefabs[tempeffectType], new Vector3(0, 1.153f, 0), new Quaternion()) as GameObject;
			currentInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
			var color = Hue(colorHUE);
			var rend = currentInstance.GetComponentsInChildren<Renderer>();
			foreach (var r in rend)
			{
				var mat = r.material;
				if (mat == null || !mat.HasProperty("_TintColor")) continue;
				var oldColor = mat.GetColor("_TintColor");
				color.a = oldColor.a;
				mat.SetColor("_TintColor", color);
			}
			var light = currentInstance.GetComponentInChildren<Light>();
			if (light != null) light.color = color;
			InvokeRepeating("Reactivate", currentInstance.GetComponent<CFX_DemoReactivator>().TimeDelayToReactivate, currentInstance.GetComponent<CFX_DemoReactivator>().TimeDelayToReactivate);
		}

		HC.SetActive(false);
		DEC.SetActive(true);

		
	}

	public void saveDE(int n) 
	{
		HomeDataClass temp = new HomeDataClass();
		string datastr = "";
		StreamReader reader;
		reader = new StreamReader(Application.dataPath + "/jsonfiles/HomeData" + ".json");
		datastr = reader.ReadToEnd();
		reader.Close();
		temp = JsonUtility.FromJson<HomeDataClass>(datastr);

		if (n == 1) { temp.DEP1Color = effectColorP1; temp.DEP1Type = effectTypeP1; }
		if (n == 2) { temp.DEP2Color = effectColorP2; temp.DEP2Type = effectTypeP2; }

		string jsonstr = LitJson.JsonMapper.ToJson(temp);
		StreamWriter writer = new StreamWriter(Application.dataPath + "/jsonfiles/HomeData" + ".json", false);
		writer.WriteLine(jsonstr);
		writer.Flush(); writer.Close();
		
	}

	Color Hue(float H)
	{
		Color col = new Color(1, 0, 0);
		if (H >= 0 && H < 1) col = new Color(1, 0, H);
		if (H >= 1 && H < 2) col = new Color(2 - H, 0, 1);
		if (H >= 2 && H < 3) col = new Color(0, H - 2, 1);
		if (H >= 3 && H < 4) col = new Color(0, 1, 4 - H);
		if (H >= 4 && H < 5) col = new Color(H - 4, 1, 0);
		if (H >= 5 && H < 6) col = new Color(1, 6 - H, 0);
		return col;
	}


	public void selectEffectP1(int n)
	{
		effectTypeP1 = n;
		cleanP1DEButton(n);
		P1DEButton[n].GetComponent<RawImage>().color = Hue(effectColorP1 * 6);
		P1DEButton[n].GetComponent<RawImage>().CrossFadeAlpha(1f, 0.3f, false);


	}
    void cleanP1DEButton(int n) 
	{
		for (int i = 0; i < 30; i++)
		{
			if (i != n)
			{
				P1DEButton[i].GetComponent<RawImage>().color = new Color (0,0,0,0);
				P1DEButton[i].GetComponent<RawImage>().CrossFadeAlpha(0f,0.3f,false);
			}
		}
	}
	public void selectEffectP2(int n)
	{
		effectTypeP2 = n;
		cleanP2DEButton(n);
		P2DEButton[n].GetComponent<RawImage>().color = Hue(effectColorP2 * 6);
		P2DEButton[n].GetComponent<RawImage>().CrossFadeAlpha(1f, 0.3f, false);


	}
	void cleanP2DEButton(int n)
	{
		for (int i = 0; i < 30; i++)
		{
			if (i != n)
			{
				P2DEButton[i].GetComponent<RawImage>().color = new Color (0,0,0,0);
				P2DEButton[i].GetComponent<RawImage>().CrossFadeAlpha(0f, 0.3f, false);
			}
		}
	}

	public void ChangeSliderColorP1()
	{
		effectColorP1 = colorSliderP1.value;
	}
	public void ChangeSliderColorP2()
	{
		effectColorP2 = colorSliderP2.value;
	}

	public void goHome()
	{
		CancelInvoke();
		HC.SetActive(true);
		DEC.SetActive(false);
		if (currentInstance != null) Destroy(currentInstance);
		selectEffectP1(effectTypeP1);
		selectEffectP2(effectTypeP2);
	}
	
	public void showDEByObj(GameObject GO, int DEtype, float DEcolor) 
	{
		if (DEtype != 0)
		{

			currentInstance = Instantiate(Prefabs[DEtype], new Vector3(0f, 0f, 100000f), new Quaternion()) as GameObject;
			
			if (GO.CompareTag("KingKoma")) { currentInstance.transform.localScale = new Vector3(1f, 1f, 1f); }
			else { currentInstance.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); }

			var color = Hue(DEcolor);
			var rend = currentInstance.GetComponentsInChildren<Renderer>();
			foreach (var r in rend)
			{
				var mat = r.material;
				if (mat == null || !mat.HasProperty("_TintColor")) continue;
				var oldColor = mat.GetColor("_TintColor");
				color.a = oldColor.a;
				mat.SetColor("_TintColor", color);
			}
			var light = currentInstance.GetComponentInChildren<Light>();
			if (light != null) light.color = color;

			currentInstance.GetComponent<CFX_DemoReactivator>().ShowThis(GO);

		}
		else 
		{
			Destroy(GO);
		}
	}


}

public class HomeDataClass 
{
    public float DEP1Color;
    public float DEP2Color;
    public int DEP1Type;
    public int DEP2Type;

}










