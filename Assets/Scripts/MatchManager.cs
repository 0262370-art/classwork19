using UnityEngine;
using TMPro;

public class MatchManager : MonoBehaviour
{
    [Header("Referencias de Objetos")]
    public ObjectController targetObject;
    public ObjectController playerObject;

    [Header("Interfaz de Usuario (Feedback)")]
    public TextMeshProUGUI feedbackText;

    [Header("Configuración de Tolerancia")]
    [Tooltip("Ángulo máximo de diferencia en grados para aceptar la rotación")]
    public float rotationToleranceDegrees = 25f;

    private void Start()
    {
        GenerateRandomTarget();
    }

    public void GenerateRandomTarget()
    {
        if (targetObject == null) return;

        targetObject.SetShape(Random.Range(0, 3));
        targetObject.SetColor(Random.Range(0, 3));
        targetObject.SetSize(Random.Range(0, 3));

        float rx = Random.Range(0, 4) * 90f;
        float ry = Random.Range(0, 4) * 90f;
        float rz = Random.Range(0, 4) * 90f;
        targetObject.transform.localRotation = Quaternion.Euler(rx, ry, rz);
    }

    public void ConfirmAnswer()
    {
        if (targetObject == null || playerObject == null) return;

        bool shapeMatch = playerObject.currentShape == targetObject.currentShape;
        bool colorMatch = playerObject.currentColor == targetObject.currentColor;
        bool sizeMatch = playerObject.currentSize == targetObject.currentSize;

        float angleDifference = Quaternion.Angle(playerObject.transform.localRotation, targetObject.transform.localRotation);
        bool rotationMatch = angleDifference <= rotationToleranceDegrees;

        if (shapeMatch && colorMatch && sizeMatch && rotationMatch)
        {
            feedbackText.text = "<b>¡FELICIDADES!</b>\nHas igualado el objeto con éxito.";
            feedbackText.color = Color.green;
        }
        else
        {
            string feedback = "<b>HAY ERRORES EN EL OBJETO:</b>\n";

            if (!shapeMatch) feedback += "• Forma incorrecta.\n";
            if (!colorMatch) feedback += "• Color incorrecto.\n";
            if (!sizeMatch) feedback += "• Tamaño incorrecto.\n";
            if (!rotationMatch) feedback += "• Orientación / Rotación incorrecta.\n";

            feedbackText.text = feedback;
            feedbackText.color = new Color(1f, 0.3f, 0.3f); 
        }
    }
}