# Android cloud build setup

Workflow: `.github/workflows/android-build.yml` (manual dispatch and push to `main`).

## Required Unity activation
The GitHub Actions workflow currently fails before Unity imports or compiles the project because `UNITY_LICENSE` is empty. Verified log error:

```
Missing Unity License File and no Serial was found.
```

This is an account/license setup blocker, not a confirmed source-code compile failure.

1. On a computer (or a browser-capable setup), sign in to Unity and activate a Unity Personal license if eligible.
2. Generate the Unity license activation file for the exact Editor version used by CI (`6000.0.32f1`) following GameCI's license activation guide: https://game.ci/docs/github/activation
3. In GitHub, open **LAST-HOPE → Settings → Secrets and variables → Actions → New repository secret**.
4. Name it exactly `UNITY_LICENSE` and paste the complete license file contents. Keep it private; do not commit it.
5. Re-run **Actions → Unity Android Build → Run workflow** (or push a commit).

Alternatively, use `UNITY_SERIAL` only if you have a valid Unity serial and the corresponding account credentials/activation flow supports it.

## Current pipeline
Produces an unsigned development Android build artifact if Unity activation and runner succeed. Release signing/AAB is not yet implemented.

## Verification status
Latest run (run #38, commit `ab125078`) stopped at Unity activation due to missing `UNITY_LICENSE`; Unity compilation and tests were not reached. No APK has been verified yet.
