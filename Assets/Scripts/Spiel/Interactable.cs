
using UnityEngine;

public class Interactable : MonoBehaviour
{
    #region private Variables 
    bool isFocued = false;
    bool hasInteracted = false;
    Transform player;
    #endregion


    #region public Variables 
    public float radius = 3f;
    public Transform interactionTransform;
    #endregion


    #region Methods
    
    public virtual void Interact()
    {
        // this method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }
    
    private void Update()
    {
        if (isFocued == true && hasInteracted == false)
        {
            float distance = Vector2.Distance(player.position, interactionTransform.position);
            if (distance <= radius)
            {
                Interact();
                hasInteracted = true;
            }
            else
            {
                OnDeFocused();
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocued = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDeFocused()
    {
        isFocued = false;
        player = null;
        hasInteracted = false;
    }

    #endregion

}
