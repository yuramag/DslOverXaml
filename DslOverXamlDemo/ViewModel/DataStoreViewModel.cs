using System.Windows.Input;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Model;
using DslOverXamlDemo.Properties;
using DslOverXamlDemo.Samples;
using Newtonsoft.Json;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class DataStoreViewModel : ChangeableEx
    {
        public DataStoreViewModel()
        {
            m_data = SampleDataStore.GetOrCreateSampleData();
        }

        private DataStore m_data;

        public DataStore Data
        {
            get { return m_data; }
            set
            {
                if (m_data != value)
                {
                    m_data = value;
                    m_editText = null;
                    Changed();
                    NotifyOfPropertyChange(() => AsText);
                    NotifyOfPropertyChange(() => Data);
                }
            }
        }

        private string m_editText;

        public string EditText
        {
            get { return m_editText; }
            set
            {
                if (m_editText != value)
                {
                    m_editText = value;
                    NotifyOfPropertyChange(() => EditText);
                }
            }
        }

        private bool m_isInEditMode;

        public bool IsInEditMode
        {
            get { return m_isInEditMode; }
            set
            {
                if (m_isInEditMode != value)
                {
                    m_isInEditMode = value;
                    EditText = value ? AsText : null;
                    NotifyOfPropertyChange(() => IsInEditMode);
                }
            }
        }

        public string AsText => JsonConvert.SerializeObject(m_data, Formatting.Indented);

        private ICommand m_toggleEditModeCommand;

        public ICommand ToggleEditModeCommand => m_toggleEditModeCommand ?? (m_toggleEditModeCommand = new RelayCommand(() => IsInEditMode = !IsInEditMode));

        private ICommand m_setEditModeCommand;

        public ICommand SetEditModeCommand => m_setEditModeCommand ?? (m_setEditModeCommand = new RelayCommand<bool>(b => IsInEditMode = b));

        private ICommand m_applyCommand;

        public ICommand ApplyCommand => m_applyCommand ?? (m_applyCommand = new RelayCommand(() => Apply()));

        private ICommand m_saveCommand;

        public ICommand SaveCommand => m_saveCommand ?? (m_saveCommand = new RelayCommand(() => Save(), () => IsModified));
        
        private ICommand m_loadDefaultCommand;

        public ICommand LoadDefaultCommand => m_loadDefaultCommand ?? (m_loadDefaultCommand = new RelayCommand(() => LoadDefault()));

        public void LoadDefault()
        {
            Settings.Default.SampleData = null;
            Data = SampleDataStore.GetOrCreateSampleData();
            LogInfo("Loaded default sample data.");
        }

        public void Apply()
        {
            var jsonSettings = new JsonSerializerSettings {MissingMemberHandling = MissingMemberHandling.Error};
            Settings.Default.SampleData = JsonConvert.DeserializeObject<DataStore>(EditText, jsonSettings);
            Data = SampleDataStore.GetOrCreateSampleData();
            IsInEditMode = false;
            LogInfo("Updated model has been accepted. Click Save to persist data.");
        }

        public void Save()
        {
            Settings.Default.SampleData = Data;
            Settings.Default.Save();
            IsModified = false;
            LogInfo("Data model has been saved successfully.");
            EventAggregator.Instance.Publish(new ApplicationEvents.SettingsRefreshed());
        }
    }
}