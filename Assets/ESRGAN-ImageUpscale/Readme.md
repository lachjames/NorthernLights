# Barracuda ESRGAN image upscaler

## Disclaimer

This is proof of concept implementation of image upscaling workflow via Neural Net model ESRGAN by using local on-GPU inference via Unity Inference Engine Barracuda. This package should not be viewed as a final product and might never become one.

## Usage

Image upscaling is exposed as a context menu in the Unity Project view. Just right-click on the texture you would like to upscale and pick `Upscale Texture`.
ESRGAN model is quite memory hungry and it's recommended to try it first on smaller textures (under 512x512), bigger might work, but sometimes you might get corrupted results. 

This tool automatically creates a backup of the texture named as originalname-bak.extension, the content of the texture can be restored from backup at any time via context menu `Restore From Backup`. 
_Note:_ Only the first original version of texture is backed up automatically. Make sure to manually remove backup before editing your texture in the external tool. 

## Licenses
- Barracuda license is available in `Barracuda.Core` subfolder as `LICENSE.md`
- ESRGAN license is available in present folder as `ESRGAN-LICENSE`

# References 
- [ESRGAN source:https://github.com/xinntao/ESRGAN](https://github.com/xinntao/ESRGAN)

_P.S._: this package includes basic performance analytics (mem size, video mem size, texture res, OS version, GPU model, duration of the upscale). You can disable it in AssetUpscaler.cs, but please keep it on if possible as it helps us to better understand performance of our inference engine. Thanks!