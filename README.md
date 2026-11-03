# LAST HOPE

Android-first first-person survival game built with Unity, C#, and URP.

## Project status
Bootstrap repository. Unity editor and Android cloud build credentials are not yet configured.

## Target
- Platform: Android
- Engine: Unity 6 LTS
- Render pipeline: Universal Render Pipeline (URP)
- Input: touch controls (planned)
- CI: GitHub Actions + licensed Unity runner (setup pending)

## Structure
- Assets/_Project/Scripts/Runtime — gameplay code
- Assets/_Project/Scenes — scenes
- Assets/_Project/Settings — rendering and project settings
- Packages — Unity package manifest
- ProjectSettings — Unity project configuration
- .github/workflows — CI

Cloud builds require Unity licensing and repository secrets; see docs/ANDROID_BUILD.md.
