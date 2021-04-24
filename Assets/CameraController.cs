using System.Linq;

using UnityEngine;

/// <summary>
/// Class responsible for camera following the Player. 
/// </summary>
public class CameraController : MonoBehaviour
{
	/// <summary>
	/// Time (in seconds) in which camera will move between two points declared in Vector2.SmoothDamp.
	/// Changeable from inspector level.
	/// For more info see: https://docs.unity3d.com/ScriptReference/Vector2.SmoothDamp.html
	/// </summary>
	[SerializeField]
	private float distanceTime = 0.1f;

	/// <summary>
	/// Default distance between the camera and the player. Changeable from inspector level.
	/// </summary>
	[SerializeField]
	private Vector3 defaultDistanceFromTarget = new Vector3(0f, 2.8f, -4.3f);

	/// <summary>
	/// Initial velocity. This value is modified every frame, according to the distance the
	/// camera has to travel and the time defined by distanceTime.
	/// </summary>
	private Vector2 velocityVector2D = Vector2.one;

	/// <summary>
	/// Transform of target followed by Camera during the game. In this case Player is the target.
	/// </summary>
	private Transform target;

	/// <summary>
	/// Camera transform field. 
	/// </summary>
	private Transform cameraTransform;

	/// <summary>
	/// Gets Camera's transform to cameraTransform variable.
	/// Assigns Player's transform as Camera's target to follow.
	/// </summary>
	private void Awake()
	{
		cameraTransform = transform;
		var targets = FindObjectsOfType<PlayerMovement>();
		if (targets == null || targets.Length == 0) 
			Debug.LogError("There's no PlayerMovement objects on the scene.");
		else
		{
			if (targets.Length > 1) 
				Debug.LogError("There's more than one PlayerMovement on the scene.");
			target = targets.FirstOrDefault()?.gameObject.transform;
		}
	}

	/// <summary>
	/// LateUpdate() is called after all Update functions have been called.
	/// Camera uses MixedFollow() method to follow Player after he updates his position.
	/// </summary>
	private void LateUpdate()
	{
		MixedFollow();
	}

	/// <summary>
	/// Camera gets target's position and counts the distance 
	/// defined in defaultDistanceFromTarget Vector3. Going along with it, following the Player is
	/// divided into two parts: moving along (x,y) axis, using Vector2.SmoothDamp and moving along
	/// z-axes, simply setting the distance between Camera and Player (defined before in
	/// "defaultDistanceFromTarget").
	/// Second part is Camera moves along z-axis simply subtracting default distance, defined before
	/// in "defaultDistanceFromTarget" Vector3. 
	/// </summary>
	private void MixedFollow()
	{
		//Vector2 toPosXY represents (x,y) position that Camera is trying
		// to reach. This Vector2 is created by getting Player's (x,y) position and
		// adding default (x,y) distance to use it later.
		var targetPosition = target.position;
		var toPosXY = new Vector2(
			targetPosition.x + defaultDistanceFromTarget.x,
			targetPosition.y + defaultDistanceFromTarget.y);

		//Vector2 "curPos" is a vector that represents desired(x, y) Camera position,
		// counted by Vector2.SmoothDamp, that takes present Camera (x,y) position as current position and
		// "toPosXY" as goal position. This method refers to "velocityVector2D" as a field to manipulate speed.
		// distanceTime, set before, is time (in seconds) in which Camera will move between it's 
		// current and desired position. Referring to the documentation, "Mathf.Infinity" is maximum
		// allowed Camera's speed and "Time.deltaTime" is the time since the last call to this function.
		// This is default value for Vector2.SmoothDamp.
		var cameraPosition = cameraTransform.position;
		var curPos = Vector2.SmoothDamp(
			new Vector2(cameraPosition.x, cameraPosition.y),
			toPosXY,
			ref velocityVector2D,
			distanceTime,
			Mathf.Infinity,
			Time.deltaTime);

		// Summarizing, on the x and y axes the desired position is set using values calculated
		// by Vector2.SmoothDamp method and on the z-axis the desired position is set using subtraction.
		// At the end, desired position is assigned to cameraTransform field.
		cameraPosition = new Vector3(
			curPos.x,
			curPos.y,
			targetPosition.z + defaultDistanceFromTarget.z);
		cameraTransform.position = cameraPosition;
	}
}
