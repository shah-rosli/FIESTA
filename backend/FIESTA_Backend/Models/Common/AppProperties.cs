namespace FIESTA_Backend.Models.Common
{
    public static class AppProperties
    {
        public static string DocumentType_R14 = "R14";
        public static string DocumentType_ePR = "ePR";
        public static string DocumentType_INV = "INV";
        public static string UploadPath_R14 = "R14Upload";
        public static string UploadPath_ePR = "ePRUpload";
        public static string UploadPath_ePRReview = "ePRReviewUpload";
        public static string UploadPath_INV = "INVUpload";

        public static string ActionType_Insert = "Insert";
        public static string ActionType_Update = "Update";
        public static string ActionType_ProcurementFix = "ActionType_ProcurementFix";
        public static string ActionType_UpdateStatus = "ActionType_UpdateStatus";

        //Commented based on new req to filter based on only business
        //public static string Interface_OnitAPI = "https://renesas.onit.com/api/atom_dictionaries/54b7e691ed404f54990003bf/atoms.json?auth_token=8Th2jtUHVeQVvR-ysnE6&filter=%5B%7B%22property%22%3A%22curr_state_name%22%2C%22operator%22%3A%22like%22%2C%22value%22%3A%22business%22%2C%22type%22%3A%22string%22%7D%2C%7B%22property%22%3A%22p_contract_type%22%2C%22operator%22%3A%22like%22%2C%22value%22%3A%22%23(Vendor%7CLicense)%22%2C%22type%22%3A%22string%22%7D%5D&fieldset=_id,name,p_ready_for_signature,p_contract_number,p_contract_type,p_counter_party_selectable,p_contract_name_read_only,active_assigned_attorney_approver,p_renesas_poc_list,p_location_of_requester";
        public static string Interface_OnitAPI = "https://renesas.onit.com/api/atom_dictionaries/54b7e691ed404f54990003bf/atoms.json?auth_token=8Th2jtUHVeQVvR-ysnE6&filter=%5B%7B%22property%22%3A%22curr_state_name%22%2C%22operator%22%3A%22like%22%2C%22value%22%3A%22%23business%22%2C%22type%22%3A%22string%22%7D%5D&fieldset=_id,name,p_ready_for_signature,p_contract_number,p_contract_type,p_counter_party_selectable,p_contract_name_read_only,active_assigned_attorney_approver,p_renesas_poc_list,p_location_of_requester";

    }
}
