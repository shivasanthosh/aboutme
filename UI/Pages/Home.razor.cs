using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace UI.Pages;

public partial class Home
{
    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;
    private bool showPdfModal;
    private string? currentPdfUrl;
    private bool showImageModal;
    private string? currentImageUrl;
    private string? currentImageTitle;

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

    private void ShowImageModal(string imageUrl, string title)
    {
        currentImageUrl = imageUrl;
        currentImageTitle = title;
        showImageModal = true;
        StateHasChanged();
    }

    private void CloseImageModal()
    {
        showImageModal = false;
        currentImageUrl = null;
        currentImageTitle = null;
        StateHasChanged();
    }

    private void NavigateToCertificate(string certificateId)
    {
        NavigationManager.NavigateTo($"/certificate/{certificateId}");
    }
}
