using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    [Header("Tiempo")]
    public float tiempoInicial = 60f; // segundos

    [Header("Comportamiento al terminar")]
    public bool cargarEscenaDerrota = true;
    public string nombreEscenaDerrota = "Derrota";

    private float tiempoRestante;
    private bool contando = true;

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        if (!contando) return;

        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0f)
        {
            TiempoTerminado();
        }
    }

    void TiempoTerminado()
    {
        contando = false;

        if (cargarEscenaDerrota)
        {
            SceneManager.LoadScene(nombreEscenaDerrota);
        }
        else
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }

    // =========================
    // MÉTODOS PÚBLICOS
    // =========================

    // Reinicia el contador desde el tiempo inicial
    public void ReiniciarContador()
    {
        tiempoRestante = tiempoInicial;
        contando = true;
    }

    // Pausa el contador
    public void PausarContador()
    {
        contando = false;
    }

    // Reanuda el contador
    public void ReanudarContador()
    {
        contando = true;
    }

    // Detiene el contador indefinidamente (no vuelve solo)
    public void DetenerContador()
    {
        contando = false;
        tiempoRestante = Mathf.Infinity;
    }

    // (Opcional) obtener el tiempo restante desde otros scripts
    public float ObtenerTiempoRestante()
    {
        return tiempoRestante;
    }
}