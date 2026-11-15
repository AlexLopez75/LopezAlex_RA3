using UnityEngine;

public class ShowText : MonoBehaviour
{
    [SerializeField] public GameObject textBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textBox.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textBox.SetActive(false);
    }
}
