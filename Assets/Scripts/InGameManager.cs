using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
	public BallGenerator ballGenerator;
	public GameObject StartLine;
	public GameObject EndPanel;
	public GameObject InGamePanel;
	public TextMeshProUGUI ResultText;
	private int currentPage = 1;
	private int maxPage = 1;
	public List<GameObject> list = new List<GameObject>();
	private int goalCount = 0;

	public void DestroyStartLine()
	{
		StartLine.SetActive(false);
		maxPage = ballGenerator.nameList.Length / 20 + 1;
		PanelChange2();
	}
	public void PanelChange2()
	{
		ballGenerator.StartPanel.SetActive(false);
		InGamePanel.SetActive(true);
	}
	public void ShowResult(int page)
	{
		ResultText.pageToDisplay = page;
	}
	public void AddPageButton(int n)
	{
		currentPage = (currentPage + n) % maxPage + 1;
		ShowResult(currentPage);
	}
	public void AddRankList(GameObject obj)
	{
		if (!list.Contains(obj))
		{
			list.Add(obj);
			goalCount++;
			if (goalCount == ballGenerator.nameList.Length)
				GameEnd();
		}

	}
	public void GameEnd()
	{
		EndPanel.SetActive(true);
		string text = "";

		for (int i = 0; i < list.Count; i++)
		{
			text += (i + 1) + "À§ : " + list[i].name + "\n";
		}

		ResultText.text = text;
	}


}
