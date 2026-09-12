# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

Personal portfolio site for Shiva Santhosh, built as a **Blazor WebAssembly (.NET 9)** single-page app and deployed to **GitHub Pages** at `https://shivasanthosh.github.io/aboutme/`. There is no backend and no test project.

## Commands

All commands run from the repo root.

```sh
dotnet build UI/UI.csproj                      # build
dotnet run --project UI/UI.csproj              # dev server at http://localhost:5217 (hot reload: dotnet watch --project UI/UI.csproj)
dotnet publish UI/UI.csproj -c Release -o release   # what CI runs; static output lands in release/wwwroot
```

Deployment is automatic: `.github/workflows/deploy.yml` publishes on every push to `main` and pushes `release/wwwroot` to the `gh-pages` branch. Never commit to `gh-pages` directly.

## Architecture

- `UI/` is the only project (`aboutme.sln` wraps it). `Program.cs` is stock Blazor WASM bootstrap.
- **Routing/base path:** the site is served under `/aboutme/` on GitHub Pages. GitHub Pages serves `404.html` for deep links, which boots the app and lets the Blazor router resolve the path. Consequences:
  - In-app links must be **relative** (`href="certificate/az400"`, `href=""` for home) — never `href="/"`, which escapes to the domain root.
  - Source keeps `<base href="/">` so `dotnet run` works at `http://localhost:5217/`; the deploy workflow `sed`s it to `/aboutme/` in the published `index.html`/`404.html`. Never hard-code `/aboutme/` in source.
- **Pages:** `Pages/Home.razor` is a single long-scroll page with anchor sections (`#about`, `#skills`, `#certifications`, `#experience`, `#projects`, `#achievements`, `#contact`). `Pages/Certificate.razor` (`/certificate/{Id}`) is the only other route; its content comes from a `switch` on `Id` in `Certificate.razor.cs`. Adding a certificate means adding a card in `Home.razor` **and** a case in that switch.
- **Code-behind convention:** logic lives in `*.razor.cs` partial classes (`Home.razor.cs`, `Certificate.razor.cs`), not `@code` blocks.
- **Styling:** Bootstrap 5 (vendored, only `bootstrap.min.css` + `bootstrap.bundle.min.js` kept in `wwwroot/lib`) + Font Awesome 6 from CDN. `wwwroot/css/app.css` defines the Inspinia-style classes the markup uses (`ibox`, `ibox-title`, `navy-bg`, `widget`, `timeline-item`, `product-box`, etc.) — there is no Inspinia theme installed; those classes only exist because `app.css` re-implements them. Use `fa`/`fab` icon classes, not `bi-*`.
- **Static assets:** certificate images in `wwwroot/Images/`, award PDFs in `wwwroot/data/` (shown in an in-page `<iframe>` modal driven by `Home.razor.cs`).
