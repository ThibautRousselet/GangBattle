using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GamePhase
{
	Shop,
	Normal,
	Selection
}

public class Main : MonoBehaviour
{
	public List<Player> players;
	public Neighborhood selectedNH { get; set; }
	public Neighborhood overedNH { get; set; }
	public ClickableElement overedButton { get; set; }

	public GamePhase phase = GamePhase.Normal;

	public Player CurrentPlayer;

	public int ActionsLeft;

	public CameraControl camera;
	public NeighborhoodHandler NHHandler;

	private static Main instance = null;

	[SerializeField] private Text playerText;
	[SerializeField] private Text actionText;
	public Button nextTurnButton;

	public static Main Instance
	{
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<Main>();
			}
			return instance;
		}
	}

	private void Start()
	{
		CurrentPlayer.HQ.OpenShop();
	}

	private void Update()
	{
		playerText.text = "Player " + CurrentPlayer.ID + " turn";
		actionText.text = ActionsLeft + " Actions left";
	}


	public static bool HasInstance { get { return instance != null; } }

	public void SkipTurn()
	{
		if (phase == GamePhase.Normal)
		{
			Neighborhood.UnSelect();
			if (CurrentPlayer.ID == 1)
				CurrentPlayer = players[2];
			else
				CurrentPlayer = players[1];
			CurrentPlayer.HQ.OpenShop();
		}
	}

	public void ConsumeAction()
	{
		ActionsLeft--;
		if (ActionsLeft == 0)
			SkipTurn();
	}
}
