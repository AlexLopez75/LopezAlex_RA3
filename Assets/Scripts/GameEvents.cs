using System;
using UnityEngine;

public static class GameEvents
{
	public static event Action<int> OnPlayerDie;

	public static void PlayerDie(int points)
	{
		OnPlayerDie?.Invoke(points);
	}
}
