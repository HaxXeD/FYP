using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField] Transform Gun;
    public float intensity;
    public float smooth;
    // public bool isMine;

    private Quaternion origin_rotation;

    private void Start()
    {
        origin_rotation = Gun.localRotation;
    }

    #region Private Methods

    public void UpdateSway (Vector2 input)
    {
        //controls
        float t_x_mouse = input.x;
        float t_y_mouse = input.y;

        //calculate target rotation
        Quaternion t_x_adj = Quaternion.AngleAxis(-intensity * t_x_mouse, Vector3.up);
        Quaternion t_y_adj = Quaternion.AngleAxis(intensity * t_y_mouse, Vector3.right);
        Quaternion target_rotation = origin_rotation * t_x_adj * t_y_adj;

        //rotate towards target rotation
        Gun.localRotation = Quaternion.Lerp(Gun.localRotation, target_rotation, Time.deltaTime * smooth);
    }

    #endregion
}