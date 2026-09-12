using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Certificate
{
    [Parameter]
    public string Id { get; set; } = string.Empty;

    public CertificateDetail CertificateDetails => GetCertificateDetails();

    private CertificateDetail GetCertificateDetails()
    {
        return Id switch
        {
            "az400" => new CertificateDetail
            {
                Title = "Azure DevOps Engineer Expert",
                Subtitle = "AZ-400",
                PackageId = "Azure.DevOps.Engineer.Expert",
                Version = "1.0.0",
                ImageUrl = "Images/Az400.png",
                Description = "Microsoft Certified: Azure DevOps Engineer Expert certification validates the skills and knowledge required to design and implement DevOps practices for Azure.",
                Skills = new[]
                {
                    "CI/CD Implementation",
                    "Infrastructure as Code",
                    "Security & Compliance",
                    "Source Control Management",
                    "Continuous Testing",
                    "Package Management",
                    "Release Strategy Design"
                },
                CredlyUrl = "https://www.credly.com/badges/b6ecb375-6bad-4ba3-a621-4bfafcd50f4f/public_url"
            },
            "az204" => new CertificateDetail
            {
                Title = "Azure Developer Associate",
                Subtitle = "AZ-204",
                PackageId = "Azure.Developer.Associate",
                Version = "1.0.0",
                ImageUrl = "Images/az204.png",
                Description = "Microsoft Certified: Azure Developer Associate certification demonstrates your ability to design, build, test, and maintain cloud solutions.",
                Skills = new[]
                {
                    "Cloud Solutions Development",
                    "Azure Services Integration",
                    "Serverless Computing",
                    "Azure Storage Solutions",
                    "Azure Security Implementation",
                    "Monitoring and Optimization"
                },
                CredlyUrl = "https://www.credly.com/badges/7ff91383-901b-493e-b8cc-fcffab306ff6"
            },
            "az900" => new CertificateDetail
            {
                Title = "Azure Fundamentals",
                Subtitle = "AZ-900",
                PackageId = "Azure.Fundamentals",
                Version = "1.0.0",
                ImageUrl = "Images/Az900.png",
                Description = "Microsoft Certified: Azure Fundamentals validates foundational knowledge of cloud services and how those services are provided with Microsoft Azure.",
                Skills = new[]
                {
                    "Cloud Concepts",
                    "Azure Services",
                    "Security & Privacy",
                    "Azure Pricing & Support"
                },
                CredlyUrl = "https://www.credly.com/badges/2a82bf49-fe81-4faf-a22a-2ba87fefda26"
            },
            "deloitte-ai" => new CertificateDetail
            {
                Title = "Deloitte AI Academy",
                Subtitle = "EP Data Analyst",
                PackageId = "Deloitte.AI.Academy.DataAnalyst",
                Version = "1.0.0",
                ImageUrl = "Images/DeloitteAiAcademyEPDataAnalyst.png",
                Description = "Successfully completed the Deloitte AI Academy™ Experienced Professionals Program: Data Analyst",
                Skills = new[]
                {
                    "Data extraction and organization with SQL",
                    "Data manipulation, analysis, and visualization with Python",
                    "Statistical inference and exploratory data analysis",
                    "Data hygiene",
                    "Enterprise AI Solutions Implementation"
                }
            },
            "safe6" => new CertificateDetail
            {
                Title = "SAFe® 6.0 Practitioner",
                Subtitle = "Scaled Agile Framework",
                PackageId = "SAFe.Practitioner",
                Version = "6.0.0",
                ImageUrl = "Images/Safe6.png",
                Description = "Certified SAFe® 6.0 Practitioner with expertise in implementing Agile practices at enterprise scale.",
                Skills = new[]
                {
                    "Agile Practices",
                    "Program Increment Planning",
                    "Team & Technical Agility",
                    "Built-in Quality Practices",
                    "DevOps Implementation"
                },
                CredlyUrl = "https://www.credly.com/earner/earned/badge/61123942-a068-45e5-98be-1f078245a222"
            },
            "pm-course" => new CertificateDetail
            {
                Title = "Project Management Course",
                Subtitle = "Udemy, via Cognizant",
                PackageId = "ProjectManagement.Fundamentals",
                Version = "1.0.0",
                Description = "Completed a project management fundamentals course covering planning, scheduling, risk, and stakeholder management, sponsored by Cognizant Technology Solutions.",
                Skills = new[]
                {
                    "Project Planning & Scheduling",
                    "Risk Management",
                    "Stakeholder Management"
                }
                // No CredlyUrl: the certificate lives behind Cognizant's SSO-gated
                // Udemy Business portal, not a publicly verifiable link.
            },
            _ => throw new ArgumentException($"Certificate with ID '{Id}' not found.")
        };
    }
}

public class CertificateDetail
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string PackageId { get; set; } = string.Empty;
    public string Version { get; set; } = "1.0.0";
    /// <summary>Optional — some certs (e.g. course completions) have no certificate image.</summary>
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public string[]? Skills { get; set; }
    public string? CredlyUrl { get; set; }
}
