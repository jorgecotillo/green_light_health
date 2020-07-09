
using GreenLightHealth.Client.Constants;

namespace GreenLightHealth.Client.Models
{
    public class HomeViewModel
    {
        public string HealthDeclarationHeader = "Health Declaration";

        public string HealthDeclarationHeaderId = ViewConstants.HealthDeclarationHeaderId;

        public string HealthDeclarationParagraph = "For the health and safety of our community, your declaration of health is required. Please get immediate medical attention if you have any signs of COVID-19. Do you, to the best of your knowledge, have any symptoms or positive test results for COVID-19?";

        public string HealthDeclarationParagraphId = ViewConstants.HealthDeclarationParagraphId;

        public string HealthDeclarationModalId = ViewConstants.HealthDeclarationModalId;

        public string DefinitionsContainerId = "definitions-container";

        public string GreenLightDefinitionId = "greenlight-definition";

        public string GreenLightDefinition = "You have self-declared that you have symptoms or a positive test result. You could be at risk or put others at risk. Please seek consultation from medical experts to protect yourself and others if you have symptoms or a positive test result.";

        public string YellowLightDefinitionId = "yellowlight-definition";

        public string YellowLightDefinition = "You have declared that you are free of smptoms and have no positive test results. However, you may have been exposed through contact to others who are now reporting symptoms of illness. Please seek consultation from medical experts to protect yourself and others.";

        public string AcceptText = "No";

        public string DeclineText = "Yes";

        public string QrCodeId = ViewConstants.QrCodeId;

        public string StoplightId = ViewConstants.StoplightId;

        public string StoplightGreenBulbId = ViewConstants.StoplightGreenBulbId;

        public string StoplightYellowBulbId = ViewConstants.StoplightYellowBulbId;

        public string StoplightRedBulbId = ViewConstants.StoplightRedBulbId;

        public string AcceptId = ViewConstants.AcceptId;

        public string DeclineId = ViewConstants.DeclineId;

        public string LoginRegistrationModalId = ViewConstants.RegistrationForm;
    }
}
