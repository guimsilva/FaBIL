namespace FastImageClassifier
{
    internal class Config
    {
        public string SourceFolder { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string LeftArrowClassName { get; set; } = "Negative";
        public string RightArrowClass { get; set; } = "Positive";
    }
}
