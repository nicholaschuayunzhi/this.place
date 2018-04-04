using UnityEngine;
using UnityEngine.Rendering;

public class RendererController : MonoBehaviour, ITransparentRenderer
{
    public Material TransparentMaterial;
    private Material _originalMaterial;
    private Renderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _originalMaterial = _renderer.material;
    }


    public void SetTransparent(bool transparency)
    {
        _renderer.shadowCastingMode = transparency ? ShadowCastingMode.Off : ShadowCastingMode.On;

        _renderer.material = transparency ? TransparentMaterial : _originalMaterial;
    }

    public void SetAlpha(float a)
    {
        float alpha = Mathf.Clamp(a, 0, 100);
        _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, alpha);
    }
}
