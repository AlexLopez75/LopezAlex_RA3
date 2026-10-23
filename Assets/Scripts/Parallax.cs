using UnityEngine;

public class Parallax : MonoBehaviour
{
	[SerializeField] float parallaxMutliplier = 0.1f;
	private Material parallaxMaterial;
	private float lastPlayerX;
	[SerializeField] private Transform player;

	void Start()
	{
		parallaxMaterial = GetComponent<Renderer>().material;
		lastPlayerX = player.position.x;
	}

	// Update is called once per frame
	void Update()
	{
		float deltax = player.position.x - lastPlayerX;
		parallaxMaterial.mainTextureOffset += new Vector2(deltax * parallaxMutliplier, 0);
		lastPlayerX = player.position.x;
	}
}
