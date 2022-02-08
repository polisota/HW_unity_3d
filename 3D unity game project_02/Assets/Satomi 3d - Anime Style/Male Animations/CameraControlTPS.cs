using UnityEngine;
using System.Collections;

public class CameraControlTPS : MonoBehaviour
{

	public enum InversionX { Disabled = 0, Enabled = 1 };
	public enum InversionY { Disabled = 0, Enabled = 1 };
	public enum Smooth { Disabled = 0, Enabled = 1 };

	[Header("General")]
	public float sensitivity = 2; // ���������������� �����
	public float distance = 5; // ���������� ����� ������� � �������
	public float height = 2.3f; // ������

	[Header("Over The Shoulder")]
	public float offsetPosition; // �������� ������ ������ ��� �����, 0 = �����

	[Header("Clamp Angle")]
	public float minY = 15f; // ����������� ����� ��� �������
	public float maxY = 15f;

	[Header("Invert")] // �������� ����
	public InversionX inversionX = InversionX.Disabled;
	public InversionY inversionY = InversionY.Disabled;

	[Header("Smooth Movement")]
	public Smooth smooth = Smooth.Enabled;
	public float speed = 8; // �������� �����������

	private float rotationY;
	private int inversY, inversX;
	private Transform player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		gameObject.tag = "MainCamera";
	}

	// ���������, ���� ���� �� ���� ����, �� ������ �� ������, �����-���� ����������� (���������)
	Vector3 PositionCorrection(Vector3 target, Vector3 position)
	{
		RaycastHit hit;
		Debug.DrawLine(target, position, Color.blue);
		if (Physics.Linecast(target, position, out hit))
		{
			float tempDistance = Vector3.Distance(target, hit.point);
			Vector3 pos = target - (transform.rotation * Vector3.forward * tempDistance);
			position = new Vector3(pos.x, position.y, pos.z); // ����� ������� � ����� ��������
		}
		return position;
	}

	void LateUpdate()
	{
		if (player)
		{
			if (inversionX == InversionX.Disabled) inversX = 1; else inversX = -1;
			if (inversionY == InversionY.Disabled) inversY = -1; else inversY = 1;

			// �������� ������ ������ ������
			transform.RotateAround(player.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity * inversX);

			// ���������� ����� �� ��������� ��������� �� ������
			Vector3 position = player.position - (transform.rotation * Vector3.forward * distance);
			position = position + (transform.rotation * Vector3.right * offsetPosition); // ����� �� �����������
			position = new Vector3(position.x, player.position.y + height, position.z); // ������������� ������
			position = PositionCorrection(player.position, position); // ������� ������� �������, ������������ ������

			// ������� ������ �� ��� �
			rotationY += Input.GetAxis("Mouse Y") * sensitivity;
			rotationY = Mathf.Clamp(rotationY, -Mathf.Abs(minY), Mathf.Abs(maxY));
			transform.localEulerAngles = new Vector3(rotationY * inversY, transform.localEulerAngles.y, 0);

			if (smooth == Smooth.Disabled) transform.position = position;
			else transform.position = Vector3.Lerp(transform.position, position, speed * Time.deltaTime);
		}
	}
}