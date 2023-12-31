using UnityEngine;
public class Movement : MonoBehaviour
{
    private float WalkSpeed = 0f;
    private float MaxWalkSpeed = 2f;
    //private const float DistanceError = 0.05f;
    private Vector2 Walkdirection = Vector2.up;
    private bool WalkSpeedSet = false;
    [SerializeField] Vector2 LastTarget = Vector2.zero;
    //private Vector2 Target;
    public void Walk()
    {
        Walkdirection = Walkdirection.normalized;
        transform.position += (Vector3)(Walkdirection * WalkSpeed * Time.fixedDeltaTime);
    }
    public void WalkTo(Vector2 v2)
    {
        Walkdirection = (v2 - (transform.position).ToV2()).normalized;
        WalkSpeed = MaxWalkSpeed;
        WalkSpeedSet = true;
        //Target = v2;
        LastTarget = v2;
    }
    public void WalkToRandom()
    {
        float x = Random.Range(0f, 1f);
        float y = Random.Range(0f, 1f);
        Vector2 change = new Vector2(x, y);
        Walkdirection = (Walkdirection + change.normalized * Time.fixedDeltaTime).normalized;
        WalkSpeed = MaxWalkSpeed;
        WalkSpeedSet = true;
    }
    private void FixedUpdate()
    {
        Walk();
        //if (transform.DistanceTo(Target) < DistanceError) { WalkSpeed = 0f; }
        if (!WalkSpeedSet)
        {
            WalkSpeed *= 0.5f;
        }
        WalkSpeedSet = false;
    }
}