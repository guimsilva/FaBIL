namespace FastImageLabeler
{
    internal class Config
    {
        public string SourceFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string LeftArrowLabelName { get; set; } = "Negative";
        public string RightArrowLabelName { get; set; } = "Positive";
    }
}
