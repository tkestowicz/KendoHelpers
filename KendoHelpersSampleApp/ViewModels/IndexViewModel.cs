namespace KendoHelpersSampleApp.ViewModels
{
    public class IndexViewModel
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string FullName { get { return string.Format("{0} {1}", LastName, FirstName); } }
    }
}