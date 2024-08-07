
# SpawnDev.BlazorJS.BrowserExtension

This project is new and under active development. A Nuget package will be released soon.

SpawnDev.BlazorJS.BrowserExtension adds the ability for Blazor WASM to run as a web browser Manifest V3 extension. Blazor can run in all extension contexts. Runs in content context (in page with any site), popup window, options window, and the background.

## Features
- Manifest V3
- Supports multi-platform extension builds (Firefox, Chrome, etc)
- Supports non-SIMD compatible browsers/devices. Uses SIMD when available.
- Supports shared and platform specific manifest entries
- Blazor WASM runs in ALL extension contexts: 
  - Background page (Firefox), 
  - Background ServiceWorker (Chrome)
  - Content script
  - Options, Popup, etc

