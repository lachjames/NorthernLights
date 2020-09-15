using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuroraEmitter : MonoBehaviour
{
    float SIZE_FACTOR = 1f;

    public Material mat;
    public EmitterParameters emitterParameters;
    public EmitterHeader header;

    ParticleSystem particleSystem;
    ParticleSystemRenderer particleRenderer;
    ParticleSystem.MainModule mainModule;
    ParticleSystem.EmissionModule emissionModule;
    ParticleSystem.ShapeModule shapeModule;
    ParticleSystem.SizeOverLifetimeModule sizeModule;
    ParticleSystem.ColorOverLifetimeModule colorModule;
    ParticleSystem.TextureSheetAnimationModule texAnimModule;
    ParticleSystem.VelocityOverLifetimeModule velocityModule;
    ParticleSystem.CollisionModule collisionModule;
    ParticleSystem.RotationOverLifetimeModule rotationModule;
    ParticleSystem.LimitVelocityOverLifetimeModule limitVelocityModule;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Branches: " + header.numBranches);
        particleSystem = gameObject.AddComponent<ParticleSystem>();
        particleRenderer = GetComponent<ParticleSystemRenderer>();

        // Get and activate all the required modules
        mainModule = particleSystem.main;

        emissionModule = particleSystem.emission;
        emissionModule.enabled = true;

        shapeModule = particleSystem.shape;
        shapeModule.enabled = true;

        colorModule = particleSystem.colorOverLifetime;
        colorModule.enabled = true;

        sizeModule = particleSystem.sizeOverLifetime;
        sizeModule.enabled = true;

        texAnimModule = particleSystem.textureSheetAnimation;
        texAnimModule.enabled = true;

        velocityModule = particleSystem.velocityOverLifetime;
        velocityModule.enabled = true;

        collisionModule = particleSystem.collision;
        collisionModule.enabled = true;

        rotationModule = particleSystem.rotationOverLifetime;
        rotationModule.enabled = true;

        limitVelocityModule = particleSystem.limitVelocityOverLifetime;
        limitVelocityModule.enabled = true;

        // Set main parameters
        mainModule.gravityModifier = emitterParameters.gravity;
        mainModule.startSize = emitterParameters.sizeStart;
        mainModule.startLifetime = emitterParameters.lifeExp;

        // Set collision parameters
        collisionModule.bounce = emitterParameters.bounceCoefficient;
        
        // Set emission parameters
        emissionModule.rateOverTime = new ParticleSystem.MinMaxCurve(emitterParameters.birthRate);

        // Set size parameters
        // TODO: Use x, y values of size?
        // TODO: Use size mid
        sizeModule.size = new ParticleSystem.MinMaxCurve(
            emitterParameters.sizeStart / SIZE_FACTOR,
            emitterParameters.sizeEnd / SIZE_FACTOR
        );

        sizeModule.x = new ParticleSystem.MinMaxCurve(
            emitterParameters.sizeStartX / SIZE_FACTOR,
            emitterParameters.sizeEnd / SIZE_FACTOR
        );
        sizeModule.y = new ParticleSystem.MinMaxCurve(
            emitterParameters.sizeStartY > 0 ? emitterParameters.sizeStartY / SIZE_FACTOR : emitterParameters.sizeStartX / SIZE_FACTOR,
            emitterParameters.sizeEnd / SIZE_FACTOR
        );

        // Set color parameters
        // TODO: Support colorMid too
        //colorModule.color = new ParticleSystem.MinMaxGradient(
        //    new Color(
        //        emitterParameters.colorStart.r,
        //        emitterParameters.colorStart.g,
        //        emitterParameters.colorStart.b,
        //        emitterParameters.alphaStart
        //    ),
        //    new Color(
        //        emitterParameters.colorEnd.r,
        //        emitterParameters.colorEnd.g,
        //        emitterParameters.colorEnd.b,
        //        emitterParameters.alphaEnd
        //    )
        //);

        // Set texture sheet parameters
        texAnimModule.animation = ParticleSystemAnimationType.WholeSheet;
        //texAnimModule.cycleCount = 1;
        texAnimModule.fps = emitterParameters.fps;
        texAnimModule.numTilesX = 4;
        texAnimModule.numTilesY = 4;
        texAnimModule.startFrame = emitterParameters.frameStart;
        texAnimModule.timeMode = ParticleSystemAnimationTimeMode.FPS;

        // Velocity parameters
        velocityModule.speedModifier = emitterParameters.velocity;

        // Velocity limit parameters
        limitVelocityModule.drag = emitterParameters.drag;

        // Rotation over lifetime
        rotationModule.separateAxes = false;
        rotationModule.x = emitterParameters.particleRotation;

        // Particle system render options
        particleRenderer.minParticleSize = 0f;
        particleRenderer.maxParticleSize = 1f;
        particleRenderer.alignment = ParticleSystemRenderSpace.Facing;

        // Source: https://forum.unity.com/threads/change-standard-shader-render-mode-in-runtime.318815/
        mat.SetInt("_Mode", 2);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.SetInt("_ZWrite", 0);
        mat.DisableKeyword("_ALPHATEST_ON");
        mat.DisableKeyword("_ALPHABLEND_ON");
        mat.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        mat.renderQueue = 3000;

        mat.SetFloat("_SoftParticlesEnabled", 1f);
        mat.SetFloat("_SoftParticlesNearFadeDistance", 5f);
        mat.SetFloat("_SoftParticlesFarFadeDistance", 1f);

        mat.SetFloat("_CameraFadingEnabled", 1f);
        mat.SetFloat("_CameraFarFadeDistance", 5f);
        mat.SetFloat("_CameraNearFadeDistance", 1f);

        mat.SetFloat("_FlipbookMode", 1f);
        particleRenderer.material = mat;

        switch (header.blend)
        {
            case "Normal":
                break;
            case "Punch-Through":
                Debug.Log("Punch-Through not yet supported");
                break;
            case "Lighten":
                Debug.Log("Lighten not yet supported");
                break;
            default:
                Debug.Log(header.blend + " blend type not yet supported");
                break;
        }

        switch (header.render)
        {
            case "Normal":
                // Particles are billboards
                particleRenderer.renderMode = ParticleSystemRenderMode.VerticalBillboard;
                particleRenderer.alignment = ParticleSystemRenderSpace.Facing;
                break;
            case "Linked":
                // Particle "touch and are stretched where necessary to do so"
                Debug.LogWarning("Linked not yet supported");
                break;
            case "Billboard to Local Z":
                // Particle faces the way they came out regardless of camera movement
                Debug.LogWarning("Billboard to Local Z not yet supported");
                break;
            case "Billboard to World Z":
                // Particles face upwards
                particleRenderer.renderMode = ParticleSystemRenderMode.HorizontalBillboard;
                break;
            case "Aligned to World Z":
                Debug.LogWarning("Aligned to World Z not yet supported");
                break;
            case "Aligned to Particle":
                // Particles are aligned at the angle they leave the emitter
                // Uses the deadspace parameter
                Debug.LogWarning("Aligned to Particle not yet supported");
                break;
            case "Motion Blur":
                // Stretches the particles along the path of travel severely,
                // and overlaps them as well
                particleRenderer.renderMode = ParticleSystemRenderMode.Stretch;
                break;
            default:
                Debug.LogWarning("Did not recognize particle render mode " + header.render);
                break;
        }

        switch (header.update)
        {
            case "Fountain":
                shapeModule.angle = emitterParameters.spread;
                break;
            case "Single":
                break;
            case "Explosion":
                particleSystem.Stop();
                break;
            case "Lightning":
                break;
            default:
                Debug.LogWarning("Emitter style " + header.style + " not found");
                break;
        }
    }

    void FountainStyle ()
    {

    }

    void SingleStyle ()
    {

    }

    void ExplosionStyle ()
    {

    }

    void LightningStyle ()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
