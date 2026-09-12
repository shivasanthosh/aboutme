# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this is

Personal portfolio site for Shiva Santhosh, built as a **Blazor WebAssembly (.NET 9)** single-page app and deployed to **GitHub Pages** at `https://shivasanthosh.github.io/aboutme/`. There is no backend and no test project. The repo also holds his **resume** (`resume/`, a LaTeX project, compiled via CI — see below).

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
- **Pages:** `Pages/Home.razor` is a single long-scroll page with anchor sections (`#about`, `#skills`, `#experience`, `#projects`, `#certifications`, `#achievements`, `#contact`), navigated via the sticky `Layout/TopNav.razor` bar. `Pages/Certificate.razor` (`/certificate/{Id}`) is the only other route; its content comes from a `switch` on `Id` in `Certificate.razor.cs`. Adding a certificate means adding a card in `Home.razor` **and** a case in that switch.
- **Code-behind convention:** logic lives in `*.razor.cs` partial classes (`Home.razor.cs`, `Certificate.razor.cs`), not `@code` blocks.
- **Projects are data-driven:** `Home.razor.cs` has a `private record Project` and a static `Projects` list; `Home.razor` just `@foreach`es it into `.repo-card`s. Add a new project by appending to that list — no markup changes needed. `Featured` projects (currently the two Deloitte USI ones) render first.
- **Design system — "you're looking at my editor":** no CSS framework (Bootstrap was removed); everything is hand-rolled dark VS Code–style theme in `wwwroot/css/app.css`, using CSS custom properties (`--bg`, `--blue`, `--cyan`, etc.) and JetBrains Mono (Google Fonts) for code-styled text. Font Awesome 6 (CDN) for icons — use `fa`/`fab` classes, not `bi-*`. Every section reuses the same `.ide-window` shell (macOS-style `.ide-titlebar` with `.ide-dots` + `.ide-tabs`) so a new section should follow that pattern rather than introducing a new visual language. Key composite components: `.tree*` (Solution Explorer skills tree), `.commit*`/`.git-log` (journey timeline), `.repo-card`/`.repo-grid` (projects), `.package-card`/`.package-grid` (certifications, styled as NuGet packages — the `/certificate/{id}` detail page continues the metaphor as a "package readme").
- **`.code-line` gutter is absolutely positioned, not flex** — this matters if you touch `app.css`: `display:flex` on a line containing multiple inline `<span>`s makes each span its own flex item, which breaks text wrapping into scrambled order on narrow screens. The line-number gutter uses `position:absolute` inside a `position:relative` line instead, so the rest of the line stays normal wrapping inline content.
- **Static assets:** certificate images in `wwwroot/Images/`, award PDFs in `wwwroot/data/` (shown in a themed `.ide-modal` iframe viewer driven by `Home.razor.cs`).

## Resume system

`resume/CONTEXT.md` is the **single source of truth** for both this website and the resume — every role, project, and metric, written in full. When adding or changing anything career-related, update `CONTEXT.md` first, then propagate whatever's relevant into `Home.razor`/`Home.razor.cs` and/or `resume/base/ShivaSanthoshKumar-Resume.tex`. It's public-safe by design (this repo is public): no compensation figures, no private application-tracking notes.

- `resume/base/` — the general-purpose resume (LaTeX, Deedy-Resume template, requires **XeLaTeX**). No LaTeX toolchain exists on the dev machine or in this repo's expectations — don't try to compile locally; CI does it.
- `resume/tailored/<company>-<role-slug>/` — per-application copies of `base/`, re-weighted from `CONTEXT.md` for a specific JD. Created on demand (not pre-populated), never fabricate content not already in `CONTEXT.md`.
- **CI:** `.github/workflows/deploy.yml` compiles `resume/base/*.tex` on every push to `main` and publishes it at `https://shivasanthosh.github.io/aboutme/resume.pdf` (linked from the site's `#contact` section). `.github/workflows/tailor-resume.yml` is `workflow_dispatch`-only, compiles a given `resume/tailored/<folder>/`, and uploads the PDF as a build artifact — tailored resumes are intentionally **never** published to the public site. See `resume/README.md` for the exact commands.
