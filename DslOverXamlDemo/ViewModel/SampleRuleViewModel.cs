using System;
using System.Windows.Input;
using System.Xml.Linq;
using DslOverXamlDemo.Contracts;
using DslOverXamlDemo.Contracts.Lib;
using DslOverXamlDemo.Interface;
using DslOverXamlDemo.Properties;
using DslOverXamlDemo.Rules.Model;
using DslOverXamlDemo.Rules.ViewModel;
using DslOverXamlDemo.Samples;

namespace DslOverXamlDemo.ViewModel
{
    public sealed class SampleRuleViewModel : ChangeableEx
    {
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
                    m_designer = null;
                    NotifyOfPropertyChange(() => AsXaml);
                    NotifyOfPropertyChange(() => AsText);
                    NotifyOfPropertyChange(() => Designer);
                    NotifyOfPropertyChange(() => Data);
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
                        m_designer.OnModified += (sender, args) => IsGraphChanged = true;
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }
                return m_designer;
            }
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
                    NotifyOfPropertyChange(() => IsGraphChangedOrInEditMode);
                    if (IsAutoApply)
                        ApplyGraph();
                }
            }
        }

        private bool m_isAutoApply;

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
                    NotifyOfPropertyChange(() => IsGraphChangedOrInEditMode);
                }
            }
        }

        public bool IsGraphChangedOrInEditMode => IsGraphChanged || IsInEditMode;

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

        private CurrentTabItem m_tabItem;

        public CurrentTabItem TabItem
        {
            get { return m_tabItem; }
            set
            {
                if (m_tabItem != value)
                {
                    m_tabItem = value;
                    NotifyOfPropertyChange(() => TabItem);
                    NotifyOfPropertyChange(() => IsXmlView);
                }
            }
        }

        public bool IsXmlView => TabItem == CurrentTabItem.XmlView;

        private ICommand m_loadDefaultCommand;

        public ICommand LoadDefaultCommand => m_loadDefaultCommand ?? (m_loadDefaultCommand = new RelayCommand(() => LoadDefault()));

        private ICommand m_toggleEditModeCommand;

        public ICommand ToggleEditModeCommand => m_toggleEditModeCommand ?? (m_toggleEditModeCommand = new RelayCommand(() => IsInEditMode = !IsInEditMode));

        private ICommand m_setEditModeCommand;

        public ICommand SetEditModeCommand => m_setEditModeCommand ?? (m_setEditModeCommand = new RelayCommand<bool>(b => IsInEditMode = b));

        private ICommand m_applyEditTextCommand;

        public ICommand ApplyEditTextCommand => m_applyEditTextCommand ?? (m_applyEditTextCommand = new RelayCommand(() => ApplyEditText()));

        private ICommand m_applyGraphCommand;

        public ICommand ApplyGraphCommand => m_applyGraphCommand ?? (m_applyGraphCommand = new RelayCommand(() => ApplyGraph(), () => IsGraphChanged));

        private ICommand m_saveCommand;

        public ICommand SaveCommand => m_saveCommand ?? (m_saveCommand = new RelayCommand(() => Save(), () => IsModified));

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

        public void ApplyGraph()
        {
            if (m_designer == null || !IsGraphChanged)
                return;

            AsText = SimpleXamlSerializer.ToXaml(Designer.Model.Value);
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

    public enum CurrentTabItem
    {
        XmlView,
        GraphView
    }
}