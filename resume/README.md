# Resume

Source for Shiva's resume — a customized [Deedy-Resume](https://github.com/deedydas/Deedy-Resume)
(Apache-2.0) LaTeX template, compiled with **XeLaTeX**.

- **[`CONTEXT.md`](CONTEXT.md)** is the master record — every role, project, metric, cert,
  written in full. Update it first, before touching a resume or the website.
- **[`base/`](base)** is the general-purpose resume. Kept lean enough to fit one page;
  always safe to hand out as-is.
- **`tailored/<company>-<role-slug>/`** holds per-application copies of `base/`, re-weighted
  from `CONTEXT.md` for a specific job description (reorder skills, swap which bullets lead
  — never add anything not already in `CONTEXT.md`). Created on demand, not pre-populated.

## Getting a PDF

No local LaTeX install needed — this repo has no XeLaTeX toolchain, and this template's
fonts/packages are fiddly to set up by hand.

- **`base/`** compiles automatically in CI on every push to `main` that touches `resume/**`,
  and the PDF is published at **https://shivasanthosh.github.io/aboutme/resume.pdf** — always
  the latest version, one stable link to hand out.
- **A tailored version** compiles on demand via the `Compile Tailored Resume` GitHub Action
  (`.github/workflows/tailor-resume.yml`). Run it from the Actions tab, or:
  ```sh
  gh workflow run tailor-resume.yml -f folder=<company>-<role-slug>
  gh run watch                                   # wait for it to finish
  gh run download --name resume-<company>-<role-slug>
  ```
  It uploads the compiled PDF as a build artifact — not published anywhere public, since a
  resume tailored for one company shouldn't sit at a public URL next to one tailored for
  another.

## Making a tailored resume

1. `cp -r resume/base resume/tailored/<company>-<role-slug>`
2. Re-read `CONTEXT.md` against the job description; in the copied `.tex`, reorder/trim
   skills and swap which experience bullets lead — pull only from what's already in
   `CONTEXT.md`.
3. Commit, push, then run the workflow above to get the PDF.
