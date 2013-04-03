using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CastFromCamera : MonoBehaviour
{
	public GameObject waveyEffect;
	
	private Transform _mainCamera;
	private Transform _player;
	private WaveFade _waveFade;
	private int _layerMask;
	private int defaultLayer;
	private bool _stopCast = false;
	
	private static Vector3 _setPlayerLoc;
	private static Quaternion _setPlayerRot;
	private static int counter = 0;
	
	// Use this for initialization
	void Awake()
	{
		_mainCamera = transform;
		_player = _mainCamera.parent;
		if (_setPlayerLoc != Vector3.zero)
		{
			_player.position = _setPlayerLoc;
			_player.rotation = _setPlayerRot;
		}
		_layerMask = 1 << LayerMask.NameToLayer("Collect");
		defaultLayer = LayerMask.NameToLayer("Default");
		_waveFade = waveyEffect.GetComponent<WaveFade>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if (_stopCast) return;
		
		RaycastHit hit;
		if (Physics.SphereCast(_mainCamera.position, 0.5f, _mainCamera.forward, out hit,
			5.0f, _layerMask))
		{
			if (hit.transform.gameObject == DontDestroy.Instance.objects[counter])
			{
				++counter;
				_stopCast = true;
				hit.transform.gameObject.layer = defaultLayer;
				StartCoroutine(_waveFade.WaveFadeOut());
				// disable motor?
				_setPlayerLoc = _player.position;
				_setPlayerRot = _player.rotation;
			}
		}
	}
}
