using UnityEngine;

public enum ShapeType { Cube, Sphere, Cylinder }
public enum ColorType { Red, Green, Blue }
public enum SizeType { Small, Medium, Large }

public class ObjectController : MonoBehaviour
{
    [Header("Componentes de Rederizado")]
    public MeshFilter meshFilter;
    public MeshRenderer meshRenderer;

    [Header("Mallas de Formas Base")]
    public Mesh cubeMesh;
    public Mesh sphereMesh;
    public Mesh cylinderMesh;

    [Header("Estado Actual")]
    public ShapeType currentShape = ShapeType.Cube;
    public ColorType currentColor = ColorType.Red;
    public SizeType currentSize = SizeType.Medium;

    private Quaternion initialRotation;
    private ShapeType initialShape;
    private ColorType initialColor;
    private SizeType initialSize;

    private Material instanceMaterial;

    private void Awake()
    {
        if (meshRenderer != null)
        {
            instanceMaterial = new Material(meshRenderer.sharedMaterial);
            meshRenderer.material = instanceMaterial;
        }

        initialRotation = transform.localRotation;
        initialShape = currentShape;
        initialColor = currentColor;
        initialSize = currentSize;

        UpdateVisuals();
    }

    public void SetShape(int shapeIndex)
    {
        currentShape = (ShapeType)shapeIndex;
        UpdateVisuals();
    }

    public void SetColor(int colorIndex)
    {
        currentColor = (ColorType)colorIndex;
        UpdateVisuals();
    }

    public void SetSize(int sizeIndex)
    {
        currentSize = (SizeType)sizeIndex;
        UpdateVisuals();
    }

    public void RotateX(float degrees) => transform.Rotate(Vector3.right, degrees, Space.Self);
    public void RotateY(float degrees) => transform.Rotate(Vector3.up, degrees, Space.Self);
    public void RotateZ(float degrees) => transform.Rotate(Vector3.forward, degrees, Space.Self);

    public void ResetObject()
    {
        currentShape = initialShape;
        currentColor = initialColor;
        currentSize = initialSize;
        transform.localRotation = initialRotation;
        UpdateVisuals();
    }

    public void UpdateVisuals()
    {
        if (meshFilter != null)
        {
            switch (currentShape)
            {
                case ShapeType.Cube: meshFilter.mesh = cubeMesh; break;
                case ShapeType.Sphere: meshFilter.mesh = sphereMesh; break;
                case ShapeType.Cylinder: meshFilter.mesh = cylinderMesh; break;
            }
        }

        if (instanceMaterial != null)
        {
            switch (currentColor)
            {
                case ColorType.Red: instanceMaterial.color = Color.red; break;
                case ColorType.Green: instanceMaterial.color = Color.green; break;
                case ColorType.Blue: instanceMaterial.color = Color.blue; break;
            }
        }

        switch (currentSize)
        {
            case SizeType.Small: transform.localScale = Vector3.one * 0.35f; break;
            case SizeType.Medium: transform.localScale = Vector3.one * 0.7f; break;
            case SizeType.Large: transform.localScale = Vector3.one * 1.0f; break;
        }
    }
}