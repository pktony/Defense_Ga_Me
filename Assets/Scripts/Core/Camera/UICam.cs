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
        FollowTarget(player.SelectedCharacter);
    }

    private void FollowTarget(ISelectable target)
    {
        if (target != null)
        {
            transform.position = target.currentPos + camOffset;
        }
    }
}
