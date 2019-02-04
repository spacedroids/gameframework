using UnityEngine;
using System;
using System.Collections;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T> {
	
	private static T instance;
	private static bool quitting = false;
	
	protected internal static T Instance {
		get {
			if (quitting) {
				return instance;
			}
			
			if (instance == null) {
				Type type = typeof(T);
				instance = GameObject.FindObjectOfType(type) as T;
				
				if (instance == null) {
					instance = new GameObject(type.ToString() + "Instance", type).GetComponent<T>();
				}
			}
			
			return instance;
		}
	}
	
	protected virtual void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	protected virtual void OnApplicationQuit() {
		quitting = true;
		
		if (instance != null) {
			StopAllCoroutines();
			
			if (instance.gameObject != null) {
				Destroy(instance.gameObject);
			}
		}
	}
}