# Android cloud build setup
Workflow: .github/workflows/android-build.yml (manual dispatch and main branch push).

## Required
- Add UNITY_LICENSE repository secret containing valid Unity license activation data.
- Unity license/account must permit CI; Android modules must be available to runner.
- Signed release: add keystore/password secrets and configure signing; never commit credentials.

## Current pipeline
Produces an unsigned development Android build artifact if Unity activation and runner succeed. Release signing/AAB is not yet implemented.

CI has not yet run. Confirm editor/license compatibility in Actions before treating artifacts as verified.
