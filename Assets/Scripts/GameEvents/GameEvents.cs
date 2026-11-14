using System;
using UnityEngine;

public static class GameEvents
{
	public static event Action OnPlayerDie;
	public static event Action OnGameOver;
	public static void PlayerDie()
	{
		OnPlayerDie?.Invoke();
	}
	public static void GameOver()
	{
		OnGameOver?.Invoke();
	}
}
