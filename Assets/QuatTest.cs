using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuatTest : MonoBehaviour {
    public GameObject plain1;
    public GameObject plain2;
    public GameObject plain3;

	// Use this for initialization
	void Start () {
        StartCoroutine(rotateCoro());

        Debug.Log(Mathf.Atan(1.0f));
        Debug.Log(Mathf.Atan2(+1, +1));
        Debug.Log(Mathf.Atan2(-1, +1));
        Debug.Log(Mathf.Atan2(-1, -1));
        Debug.Log(Mathf.Atan2(+1, -1));
    }

    // Update is called once per frame
    void Update () {
		
	}

    IEnumerator rotateCoro()
    {
        int count = 0;
        while (true)
        {
            float roll_deg = count * 0.4f;
            float yaw_deg = count * 0.5f;

            float pitch = Mathf.Sin(count * 0.3f / 180 * Mathf.PI) * Mathf.PI / 2;
            float roll = roll_deg * Mathf.PI / 180;
            float yaw = yaw_deg * Mathf.PI / 180;

            float pitch_deg = pitch / Mathf.PI * 180;

            Quaternion q = new Quaternion();
            float t0 = Mathf.Cos(yaw * 0.5f);
            float t1 = Mathf.Sin(yaw * 0.5f);
            float t2 = Mathf.Cos(roll * 0.5f);
            float t3 = Mathf.Sin(roll * 0.5f);
            float t4 = Mathf.Cos(pitch * 0.5f);
            float t5 = Mathf.Sin(pitch * 0.5f);

            q.w = t0 * t2 * t4 + t1 * t3 * t5;
            q.x = t0 * t3 * t4 - t1 * t2 * t5;
            q.y = t0 * t2 * t5 + t1 * t3 * t4;
            q.z = t1 * t2 * t4 - t0 * t3 * t5;

            Vector3 orig = new Vector3(roll_deg, pitch_deg, yaw_deg);
            plain1.transform.eulerAngles = orig;

            plain2.transform.eulerAngles = q.eulerAngles;

            plain3.transform.eulerAngles = quatToEuler(q);

            count++;
            yield return null;
        }
    }

    Vector3 quatToEuler(Quaternion q)
    {
        float ysqr = q.y * q.y;

        // roll (x-axis rotation)
        float t0 = +2.0f * (q.w * q.x + q.y * q.z);
        float t1 = +1.0f - 2.0f * (q.x * q.x + ysqr);
        float roll = Mathf.Atan2(t0, t1);

        // pitch (y-axis rotation)
        float t2 = +2.0f * (q.w * q.y - q.z * q.x);
        t2 = ((t2 > 1.0f) ? 1.0f : t2);
        t2 = ((t2 < -1.0f) ? -1.0f : t2);
        float pitch = Mathf.Asin(t2);

        // yaw (z-axis rotation)
        float t3 = +2.0f * (q.w * q.z + q.x * q.y);
        float t4 = +1.0f - 2.0f * (ysqr + q.z * q.z);
        float yaw = Mathf.Atan2(t3, t4);

        return new Vector3(roll / Mathf.PI * 180, pitch / Mathf.PI * 180, yaw / Mathf.PI * 180);
    }
}
