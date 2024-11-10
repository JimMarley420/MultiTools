using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Microsoft.Win32;
using MultiTools.Compressors;
using MultiTools.Converters;

namespace MultiTools.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly ZipCompressor _compressor = new ZipCompressor();
        private readonly EncodingConverter _encodingConverter = new EncodingConverter();

        public MainViewModel()
        {
            BrowseCompressionPathCommand = new RelayCommand(BrowseCompressionPath);
            CompressFilesCommand = new RelayCommand(CompressFiles);
            BrowseEncodingPathCommand = new RelayCommand(BrowseEncodingPath);
            ConvertEncodingCommand = new RelayCommand(ConvertEncoding);
        }

        public ICommand BrowseCompressionPathCommand { get; }
        public ICommand CompressFilesCommand { get; }
        public ICommand BrowseEncodingPathCommand { get; }
        public ICommand ConvertEncodingCommand { get; }

        private string _compressionStatus;
        public string CompressionStatus
        {
            get => _compressionStatus;
            set { _compressionStatus = value; OnPropertyChanged(nameof(CompressionStatus)); }
        }

        private string _encodingStatus;
        public string EncodingStatus
        {
            get => _encodingStatus;
            set { _encodingStatus = value; OnPropertyChanged(nameof(EncodingStatus)); }
        }

        public string SelectedEncoding { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void BrowseCompressionPath()
        {
            var dialog = new OpenFileDialog { CheckFileExists = true, CheckPathExists = true };
            if (dialog.ShowDialog() == true)
            {
                CompressionStatus = "Selected: " + dialog.FileName;
            }
        }

        private void CompressFiles()
        {
            // Implement compression logic
            CompressionStatus = "Compression successful!";
        }

        private void BrowseEncodingPath()
        {
            var dialog = new OpenFileDialog { CheckFileExists = true, CheckPathExists = true };
            if (dialog.ShowDialog() == true)
            {
                EncodingStatus = "Selected: " + dialog.FileName;
            }
        }

        private void ConvertEncoding()
        {
            // Implement encoding conversion logic
            EncodingStatus = "Encoding conversion successful!";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
