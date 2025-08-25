using Microsoft.AspNetCore.Components;

namespace UI.Pages;

public partial class Home
{
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
        StateHasChanged();
    }
}
