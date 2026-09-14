---
name: add-project
description: Add a new project to the aboutme portfolio site (and resume), whether it's a standalone repo Shiva just built/shipped or work done at his employer. Use when the user says something like "add this as a project", "I shipped a new project", "add my new repo to the portfolio", or points at a sibling repo (e.g. job-tracker) and asks for it to show up on the site.
---

# Add Project

Adds one project consistently across the surfaces this repo keeps in sync (site always;
CONTEXT.md always as source of truth; resume `.tex` only if the user wants it there —
ask, don't assume). Read `../../../CLAUDE.md` first if not already in context — this
skill assumes its Architecture/Resume-system sections.

There is no separate "nav link" step: `TopNav.razor` already has a standing `#projects`
anchor link and the `#projects` section on `Home.razor` renders whatever's in the
`Projects` list. Adding to that list is the whole job — don't add new nav entries or
new sections.

## Steps

1. **Gather the facts.** If the project is another repo on this machine (sibling to
   `aboutme`, e.g. `../job-tracker`), read its `CLAUDE.md`/`README` for what it is, its
   stack, and its deployed/live URL rather than asking the user to restate it. Otherwise
   ask (or use what the user already gave you) for: name, one-line description, tech
   stack/tags, employer or personal, and a link if one exists (live app preferred over
   source for a personal project; source/demo link if there's no live deployment — see
   SmartSeller's `README & demos` entry for that shape).

2. **Look at the existing entries** in `UI/Pages/Home.razor.cs`'s `Projects` list to
   match conventions:
   - **Icon**: an unused-feeling Font Awesome icon relevant to what the project *is*
     (e.g. `fa-briefcase` for a tracker, `fa-robot` for an AI tool) — doesn't need to be
     unique, just don't reuse the immediately-preceding entry's icon.
   - **Org**: the employer name (e.g. `"Deloitte USI"`) for work projects, `null` for
     personal ones.
   - **Featured**: `true` is reserved for current flagship employer work (currently the
     two Deloitte USI entries) — leave personal/side projects `false` unless the user
     says otherwise.
   - **Tags**: 3-7 short kebab-case strings, real technologies used, matching the style
     of existing tags (e.g. `blazor-wasm` not `Blazor WebAssembly`).
   - **Url**: `(Label, Href)` tuple, omit if there's genuinely nothing to link to yet.

3. **Update `resume/CONTEXT.md`** first (single source of truth) — add a
   `### <Name> (<Org>)` entry (or `### <Name>` if personal) under `## Projects`,
   matching the existing entries' shape (short paragraph, optional `Demo:`/link line,
   `Tags:` line with backtick-wrapped tags).

4. **Update `UI/Pages/Home.razor.cs`** — append a `new Project(...)` to the `Projects`
   list (order is manual/chronological-ish, not auto-sorted — just add it at the end).
   No markup changes needed in `Home.razor`; the `#projects` grid and `TopNav`'s
   `#projects` link both already render/point at this list.

5. **Ask before touching the resume `.tex`.** Resume page length is tight and there's no
   local LaTeX toolchain to check for overflow (CI compiles it) — per CLAUDE.md, don't
   try to compile locally. Confirm with the user whether this project should also get a
   `\runsubsection{...}` under `\section{PROJECTS}` in
   `resume/base/ShivaSanthoshKumar-Resume.tex`, following the exact shape of the
   `SmartSeller`/`ReportWriter Desktop Application` entries (`\descript`, optional
   `\location` with a `\faIcon{link}` href, a `tightemize` list, a bold Tech Stack line,
   `\sectionsep`). If yes, add it last, right before `\end{minipage}`.

6. **Build to verify**: `dotnet build UI/UI.csproj` — must succeed with 0 errors.

7. Report what was added and where (including whether the `.tex` was touched), and flag
   anything inferred (icon choice, tags, Featured/Org) so the user can adjust.

## Notes

- Always touch files in this order: CONTEXT.md → Home.razor.cs → (optionally) `.tex`.
  CONTEXT.md is the source of truth; the others are propagated from it.
- If the project is a sibling repo under active development (not "done"), that's fine —
  personal projects here don't need to be finished, just live/shippable enough to link to.
- Don't invent a live URL — if the project isn't deployed anywhere yet, omit `Url` (or use
  a source/README link if the repo is public) rather than guessing at a domain.
- Ask the user only when something has real consequences and is genuinely ambiguous (the
  resume `.tex` inclusion, or Featured status for something that reads as flagship work) —
  not for things you can infer confidently from existing conventions (icon, tag casing).
