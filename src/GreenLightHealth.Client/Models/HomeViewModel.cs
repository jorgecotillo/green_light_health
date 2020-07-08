﻿
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
