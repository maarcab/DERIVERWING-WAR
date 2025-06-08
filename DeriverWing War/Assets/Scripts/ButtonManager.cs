using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public KeyCode interactionKey = KeyCode.E;
    private bool isPlayerNear = false;
    public PlatformMover platformMover;

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(interactionKey))
        {
            ActivateButton();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }

    private void ActivateButton()
    {
        platformMover.StartMoving();
    }
}
