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
                ImageUrl = "/Images/Az400.png",
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
                CredlyUrl = "https://www.credly.com/users/shivasanthoshkumar"
            },
            "az204" => new CertificateDetail
            {
                Title = "Azure Developer Associate",
                Subtitle = "AZ-204",
                ImageUrl = "/Images/az204.png",
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
                CredlyUrl = "https://www.credly.com/users/shivasanthoshkumar"
            },
            "az900" => new CertificateDetail
            {
                Title = "Azure Fundamentals",
                Subtitle = "AZ-900",
                ImageUrl = "/Images/Az900.png",
                Description = "Microsoft Certified: Azure Fundamentals validates foundational knowledge of cloud services and how those services are provided with Microsoft Azure.",
                Skills = new[]
                {
                    "Cloud Concepts",
                    "Azure Services",
                    "Security & Privacy",
                    "Azure Pricing & Support"
                },
                CredlyUrl = "https://www.credly.com/users/shivasanthoshkumar"
            },
            "deloitte-ai" => new CertificateDetail
            {
                Title = "Deloitte AI Academy",
                Subtitle = "EP Data Analyst",
                ImageUrl = "/Images/DeloitteAiAcademyEPDataAnalyst.png",
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
                ImageUrl = "/Images/Safe6.png",
                Description = "Certified SAFe® 6.0 Practitioner with expertise in implementing Agile practices at enterprise scale.",
                Skills = new[]
                {
                    "Agile Practices",
                    "Program Increment Planning",
                    "Team & Technical Agility",
                    "Built-in Quality Practices",
                    "DevOps Implementation"
                }
            },
            _ => throw new ArgumentException($"Certificate with ID '{Id}' not found.")
        };
    }
}

public class CertificateDetail
{
    public string Title { get; set; } = string.Empty;
    public string Subtitle { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string[]? Skills { get; set; }
    public string? CredlyUrl { get; set; }
}
