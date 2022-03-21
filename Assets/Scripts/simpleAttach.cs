using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
public class simpleAttach : MonoBehaviour
{

    Interactable interactable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame

    private void OnHandHoverBegin(Hand hand)
    {
        hand.ShowGrabHint();

    }
    

    private void OnHandHoverEnd(Hand hand)
    {
        hand.HideGrabHint();
    }
    void HandHoverUpdate(Hand hand)
    {

        Debug.Log("Hover??");

        GrabTypes grabtype = hand.GetGrabStarting();
        bool IsGrabEnding = hand.IsGrabEnding(gameObject);

        if (interactable.attachedToHand == null && grabtype != GrabTypes.None)
        {
            hand.AttachObject(gameObject, grabtype);
            hand.HoverLock(interactable);
        } 
        else if (IsGrabEnding)
        {
            hand.DetachObject(gameObject);
            hand.HoverUnlock(interactable);

        }
    }
}
