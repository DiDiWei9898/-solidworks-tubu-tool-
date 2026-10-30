using System;
using System.Windows.Forms;
using 涂布二次开发工具.UI;
using 涂布二次开发工具.Modules;

namespace 涂布二次开发工具
{
    public partial class MainForm : Form
    {
        private NavigationButton _btnHome;
        private NavigationButton _btnParamModel;
        private NavigationButton _btnDrawing;
        private NavigationButton _btnBom;
        private NavigationButton _btnCalc;

        private Panel _contentPanel;
        private Label _lblSwStatus;
        private Label _lblVersion;

        public MainForm()
        {
            InitializeComponent();
            InitNavigation();
            ShowHome();
        }

        private void InitNavigation()
        {
            // 首页
            _btnHome = new NavigationButton();
            _btnHome.Text = "  首页";
            _btnHome.Click += (s, e) => ShowHome();
            panelNav.Controls.Add(_btnHome);

            // 参数化建模
            _btnParamModel = new NavigationButton();
            _btnParamModel.Text = "  参数化建模";
            _btnParamModel.Click += (s, e) => ShowParamModel();
            panelNav.Controls.Add(_btnParamModel);

            // 工程图工具
            _btnDrawing = new NavigationButton();
            _btnDrawing.Text = "  工程图工具";
            _btnDrawing.Click += (s, e) => ShowDrawing();
            panelNav.Controls.Add(_btnDrawing);

            // BOM工具
            _btnBom = new NavigationButton();
            _btnBom.Text = "  BOM 工具";
            _btnBom.Click += (s, e) => ShowBom();
            panelNav.Controls.Add(_btnBom);

            // 工程计算
            _btnCalc = new NavigationButton();
            _btnCalc.Text = "  工程计算";
            _btnCalc.Click += (s, e) => ShowCalc();
            panelNav.Controls.Add(_btnCalc);

            // 反转顺序（因为Dock=Top会倒序）
            panelNav.Controls.SetChildIndex(_btnHome, 0);
            panelNav.Controls.SetChildIndex(_btnParamModel, 1);
            panelNav.Controls.SetChildIndex(_btnDrawing, 2);
            panelNav.Controls.SetChildIndex(_btnBom, 3);
            panelNav.Controls.SetChildIndex(_btnCalc, 4);
        }

        private void SetSelected(NavigationButton btn)
        {
            _btnHome.IsSelected = false;
            _btnParamModel.IsSelected = false;
            _btnDrawing.IsSelected = false;
            _btnBom.IsSelected = false;
            _btnCalc.IsSelected = false;
            btn.IsSelected = true;
        }

        private void ClearContent()
        {
            panelContent.Controls.Clear();
        }

        private void ShowHome()
        {
            SetSelected(_btnHome);
            ClearContent();
            var ctrl = new HomeControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowParamModel()
        {
            SetSelected(_btnParamModel);
            ClearContent();
            var ctrl = new ParamModelControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowDrawing()
        {
            SetSelected(_btnDrawing);
            ClearContent();
            var ctrl = new DrawingControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowBom()
        {
            SetSelected(_btnBom);
            ClearContent();
            var ctrl = new BomControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }

        private void ShowCalc()
        {
            SetSelected(_btnCalc);
            ClearContent();
            var ctrl = new CalcControl();
            ctrl.Dock = DockStyle.Fill;
            panelContent.Controls.Add(ctrl);
        }
    }
}
