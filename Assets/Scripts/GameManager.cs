using UnityEngine;

public class GameManager : MonoBehaviour
{
    // =========================
    // SINGLETON
    // =========================
    public static GameManager Instance { get; private set; }

    [Header("Referencias")]
    public GameTimer gameTimer;

    [Header("Acumulador")]
    [SerializeField] private float valorMaximo = 100f;

    private float valorAcumulado = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // =========================
    // MÉTODO PRINCIPAL
    // =========================
    public void SumarValor(float valor)
    {
        valorAcumulado += valor;
        Debug.Log($"Valor acumulado: {valorAcumulado}");

        if (valorAcumulado >= valorMaximo)
        {
            PausarContadorPorObjetivo();
        }
    }

    void PausarContadorPorObjetivo()
    {
        if (gameTimer != null)
        {
            gameTimer.PausarContador();
            Debug.Log("Contador pausado: valor máximo alcanzado");
        }
        else
        {
            Debug.LogWarning("GameTimer no asignado en GameManager");
        }
    }

    // =========================
    // MÉTODOS ÚTILES OPCIONALES
    // =========================

    public void ReiniciarAcumulador()
    {
        valorAcumulado = 0f;
    }

    public float ObtenerValorAcumulado()
    {
        return valorAcumulado;
    }

    public float ObtenerValorMaximo()
    {
        return valorMaximo;
    }
}
