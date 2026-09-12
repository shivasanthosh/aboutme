---
name: add-certificate
description: Add a new certificate/certification to the aboutme portfolio site and resume, given an image (screenshot or scan) of the certificate. Use when the user shares a new certificate image and asks to add it to the site, resume, or CONTEXT.md, or mentions "new certificate"/"new cert"/"add certification".
---

# Add Certificate

Adds one certificate consistently across all four surfaces this repo keeps in sync.
Read `../../../CLAUDE.md` first if not already in context — this skill assumes its
Pages/Architecture/Resume-system sections.

## Steps

1. **Read the certificate image** (Read tool handles PNG/JPG/PDF). Extract: title/program
   name, issuer, recipient name (sanity-check it's Shivasanthoshkumar Sivakumar), any
   subtitle (e.g. exam code), program length/dates, certificate/credential ID, and any
   verify URL printed on it. **Never invent a verify URL** — if none is shown, there isn't one.

2. **Look at the 6+ existing cases** in `UI/Pages/Certificate.razor.cs` and cards in
   `UI/Pages/Home.razor` (`#certifications` section) to match conventions:
   - **Slug** (routing id, e.g. `az400`, `dse-capstone`): short kebab-case, propose one from
     the cert's exam code or acronym, confirm with user rather than open-ended asking.
   - **PackageId** (e.g. `Azure.DevOps.Engineer.Expert`, `Deloitte.DataScienceEssentials.Capstone`):
     dotted PascalCase, issuer + program name.
   - **Image filename**: PascalCase, descriptive (e.g. `DeloitteDataScienceEssentialsCapstone.png`),
     saved into `UI/wwwroot/Images/`.
   - **Skills list**: 3-6 bullet points *summarizing* what the program covers — infer from
     the title/description on the certificate, don't quote it verbatim.

3. **Save the image** into `UI/wwwroot/Images/<Name>.png` (or `.jpg`, matching the source).

4. **Update `resume/CONTEXT.md`** first (single source of truth) — add a row to the
   Certifications table: `| <Name> | <Issuer> | <verify URL or "— (reason)"> |`.

5. **Update `UI/Pages/Home.razor`** — add a `.package-card` in the `#certifications`
   `.package-grid`, following the exact existing markup shape:
   ```razor
   <div class="package-card" @onclick="@(() => NavigateToCertificate("<slug>"))">
       <div class="package-header"><i class="fa fa-box"></i><span class="package-name">@PackageId</span><span class="package-version">v1.0.0</span></div>
       <div class="package-cmd"><span class="prompt">&gt;</span>dotnet add package <PackageId></div>
       <p class="package-desc"><one-line summary></p>
       <span class="package-link">View package →</span>
   </div>
   ```

6. **Update `UI/Pages/Certificate.razor.cs`** — add a case to the `Id switch` in
   `GetCertificateDetails()` with `Title`, `Subtitle`, `PackageId`, `Version`, `ImageUrl`,
   `Description`, `Skills`, and `CredlyUrl` only if a real verify link exists (otherwise omit
   it with a `// No CredlyUrl: ...` comment explaining why, matching the `pm-course` case).

7. **Update `resume/base/ShivaSanthoshKumar-Resume.tex`** — add one line under
   `\section{Certification}`: `\href{verify-url}{\textbf{...}}\\` if there's a verify link,
   else plain `\textbf{...}\\`. Do not try to compile the LaTeX (no toolchain locally — CI
   does it, per CLAUDE.md).

8. **Build to verify**: `dotnet build UI/UI.csproj` — must succeed with 0 errors.

9. Report what was added and where, and mention any inferred/uncertain fields (skills list,
   package name, slug) so the user can adjust.

## Notes

- Always touch files in this order: CONTEXT.md → Home.razor → Certificate.razor.cs → .tex.
  CONTEXT.md is the source of truth; the others are propagated from it.
- If the certificate has no image (e.g. a course-completion line item with no PDF), skip
  steps 1/3 and omit `ImageUrl` in the C# case — see the `pm-course` case for the pattern.
- Ask the user only when something has real consequences and is genuinely ambiguous
  (e.g. confirm a proposed slug/package name); don't ask about things you can read off the
  certificate image or infer confidently from existing conventions.
