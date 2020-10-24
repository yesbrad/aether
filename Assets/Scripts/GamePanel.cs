using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
	public Slider heatSlider;

	public void SetHeat (float amt)
	{
		heatSlider.value = amt;
	}
}
