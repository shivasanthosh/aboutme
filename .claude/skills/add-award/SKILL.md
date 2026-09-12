---
name: add-award
description: Add a new award/achievement (Applause Award, Spot Award, etc.) to the aboutme portfolio site and resume, given a PDF or image of the award. Use when the user shares a new award document and asks to add it to the site, resume, or CONTEXT.md, or mentions "new award"/"add achievement".
---

# Add Award

Adds one award consistently across the three surfaces this repo keeps in sync (simpler
than the add-certificate skill — awards have no detail page, just a card + modal PDF viewer).
Read `../../../CLAUDE.md` first if not already in context.

## Steps

1. **Read the award document** (Read tool handles PDF/PNG/JPG). Extract: award type/title
   (e.g. "Applause Award", "Spot Award"), date (watch for DD/MM vs MM/DD ambiguity — Deloitte
   India documents are DD/MM/YYYY), the stated reason/contribution, and recipient (sanity-check
   it's Shivasanthoshkumar Sivakumar). **Never carry the monetary amount into any public-facing
   surface** — CONTEXT.md, the site, and the resume are all public; per CLAUDE.md's "public-safe
   by design" rule (no compensation figures), describe the *reason*, not the rupee/dollar value.

2. **Look at the existing entries** (`ApplauseAward2023`/`2024`, `SpotAward2025`) in
   `UI/Pages/Home.razor`'s `#achievements` section and `resume/CONTEXT.md`'s Achievements
   list to match conventions:
   - **PDF filename**: `<AwardType><Year>.pdf` in PascalCase, no spaces (e.g. `ApplauseAward2026.pdf`).
     If two awards of the same type land in the same year, append a letter or the award number.
   - **Icon**: pick an unused-feeling Font Awesome icon for variety (`fa-award`, `fa-star`,
     `fa-medal`, `fa-certificate`, `fa-trophy` are used/available) — doesn't need to be unique,
     just don't reuse the immediately-preceding card's icon.
   - **Description**: one sentence, present the contribution/reason plainly, no dollar figure.

3. **Save the PDF** into `UI/wwwroot/data/<AwardType><Year>.pdf`.

4. **Update `resume/CONTEXT.md`** first (single source of truth) — add a bullet to the
   Achievements list, **newest first** (the list is ordered by year, descending):
   ```md
   - **<Type> — <Year>:** <one-line reason>. ([PDF](../UI/wwwroot/data/<file>.pdf))
   ```

5. **Update `UI/Pages/Home.razor`** — add an `.award-card` to the `#achievements`
   `.awards-grid`, in the same newest-first position, following the exact existing shape:
   ```razor
   <div class="award-card">
       <div class="award-icon"><i class="fa fa-<icon>"></i></div>
       <div class="award-year"><year></div>
       <h4 class="award-title"><Award Type></h4>
       <p class="award-desc"><one-line reason></p>
       <button class="btn-ide" @onclick="@(() => ShowPdf("data/<file>.pdf"))">View Award</button>
   </div>
   ```
   No code-behind change is needed — awards render inline, unlike certificates.

6. **Update `resume/base/ShivaSanthoshKumar-Resume.tex`** — add one line under
   `\section{ACHIEVEMENTS}`, newest first:
   ```latex
   \href{https://shivasanthosh.github.io/aboutme/#achievements}{\faIcon{link}} \textbf{<Type> – <Year>:} <one-line reason>. \\
   ```
   Do not try to compile the LaTeX locally (no toolchain — CI does it, per CLAUDE.md).

7. **Build to verify**: `dotnet build UI/UI.csproj` — must succeed with 0 errors.

8. Report what was added and where, and flag anything inferred (icon choice, exact date
   reading) so the user can adjust.

## Notes

- Always touch files in this order: CONTEXT.md → Home.razor → .tex.
- Ask the user only when something is genuinely ambiguous with real consequences (e.g. an
  unreadable date, or an award type/filename collision) — not for things you can read off
  the document or infer confidently from existing conventions.
