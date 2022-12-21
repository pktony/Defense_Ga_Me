using UnityEngine;

public class UICam : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private Vector3 camOffset;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        transform.rotation = Camera.main.transform.rotation;
    }

    private void LateUpdate()
    {
        if (player.SelectedCharacter != null)
        {
            FollowTarget(player.SelectedCharacter);
        }
    }

    private void FollowTarget(ISelectable target)
    {
        transform.position = target.currentPos + camOffset;
    }
}
