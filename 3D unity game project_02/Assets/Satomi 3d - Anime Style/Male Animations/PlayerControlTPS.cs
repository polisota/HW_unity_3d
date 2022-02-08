using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]

public class PlayerControlTPS : MonoBehaviour
{

	public float speed = 1.5f; // ����. ��������
	public float acceleration = 100f; // ���������

	public Transform rotate; // ������ �������� (���������)

	public KeyCode jumpButton = KeyCode.Space; // ������� ��� ������
	public float jumpForce = 10; // ���� ������
	public float jumpDistance = 1.2f; // ���������� �� ������ �������, �� �����������

	private Vector3 direction;
	private float h, v;
	private int layerMask;
	private Rigidbody body;
	private float rotationY;
	private float rotationX;

	void Awake()
	{
		body = GetComponent<Rigidbody>();
		body.freezeRotation = true;
		gameObject.tag = "Player";

		// ������� ������ ���� �������� ��������� ����, ��� ������ ������
		layerMask = 1 << gameObject.layer | 1 << 2;
		layerMask = ~layerMask;
	}

	void FixedUpdate()
	{
		body.AddForce(direction.normalized * acceleration * body.mass * speed);

		// ����������� ��������, ����� ������ ����� ��������� ����������
		if (Mathf.Abs(body.velocity.x) > speed)
		{
			body.velocity = new Vector3(Mathf.Sign(body.velocity.x) * speed, body.velocity.y, body.velocity.z);
		}
		if (Mathf.Abs(body.velocity.z) > speed)
		{
			body.velocity = new Vector3(body.velocity.x, body.velocity.y, Mathf.Sign(body.velocity.z) * speed);
		}
	}

	bool GetJump() // ���������, ���� �� ��������� ��� ������
	{
		bool result = false;

		RaycastHit hit;
		Ray ray = new Ray(transform.position, Vector3.down);
		if (Physics.Raycast(ray, out hit, jumpDistance, layerMask))
		{
			result = true;
		}

		return result;
	}

	void Update()
	{
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		// ������ ����������� ��������
		direction = new Vector3(h, 0, v);
		direction = Camera.main.transform.TransformDirection(direction);
		direction = new Vector3(direction.x, 0, direction.z);

		if (Mathf.Abs(v) > 0 || Mathf.Abs(h) > 0) // �������� ���� �� ������� ��������
		{
			rotate.rotation = Quaternion.Lerp(rotate.rotation, Quaternion.LookRotation(direction), 10 * Time.deltaTime);
		}

		Debug.DrawRay(transform.position, Vector3.down * jumpDistance, Color.red); // ���������, ��� ���������� ��������� jumpDistance

		if (Input.GetKeyDown(jumpButton) && GetJump())
		{
			body.velocity = new Vector2(0, jumpForce);
		}
	}
}