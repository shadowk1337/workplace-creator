using UnityEngine;

// This script allows you to drag this GameObject using any finger, as long it has a collider
public class SimpleDrag : MonoBehaviour
{
    //public GameObject Black, Green;
   
    // This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)
    public LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;
	
	// This stores the finger that's currently dragging this GameObject
	private Lean.LeanFinger draggingFinger;
    void Start()
    {
        //Black = GameObject.Find("androidblack");
        //Green = GameObject.Find("androidgreen");
      
   
    }

    public virtual void OnEnable()
	{
		// Hook into the OnFingerDown event
		Lean.LeanTouch.OnFingerDown += OnFingerDown;
		
		// Hook into the OnFingerUp event
		Lean.LeanTouch.OnFingerUp += OnFingerUp;
	}
	
	protected virtual void OnDisable()
	{
		// Unhook the OnFingerDown event
		Lean.LeanTouch.OnFingerDown -= OnFingerDown;
		
		// Unhook the OnFingerUp event
		Lean.LeanTouch.OnFingerUp -= OnFingerUp;
	}
	
	protected virtual void LateUpdate()
	{
		// If there is an active finger, move this GameObject based on it
		if (draggingFinger != null)
		{
			Lean.LeanTouch.MoveObject(transform, draggingFinger.DeltaScreenPosition);
			
            //  Debug.Log(draggingFinger.DeltaScreenPosition);
          //  Debug.Log(close.transform.position);
         //   Debug.Log(Planet.transform.position);
           
        }
    }
    void Update()
    {


		/*
        float distance = Vector3.Distance(Black.transform.position, Green.transform.position);

   

        if (distance <2)
        {
            draggingFinger = null;
         //   Green.GetComponent<Collider>().enabled = false;
            Green.transform.position =    Black.transform.position;
           // Green.transform.localScale = new Vector3(2, 2, 2);
           
        }
		*/
    }


        public void OnFingerDown(Lean.LeanFinger finger)
	{
		if (Input.GetMouseButtonDown(0))
		{
			// Raycast information
			var ray = finger.GetRay();
			var hit = default(RaycastHit);

			// Was this finger pressed down on a collider?
			if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
			{
				// Was that collider this one?
				if (hit.collider.gameObject == gameObject)
				{
					// Set the current finger to this one
					draggingFinger = finger;
				}
			}
		}
	}
	
	public void OnFingerUp(Lean.LeanFinger finger)
	{
		// Was the current finger lifted from the screen?
		if (finger == draggingFinger)
		{
			// Unset the current finger
			draggingFinger = null;
			gameObject.transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, Mathf.Round(transform.position.z));
		}
	}
}