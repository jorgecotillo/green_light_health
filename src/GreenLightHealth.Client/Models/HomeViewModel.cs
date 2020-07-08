
using GreenLightHealth.Client.Constants;

namespace GreenLightHealth.Client.Models
{
    public class HomeViewModel
    {
        public string HealthDeclarationHeader = "Health Declaration";

        public string HealthDeclarationHeaderId = ViewConstants.HealthDeclarationHeaderId;

        public string HealthDeclarationParagraph = "For the health and safety of our community, declaration of illness is required. Be sure that the information you'll give is accurate and complete. Please get immediate medical attention if you have any of the COVID-19 signs.";

        public string HealthDeclarationParagraphId = ViewConstants.HealthDeclarationParagraphId;

        public string AcceptText = "Accept";

        public string DeclineText = "Decline";

        public string StoplightId = ViewConstants.StoplightId;

        public string AcceptId = ViewConstants.AcceptId;

        public string DeclineId = ViewConstants.DeclineId;
    }
}
