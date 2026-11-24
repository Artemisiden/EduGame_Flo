using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

[RequireComponent(typeof(Animator))]
public class AddressableAnimator : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AssetReferenceT<RuntimeAnimatorController> controllerRef;
    public AudioSource audio = null;
    private bool loadOnEnable = true;
    private bool hideRendererUntilLoaded = true;

    private AsyncOperationHandle<RuntimeAnimatorController> loadHandle;
    private RuntimeAnimatorController baseController;
    private bool isLoaded;

    public bool IsLoaded => isLoaded;
    public event Action OnAnimationsLoaded;

    private void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();
        if (spriteRenderer == null) spriteRenderer = GetComponent<SpriteRenderer>();

        baseController = animator.runtimeAnimatorController;
    }

    private void OnEnable()
    {
        if (loadOnEnable)
        {
            _ = LoadAnimationsAsync();
        }
    }

    private void OnDisable()
    {
        if (loadOnEnable)
        {
            UnloadAnimations();
        }
    }

    public async Task<bool> LoadAnimationsAsync()
    {
        if (isLoaded) return true;

        if (controllerRef == null || !controllerRef.RuntimeKeyIsValid())
        {
            return false;
        }

        if (loadHandle.IsValid())
        {
            await loadHandle.Task;
            return isLoaded;
        }

        if (hideRendererUntilLoaded && spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        loadHandle = controllerRef.LoadAssetAsync();
        RuntimeAnimatorController loadedController = await loadHandle.Task;

        if (this == null || gameObject == null)
        {
            ReleaseHandle();
            return false;
        }

        if (loadHandle.Status == AsyncOperationStatus.Succeeded && loadedController != null)
        {
            animator.runtimeAnimatorController = loadedController;
            animator.Update(0f);

            if (hideRendererUntilLoaded && spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
                if(audio!=null)
                {
                    audio.Play();
                }
            }

            isLoaded = true;
            OnAnimationsLoaded?.Invoke();
            return true;
        }
        else
        {
            ReleaseHandle();
            return false;
        }
    }

    public void UnloadAnimations()
    {
        if (animator != null)
        {
            animator.runtimeAnimatorController = baseController;
        }

        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = null;
        }

        isLoaded = false;
        ReleaseHandle();
    }

    private void ReleaseHandle()
    {
        if (loadHandle.IsValid())
        {
            Addressables.Release(loadHandle);
            loadHandle = default;
        }
    }

    private void OnDestroy()
    {
        UnloadAnimations();
    }
}
