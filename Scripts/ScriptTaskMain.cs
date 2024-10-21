public void Main()
{

    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
// TODO: Add your code here

    var word_path = Dts.Variables["User::WordFilePath"].Value.ToString();
    var word_path_output = Dts.Variables["User::WordFilePathOutput"].Value.ToString();
    var word_file_name = Dts.Variables["User::WordFileName"].Value.ToString();

    //Bring personal details to be replaced.
    var real_name = Dts.Variables["User::personal_name"].Value.ToString();
    var real_phone = Dts.Variables["User::personal_phone"].Value.ToString();
    var real_address = Dts.Variables["User::personal_address"].Value.ToString();
    var real_email = Dts.Variables["User::personal_email"].Value.ToString();
    var real_company = Dts.Variables["User::personal_company"].Value.ToString();
    var real_title = Dts.Variables["User::personal_title"].Value.ToString();
    //Bring job related informations
    var job_title = Dts.Variables["User::job_title"].Value.ToString();
    var job_company = Dts.Variables["User::job_company"].Value.ToString();
    var job_description = Dts.Variables["User::job_description"].Value.ToString();

    //Get the current date
    DateTime today = DateTime.Today;
    var today_formatted = today.ToString("yyyyMMdd");
    //Remove whitespaces from target company name for file naming
    var job_company_formatted = Regex.Replace(job_company, @"\s+", "");

    var WordApp = new Microsoft.Office.Interop.Word.Application();
    var WordDoc = WordApp.Documents.Open(word_path + word_file_name);

    var existingContent = WordDoc.Content;
    existingContent.Find.Execute(FindText: "[YourName]", ReplaceWith: real_name, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[YourEmail]", ReplaceWith: real_email, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[YourPhone]", ReplaceWith: real_phone, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[YourAddress]", ReplaceWith: real_address, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[YourCompany]", ReplaceWith: real_company, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[YourTitle]", ReplaceWith: real_title, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[RoleTitle]", ReplaceWith: job_title, Replace: WdReplace.wdReplaceAll);
    existingContent.Find.Execute(FindText: "[RoleCompany]", ReplaceWith: job_company, Replace: WdReplace.wdReplaceAll);


    WordDoc.SaveAs(word_path_output + today_formatted + "_CoverLetter_" + job_company_formatted + ".docx");
    WordDoc.Close();
    WordApp.Quit();


}