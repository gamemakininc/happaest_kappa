using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(GlitchShaderRenderer), PostProcessEvent.AfterStack, "Custom/GlitchShader")]
public sealed class GlitchShader : PostProcessEffectSettings
{
    [Range(0,1), Tooltip("Amount of color drift")]
    public FloatParameter drift = new FloatParameter { value = 0.08f };
    [Range(0,1), Tooltip("Amount of horizontal jitter")]
    public FloatParameter jitter = new FloatParameter { value = 0.2f };
    [Range(0, 1), Tooltip("Cutoff for jitter")]
    public FloatParameter cutoff = new FloatParameter { value = 0.0f };
    public TextureParameter trashTex = new TextureParameter();
}

public sealed class GlitchShaderRenderer : PostProcessEffectRenderer<GlitchShader>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/Custom/GlitchShader"));
        sheet.properties.SetFloat("_Drift", settings.drift);
        sheet.properties.SetFloat("_Jitter", settings.jitter);
        sheet.properties.SetFloat("_Cutoff", settings.cutoff);
        sheet.properties.SetTexture("_TrashTex", settings.trashTex.value);
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
