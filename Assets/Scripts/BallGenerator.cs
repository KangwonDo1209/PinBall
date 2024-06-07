using NUnit.Framework;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BallGenerator : MonoBehaviour
{
	public CameraTracking cameraTracking;
	public GameObject BallPrefab;
	public GameObject InputPanel;
	public GameObject StartPanel;
	public TMP_InputField NameText;
	[HideInInspector]
	public string[] nameList;
	public float Top;
	public float Bottom;
	public float Left;
	public float Right;

	public void BallSetting()
	{
		nameList = CreateNameList();
		CreateBall(nameList);
		PanelChange1();
		cameraTracking.AddBallList();
	}

	public void PanelChange1()
	{
		InputPanel.SetActive(false);
		StartPanel.SetActive(true);
	}

	public void CreateBall(string[] nameList)
	{
		for (int i = 0; i < nameList.Length; i++)
		{
			float randomX = UnityEngine.Random.Range(Left, Right);
			float randomY = UnityEngine.Random.Range(Bottom, Top);
			GameObject obj = Instantiate(BallPrefab, new Vector3(randomX, randomY, 0), Quaternion.identity);
			obj.name = nameList[i];
			TextMeshPro mesh = obj.GetComponentInChildren<TextMeshPro>();
			mesh.text = nameList[i];
			SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
			sprite.color = sprite.color = new Color(Random.value, Random.value, Random.value);
		}

	}
	public string[] CreateNameList()
	{
		string text = NameText.text;
		string[] nameList = text.Split('\n');


		return nameList;
	}

}
