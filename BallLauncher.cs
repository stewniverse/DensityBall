using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class BallLauncher : MonoBehaviour
{

    public bool isHolding;
    Rigidbody ball;
    public Transform target;
    public Transform playerposition; 

    public float h;
    public float gravity = -9;
    Vector3 offset = new Vector3(0, .1f, .5f);
    public float distance = .5f;
    public float firingAngle;
    public float firingAngle2;

    //Think about adding difficulty scale

    public LineRenderer _lineRenderer;

    [SerializeField]
    [Range(3, 30)]
    private int _lineSegmentCount = 20;

    private List<Vector3> _linePoints = new List<Vector3>();


    // Start is called before the first frame update
    void Start()
    {
        ball = null;

    }

    // Update is called once per frame
    private void Update()
    {
   
        if (isHolding) {
            BallInHand();
            UpdateTrajectory(CalculateLaunchVelocity(), ball, playerposition.position);
        }

        if (isHolding && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
            ball = null;
        }

    }

    void Launch()
    {
        ball.velocity = CalculateLaunchVelocity();
        Physics.gravity = Vector3.up * gravity;
        ball.useGravity = true;
        isHolding = false;
        destroyBall(ball);

        //print the intial velcity
        //Debug.Log(CalculateLaunchVelocity());
    }

    public Vector3 CalculateLaunchVelocity()
    {
        float displacementY = ball.position.y - target.position.y;
        Vector3 displacementXZ = new Vector3(target.position.x - ball.position.x, 0, target.position.z - ball.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
        Vector3 veloctyXZ = displacementXZ / (Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity));

        return veloctyXZ + velocityY;
    }

    void BallInHand()
    {
        if (ball != null) //then the player has a ball in their hand
        {
            ball.position = Camera.main.transform.position + offset + Camera.main.transform.forward * distance;
            ball.rotation = playerposition.rotation;
            firingAngle = Camera.main.transform.eulerAngles.y;
            firingAngle = Camera.main.transform.eulerAngles.x;
        }
    }

   public void SetBall(Rigidbody b)
    {
        if(!isHolding)
        {
            ball = b;
            ball.GetComponent<Rigidbody>().useGravity = false;
            isHolding = true;
        }
        
    }

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidBody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidBody.mass) * Time.fixedDeltaTime;

        float flightDuration = (2 * velocity.y) / Physics.gravity.y;

        float stepTime = flightDuration / _lineSegmentCount;

        _linePoints.Clear();

        for (int i = 0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 MovementVector = new Vector3(
                 velocity.x * stepTimePassed,
                 velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                 velocity.z * stepTimePassed);
            RaycastHit hit;
            if (Physics.Raycast(startingPoint, -MovementVector, out hit, MovementVector.magnitude))
            {
                break;
            }

            _linePoints.Add(-MovementVector + startingPoint);
        }

        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());
    }

    public void destroyBall(Rigidbody b) => Destroy(b, 7f);
}
