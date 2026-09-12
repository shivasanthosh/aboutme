using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    private bool showPdfModal;
    private string? currentPdfUrl;

    private void ShowPdf(string pdfUrl)
    {
        currentPdfUrl = pdfUrl;
        showPdfModal = true;
        StateHasChanged();
    }

    private void ClosePdfModal()
    {
        showPdfModal = false;
        currentPdfUrl = null;
    }

    private void NavigateToCertificate(string certificateId)
    {
        NavigationManager.NavigateTo($"certificate/{certificateId}");
    }

    /// <summary>
    /// Add a new project here — the grid renders whatever this list contains,
    /// featured ones first. No markup changes needed elsewhere.
    /// </summary>
    private static readonly IReadOnlyList<Project> Projects = new[]
    {
        new Project(
            Name: "Enterprise Lakehouse Platform",
            Icon: "fa-database",
            Org: "Deloitte USI",
            Description: "Ingests 10+ heterogeneous sources (Blob, S3, DynamoDB, Excel, JSON, SQL) into Microsoft Fabric OneLake through a bronze → silver → gold medallion architecture. Gold-layer schemas power 15+ production Power BI reports.",
            Tags: new[] { "microsoft-fabric", "onelake", "pyspark", "power-bi", "terraform", "ci-cd", "key-vault" },
            Featured: true),
        new Project(
            Name: "AI Data Assistant",
            Icon: "fa-robot",
            Org: "Deloitte USI",
            Description: "Chatbot experience over the Lakehouse's gold layer: an Azure Function App exposes the data through MCP for other app teams, and AWS Bedrock answers natural-language queries surfaced through a Blazor chat UI.",
            Tags: new[] { "aws-bedrock", "mcp", "azure-functions", "blazor", "rag" },
            Featured: true,
            Note: "Built on top of the Enterprise Lakehouse Platform above."),
        new Project(
            Name: "SmartSeller",
            Icon: "fa-mobile-screen",
            Org: null,
            Description: "Multi-platform order automation: a console app automating multi-order processing via Flipkart Seller APIs (3x faster, 40% increase in annual sales), plus a Xamarin.Forms mobile app for order tracking.",
            Tags: new[] { "csharp", "dotnet-core", "xamarin" },
            Featured: false,
            Url: ("README & demos", "https://github.com/shivasanthosh/Achievements/blob/3600f784dd89931b59141314477a2ba5d57fdc9f/README.md")),
        new Project(
            Name: "ReportWriter Desktop Application",
            Icon: "fa-file-lines",
            Org: null,
            Description: "WPF/MVVM document-generation tool integrated with the FileMaker API for data-driven report output.",
            Tags: new[] { "wpf", "xaml", "filemaker-api" },
            Featured: false),
    };

    private record Project(
        string Name,
        string Icon,
        string? Org,
        string Description,
        string[] Tags,
        bool Featured,
        string? Note = null,
        (string Label, string Href)? Url = null);
}
