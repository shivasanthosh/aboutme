# Shivasanthoshkumar Sivakumar — Master Record

This is the single source of truth for [the website](../UI) and every resume under
[`base/`](base) and [`tailored/`](tailored). **Update here first**, then propagate
whatever's relevant into the site markup and/or a tailored `.tex`. Neither derived
surface needs to carry everything below — they each curate a subset for their medium.

**Public-safe by design:** this file lives in a public repo. No compensation figures,
no private application-tracking notes (which company, what they emphasized, interview
feedback) — keep that in a separate, untracked file outside this repo if you want it at all.

Last reviewed: 2026-09-12.

## Profile

Senior Developer (career start **2019-12-31** — the website computes "years experience" live off this date; a resume is a snapshot, so update its hardcoded figure by hand when you next touch it) specializing in Azure Cloud, data engineering and applied AI.
Certified Azure DevOps Engineer Expert. Track record of shipping production data platforms
and the AI experiences built on top of them. Go-to languages: **C#** and **Python**.

## Skills

**Languages:** C#, Python, TypeScript

**Frameworks & Tooling:** .NET Core, ASP.NET MVC, Web API, Minimal API, Blazor/Razor, WPF,
WinForms, EF Core, LINQ, Xamarin, SQL/NoSQL, Data Structures & Algorithms, REST, Agile

**Cloud & Data:** Microsoft Fabric (notebooks, OneLake, Lakehouse, Warehouse, connections),
PySpark (medallion ETL — bronze → silver → gold), Power BI, Azure (Web Apps, Function Apps,
Logic Apps, API Management, Service Bus, Event Grid, Event Hub, Redis Cache, Storage Account,
Azure Data Factory, Key Vault, Entra ID, Virtual Network, Policy, Monitor, Azure OpenAI
Service), AWS, GCP

**AI:** AWS Bedrock (query endpoint over a data lakehouse), MCP (served via Azure Function
App), Azure OpenAI Service, Blazor-based chatbot UX

**DevOps:** Docker, Terraform, CI/CD, Key Vault-based secrets management, Git

## Certifications

