using System;
using UnityEngine;

public static class GameEvents
{
	public static event Action OnGameOver;
	public static void GameOver()
	{
		OnGameOver?.Invoke();
	}
}
