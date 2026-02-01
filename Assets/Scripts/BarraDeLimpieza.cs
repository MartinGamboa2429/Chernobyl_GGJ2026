using UnityEngine;
using UnityEngine.UI;

public class BarraDeLimpieza : MonoBehaviour
{
	
    public Image barraFill;


   void Start()
   {
	UpdateColor(); 
   }

    void UpdateColor(){

	float valor = barraFill.fillAmount; 

	if ( valor > 0.66f) 
	{
		barraFill.color = Color.red;
	}
	else if (valor > 0.33f)
	{
		barraFill.color = Color.orange;
	}
	else {
		barraFill.color = Color.green;
	}

}

    public void AddClean(){
	
      if(barraFill.fillAmount < 1) 
	{ 
	  barraFill.fillAmount += 0.1f;
	  UpdateColor();   
	}
      
    }

    public void RemoveClean(){
		Debug.Log("BOTON APRETADO");
	if(barraFill.fillAmount > 0) 
        { 
		barraFill.fillAmount -= 0.1f;
		barraFill.fillAmount = Mathf.Clamp01(barraFill.fillAmount);
		UpdateColor();
    }


 }
}
