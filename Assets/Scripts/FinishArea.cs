using UnityEngine;

public class FinishArea : MonoBehaviour
{
	public InGameManager inGameManager;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		inGameManager.AddRankList(collision.gameObject);
	}



}
