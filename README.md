
# SpawnDev.BlazorJS.BrowserExtension

This project is new and under active development. A Nuget package will be released soon.

SpawnDev.BlazorJS.BrowserExtension adds the ability for Blazor WASM to run as a web browser Manifest V3 extension. Blazor can run in all extension contexts. Runs in content context (in page with any site), popup window, options window, and the background.

## Features
- Manifest V3
- Create a fully functional Manifest V3 web browser extension without writing a single line of Javascript
- Multi-platform extension builds (Firefox, Chrome, etc)
- Supports non-SIMD compatible browsers/devices. Uses SIMD when available
- Shared and platform specific manifest entries
- Blazor WASM runs in ALL extension contexts: 
  - Background page (Firefox)
  - Background ServiceWorker (Chrome)
  - Content script
  - Options, Popup, etc
- Direct access to extension [APIs](https://developer.chrome.com/docs/extensions/reference/api) via C#
  - Extension, Runtime, Tabs, Windows, Storage, etc


### Dependencies
- [SpawnDev.BlazorJS](https://github.com/LostBeard/SpawnDev.BlazorJS) - Enables full access to the Javascript environment, and Javascript class wrapping.
- [SpawnDev.BlazorJS.WebWorkers](https://github.com/LostBeard/SpawnDev.BlazorJS.WebWorkers) - Enables running Blazor WebAssembly in any web browser context, and inter-context communication.

