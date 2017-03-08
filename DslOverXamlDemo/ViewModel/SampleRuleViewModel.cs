using System;
using System.Windows;
using System.Windows.Input;
using System.Xml.Linq;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Properties;
using DslOverXamlDemo.Rules.ViewModel;
using DslOverXamlDemo.Samples;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class SampleRuleViewModel : ChangeableEx
    {
        public SampleRuleViewModel()
        {
            m_data = SimpleXamlSerializer.ToXaml(SampleRules.GetOrCreateSampleRule());

            CopyCommand = new RelayCommand(() => Clipboard.SetText(Data), () => !string.IsNullOrEmpty(Data));
            PasteCommand = new RelayCommand(() => Data = Clipboard.GetText(), Clipboard.ContainsText);
            LoadDefaultCommand = new RelayCommand(() => LoadDefault());
            ToggleEditModeCommand = new RelayCommand(() => IsInEditMode = !IsInEditMode);
            SetEditModeCommand = new RelayCommand<bool>(x => IsInEditMode = x);
            ApplyEditTextCommand = new RelayCommand(() => ApplyEditText());
            ApplyGraphCommand = new RelayCommand(() => ApplyGraph(), () => IsGraphChanged);
            RevertGraphCommand = new RelayCommand(() => Designer = null, () => IsGraphChanged);
            SaveCommand = new RelayCommand(() => Save(), () => IsModified);
        }

        private bool m_isAutoApplyMode;

        private string m_data;

        public string Data
        {
            get { return m_data; }
            set
            {
                if (m_data != value)
                {
                    m_data = value;
                    m_asText = null;
                    m_asXaml = null;
                    NotifyOfPropertyChange(() => AsXaml);
                    NotifyOfPropertyChange(() => AsText);
                    NotifyOfPropertyChange(() => Data);

                    if (!m_isAutoApplyMode)
                        Designer = null;

                    IsInEditMode = false;
                    Changed();
                }
            }
        }

        private XElement m_asXaml;

        public XElement AsXaml
        {
            get
            {
                if (m_asXaml == null)
                    LogOnError(() => m_asXaml = string.IsNullOrEmpty(Data) ? null : XElement.Parse(Data));
                return m_asXaml; // ?? new XElement("ConditionRule");
            }
            set
            {
                if (m_asXaml != value)
                    LogOnError(() => Data = value?.ToString());
            }
        }

        private string m_asText;

        public string AsText
        {
            get { return m_asText ?? (m_asText = AsXaml?.ToString()); }
            set
            {
                if (m_asText != value)
                    LogOnError(() => AsXaml = string.IsNullOrEmpty(value) ? null : XElement.Parse(value));
            }
        }

        private RuleDesigner m_designer;

        public RuleDesigner Designer
        {
            get
            {
                if (m_designer == null)
                {
                    try
                    {
                        m_designer = new RuleDesigner(AsText);
                        m_designer.OnModified += GraphChanged;
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }
                return m_designer;
            }
            set
            {
                if (m_designer != value)
                {
                    if (m_designer != null)
                        m_designer.OnModified -= GraphChanged;
                    m_designer = value;
                    NotifyOfPropertyChange(() => Designer);
                    IsGraphChanged = false;
                }
            }
        }

        private void GraphChanged(object sender, EventArgs args)
        {
            IsGraphChanged = true;
        }

        private bool m_isGraphChanged;

        public bool IsGraphChanged
        {
            get { return m_isGraphChanged; }
            set
            {
                if (m_isGraphChanged != value)
                {
                    m_isGraphChanged = value;
                    NotifyOfPropertyChange(() => IsGraphChanged);
                    NotifyOfPropertyChange(() => Designer);
                    if (IsAutoApply)
                        ApplyGraph(true);
                }
            }
        }

        private bool m_isAutoApply = true;

        public bool IsAutoApply
        {
            get { return m_isAutoApply; }
            set
            {
                if (m_isAutoApply != value)
                {
                    m_isAutoApply = value;
                    NotifyOfPropertyChange(() => IsAutoApply);
                    if (value)
                        ApplyGraph();
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

        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }
        public ICommand LoadDefaultCommand { get; }
        public ICommand ToggleEditModeCommand { get; }
        public ICommand SetEditModeCommand { get; }
        public ICommand ApplyEditTextCommand { get; }
        public ICommand ApplyGraphCommand { get; }
        public ICommand RevertGraphCommand { get; }
        public ICommand SaveCommand { get; }

        private void LoadDefault()
        {
            Data = SimpleXamlSerializer.ToXaml(SampleRules.CreateSampleRule());
            LogInfo("Loaded default sample data.");
        }

        public void ApplyEditText()
        {
            if (IsInEditMode)
            {
                AsText = EditText;
                if (AsText == EditText)
                    IsInEditMode = false;
            }
        }

        public void ApplyGraph(bool isAutoApply = false)
        {
            if(m_designer == null || !IsGraphChanged)
                return;

            m_isAutoApplyMode = isAutoApply;
            try
            {
                AsText = SimpleXamlSerializer.ToXaml(Designer.Model.Value);
            }
            finally
            {
                m_isAutoApplyMode = false;
            }

            IsInEditMode = false;
            IsGraphChanged = false;
            Changed();
        }

        public void Save()
        {
            Settings.Default.SampleRuleXaml = Data;
            Settings.Default.Save();
            IsModified = false;
            LogInfo("Rule definition has been saved successfully.");
            EventAggregator.Instance.Publish(new ApplicationEvents.SettingsRefreshed());
        }
    }
}