| Certification | Issuer | Verify |
|---|---|---|
| AZ-400 — Azure DevOps Engineer Expert | Microsoft | https://www.credly.com/badges/b6ecb375-6bad-4ba3-a621-4bfafcd50f4f/public_url |
| AZ-204 — Azure Developer Associate | Microsoft | https://www.credly.com/badges/7ff91383-901b-493e-b8cc-fcffab306ff6 |
| AZ-900 — Azure Fundamentals | Microsoft | https://www.credly.com/badges/2a82bf49-fe81-4faf-a22a-2ba87fefda26 |
| SAFe® for Teams 6.0 | Scaled Agile | https://www.credly.com/earner/earned/badge/61123942-a068-45e5-98be-1f078245a222 |
| Deloitte AI Academy — EP Data Analyst | Deloitte | — |
| Deloitte Data Science Essentials (DSE) Program Capstone | Deloitte / DataCamp | — (certificate B0011210283880, no public verify link) |
| Project Management Course | Udemy (via Cognizant) | — (behind Cognizant's SSO-gated Udemy Business portal, not publicly verifiable) |

## Education

- **Scaler Academy** — Software Development Course — May 2022 – May 2024 — Karnataka
- **Kongu Engineering College** — BE, Electronics and Communication Engineering — Jul 2015 – Jul 2019 — Tamil Nadu

## Experience

### Senior Developer — Deloitte USI (Apr 2023 – Present, Bangalore — ongoing, so its "X yrs" grows; update by hand when touching a resume)

- Engineered scalable solutions to scan **3.5M+ cloud resources daily**, with automated
  misconfiguration detection that identified and remediated **243K+ issues**, delivering
  near real-time compliance visibility.
- Led migration of legacy platforms to managed Azure environments using IaC, reducing
  migration timelines by **40%** while ensuring **zero downtime**.
- Developed a RESTful Exception Management API, automating exception workflows and
  cutting manual effort by **60%**.
- Built an enterprise lakehouse on **Microsoft Fabric/OneLake** — a general Fortune-listed
  enterprise client engagement, kept intentionally vague on client/data specifics — 10+
  heterogeneous sources (Blob, S3, DynamoDB, Excel, JSON, SQL) normalized through a
  medallion (bronze → silver → gold) architecture, powering **15+ Power BI** reports.
  Source-controlled with CI/CD, secrets in Key Vault, infrastructure in Terraform.
- Shipped an AI data assistant on top of that platform: an **MCP** server on Azure
  Functions exposes the gold layer to other app teams, and an **AWS Bedrock**-backed
  Blazor chatbot gives it a natural-language query experience.
- Designed and implemented audit log and event history modules using Azure Table Storage
  and event-driven patterns, enabling real-time change tracking.
- Built an advanced hybrid caching solution with resiliency features, delivering
  high-speed data access and fault tolerance across two enterprise projects.
- Built secure file upload and automated analysis workflows, reducing cloud security
  assessment turnaround from **5 days to 2 days**.
- Configured Azure API Management to securely expose platform data, streamlining partner
  onboarding and boosting API adoption by **25%**.
- Established automated integration tests and CI/CD pipelines in .NET, reducing
  production defects by **30%** and accelerating releases.
- Mentored and guided peers and junior developers, fostering best practices in coding,
  architecture, and cloud adoption.
- **Tech stack:** .NET 9, CQRS, Azure, Microsoft Fabric, PySpark, Terraform, Blazor,
  Power BI, AWS Bedrock

### Developer — Cognizant Technology Solutions (Dec 2019 – Apr 2023, Bangalore/Chennai, 3.3 yrs)

- Modernized legacy systems by developing and optimizing ASP.NET MVC apps with Razor and
  Entity Framework Core, improving performance by **10%** and enhancing user experience.
- Designed a high-performance Azure Function App to monitor on-prem SFTP/FTP servers and
  transfer files to Blob Storage, achieving **2x faster processing** vs. the legacy solution.
- Automated deployment pipelines for APIs across environments, integrating code scans and
  unit tests to improve code quality and security.
- Reduced manual workload by **50%** by automating fault reporting and migrating desktop
  applications into scalable web-based solutions.
- **Tech stack:** C#.NET, ASP.NET MVC, Azure Functions, SQL Server, JIRA, Checkmarx

## Projects

### Enterprise Lakehouse Platform (Deloitte USI)
Ingests 10+ heterogeneous sources into Microsoft Fabric OneLake through a bronze → silver
→ gold medallion architecture; gold-layer schemas power 15+ production Power BI reports.
Source-controlled CI/CD, Terraform, Key Vault. *(Client/data specifics kept vague by design.)*
Tags: `microsoft-fabric` `onelake` `pyspark` `power-bi` `terraform` `ci-cd` `key-vault`

### AI Data Assistant (Deloitte USI)
Built on top of the Lakehouse Platform above. An Azure Function App exposes the gold
layer through MCP for other app teams; AWS Bedrock answers natural-language queries
surfaced through a Blazor chat UI.
Tags: `aws-bedrock` `mcp` `azure-functions` `blazor` `rag`

### SmartSeller
Multi-platform order automation: a console app automating multi-order processing via
Flipkart Seller APIs (**3x faster** processing, **40% increase** in annual sales with
minimal manual intervention), plus a Xamarin.Forms mobile app for order tracking.
Demo: [console app](https://youtu.be/wT-YlnsC1GY) · [mobile app](https://youtu.be/dzDoWu8-bc0) ·
[README](https://github.com/shivasanthosh/Achievements/blob/3600f784dd89931b59141314477a2ba5d57fdc9f/README.md)
Tags: `csharp` `dotnet-core` `xamarin`

### ReportWriter Desktop Application
WPF/MVVM document-generation tool integrated with the FileMaker API for data-driven
report output. 8 months.
Tags: `wpf` `xaml` `filemaker-api`

## Achievements

- **Applause Award — 2026:** for contributions to GISCO, recognized for going the extra mile.
  ([PDF](../UI/wwwroot/data/ApplauseAward2026.pdf))
- **Spot Award — 2025:** for leading the design of a core API and enabling scalable
  integration. ([PDF](../UI/wwwroot/data/SpotAward2025.pdf))
- **Applause Award — 2024:** for improving system reliability with flawless features,
  recognized by leadership. ([PDF](../UI/wwwroot/data/ApplauseAward2024.pdf))
- **Applause Award — 2023:** for delivering impactful features and building a robust
  testing framework. ([PDF](../UI/wwwroot/data/ApplauseAward2023.pdf))

## Links

- Portfolio: https://shivasanthosh.github.io/aboutme/
- LinkedIn: https://linkedin.com/in/shivasanthoshkumar
- GitHub: https://github.com/shivasanthosh
- Scaler: https://www.scaler.com/academy/profile/6cb69ccf7d1c
- Credly: https://www.credly.com/users/shiva-santhosh-kumar-sivakumar/badges
- Email: shivasanthosh531@gmail.com
- Phone: +91-95434-93454

## Maintenance

When something changes (new role, new project, new metric, new cert):
1. Edit this file first.
2. Update `../UI/Pages/Home.razor` (and `Home.razor.cs`'s `Projects` list) if it belongs
   on the public site.
3. Update `base/ShivaSanthoshKumar-Resume.tex` if it belongs on the general resume —
   mind the one-page limit; trim something of lower impact if you add something new.
4. For a job application, copy `base/` to `tailored/<company>-<role-slug>/` and re-weight
   from this file for that JD — don't add anything not already here. See `resume/README.md`.
