using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;


public class Raycasting : MonoBehaviour {

    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.004f;
    private float laserMaxLength = 1000f;

    [SteamVR_DefaultAction("squeeze")]
    public SteamVR_Action_Single trigger;
    /*
    [SerializeField]
    private int number;
    */
    private SteamVR_Input_Sources rightHand;
    private float rightHand_Activated;

    public float thrust = 2.0f;
    public float heavy = 2;

    void Start()
    {
        //On first frame, place the laser in the space
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
        laserLineRenderer.SetWidth(laserWidth, laserWidth);
        rightHand = SteamVR_Input_Sources.RightHand;

    }

    void Update()
    {
        // In following frames we update the laser to follow the hand
        rightHand_Activated = trigger.GetAxis(rightHand);

        if (rightHand_Activated > 0.25) {
            ShootLaserFromTargetPosition(this.transform.position, this.transform.forward, laserMaxLength);
            laserLineRenderer.enabled = true;
        }
        else
        {
            laserLineRenderer.enabled = false;
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        //Make an array and a dummy variable to store the object it hits
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;

        // The end of the ray is either a max length, or an object in its path that it can hit
        Vector3 endPosition = targetPosition + (length * direction);
        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
            Collider hitCollider = raycastHit.collider;
            //Debug.Log(hitCollider);
            if ( hitCollider.gameObject.name == "CubeDrown") {
                hitCollider.transform.Rotate(-0.1f, 0.0f, 0.0f);
                hitCollider.GetComponent<Rigidbody>().AddForce(0, thrust, 0);
                hitCollider.GetComponent<Rigidbody>().SetDensity(heavy);
                hitCollider.GetComponent<Rigidbody>().isKinematic = true;
                heavy = heavy + 2;
                //transform.localEulerAngles = new Vector3( -0.0001f, 0.0f, 0.0f);
                //MeshRenderer newMesh = hitCollider.gameObject.GetComponent<MeshRenderer>();
                //newMesh.material.SetColor("_Color", Color.green);
            }
            if (hitCollider.gameObject.name == "CubeDrown2")
            {
                hitCollider.transform.Rotate(-0.1f, 0.0f, 0.0f);
                hitCollider.GetComponent<Rigidbody>().AddForce(0, thrust, 0);
                hitCollider.GetComponent<Rigidbody>().SetDensity(heavy);
                hitCollider.GetComponent<Rigidbody>().isKinematic = true;
                heavy = heavy + 2;
                //MeshRenderer newMesh = hitCollider.gameObject.GetComponent<MeshRenderer>();
                //newMesh.material.SetColor("_Color", Color.green);
            }

        }

        //Then draw the laser between its hand and its endpoint
        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
