using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Cooldown : MonoBehaviour, IPointerDownHandler {
	protected const bool DEBUG = false;
	public const bool AUTOPLAY = false;

	public Slider slider;
	public Button button;
	public float cooldown = 5f;

	protected float clickTime;
	protected float cooldownComplete;

	protected bool MousedOn;
	protected bool Moved;
	protected Vector3 MousePosition;

	public void OnClick() {
		clickTime = Time.time;
		cooldownComplete = clickTime + cooldown;
	}

	protected float Value {
		get {
			return (cooldownComplete - Time.time) / cooldown;
		}
	}

	public void Update() {
		slider.normalizedValue = Value;
		slider.fillRect.gameObject.SetActive(Value > 0);
		button.enabled = Value <= 0 || DEBUG;

		if (Value <= 0 && AUTOPLAY) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
		}

		Moved = (MousePosition != Input.mousePosition);
		MousePosition = Input.mousePosition;
	}

	// This is fucking stupid.  God damnit unity event system.
	public void LateUpdate() {
		MousedOn &= Input.GetMouseButton(0);
		if (MousedOn && Moved) {
			ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerClickHandler);
			MousedOn = false;
		}
	}

	public void OnPointerDown(PointerEventData eventData) {
		MousedOn = true;
	}
}