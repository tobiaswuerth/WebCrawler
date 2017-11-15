using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Interface;
using ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface.Properties;

namespace ch.wuerth.tobias.WebCrawler.Infrastructure.UserInterface
{
    public partial class FormWebCrawler : Form
    {
        private readonly IFormWebCrawler _iFormWebCrawler;
        private readonly List<Control> _settingsControls;

        public FormWebCrawler(IFormWebCrawler iFormWebCrawler)
        {
            InitializeComponent();
            _iFormWebCrawler = iFormWebCrawler;

            _settingsControls = new List<Control>
            {
                txtUri,
                nudDepth,
                nudInstances,
                nudMaxTasks,
                nudNoTaskIntervalBreak,
                nudRetries,
                nudTaskRestockThreshold,
                nudTasksBufferSize,
                nudTimeout,
                nudUpdateIntervalBreak
            };

            Int32 depth = _iFormWebCrawler.GetDepth();
            Int32 instances = _iFormWebCrawler.GetInstances();
            Int32 maxTasks = _iFormWebCrawler.GetMaxTasks();
            Int32 noTaskIntervalBreak = _iFormWebCrawler.GetNoTaskIntervalBreak();
            Int32 retries = _iFormWebCrawler.GetRetries();
            Int32 taskRestockThreshold = _iFormWebCrawler.GetTaskRestockThreshold();
            Int32 taskBufferSize = _iFormWebCrawler.GetTaskBufferSize();
            Int32 timeout = _iFormWebCrawler.GetTimeout();
            Int32 updateIntervalBreak = _iFormWebCrawler.GetUpdateIntervalBreak();

            nudDepth.Value = depth;
            nudInstances.Value = instances;
            nudMaxTasks.Value = maxTasks;
            nudNoTaskIntervalBreak.Value = noTaskIntervalBreak;
            nudRetries.Value = retries;
            nudTaskRestockThreshold.Value = taskRestockThreshold;
            nudTasksBufferSize.Value = taskBufferSize;
            nudTimeout.Value = timeout;
            nudUpdateIntervalBreak.Value = updateIntervalBreak;
        }

        private void FormWebCrawler_Load(Object sender, EventArgs e)
        {
            dgvInstanceInfo.AutoGenerateColumns = false;
            dgvInstanceInfo.RowTemplate.Height = 20;
        }

        private void btnStart_Click(Object sender, EventArgs e)
        {
            String inputUri = txtUri.Text.Trim();

            if (_iFormWebCrawler.ValidateUri(inputUri))
            {
                _settingsControls.ForEach(x => x.Enabled = false);

                Uri uri = new Uri(inputUri);

                Int32 depth = Int32.Parse(nudDepth.Value.ToString(CultureInfo.InvariantCulture));
                Int32 instances = Int32.Parse(nudInstances.Value.ToString(CultureInfo.InvariantCulture));
                Int32 maxTasks = Int32.Parse(nudMaxTasks.Value.ToString(CultureInfo.InvariantCulture));
                Int32 noTaskIntervalBreak =
                    Int32.Parse(nudNoTaskIntervalBreak.Value.ToString(CultureInfo.InvariantCulture));
                Int32 retries = Int32.Parse(nudRetries.Value.ToString(CultureInfo.InvariantCulture));
                Int32 taskRestockThreshold =
                    Int32.Parse(nudTaskRestockThreshold.Value.ToString(CultureInfo.InvariantCulture));
                Int32 taskBufferSize = Int32.Parse(nudTasksBufferSize.Value.ToString(CultureInfo.InvariantCulture));
                Int32 timeout = Int32.Parse(nudTimeout.Value.ToString(CultureInfo.InvariantCulture));
                Int32 updateIntervalBreak =
                    Int32.Parse(nudUpdateIntervalBreak.Value.ToString(CultureInfo.InvariantCulture));

                _iFormWebCrawler.SetDepth(depth);
                _iFormWebCrawler.SetInstances(instances);
                _iFormWebCrawler.SetMaxTasks(maxTasks);
                _iFormWebCrawler.SetNoTaskIntervalBreak(noTaskIntervalBreak);
                _iFormWebCrawler.SetRetries(retries);
                _iFormWebCrawler.SetTaskRestockThreshold(taskRestockThreshold);
                _iFormWebCrawler.SetTaskBufferSize(taskBufferSize);
                _iFormWebCrawler.SetTimeout(timeout);
                _iFormWebCrawler.SetUpdateIntervalBreak(updateIntervalBreak);

                _iFormWebCrawler.StartCrawling(uri);
                UpdateGui();
            }
            else
            {
                MessageBox.Show(Resources.Url_does_not_match_allowed_format_, Resources.WebCrawler,
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnStop_Click(Object sender, EventArgs e)
        {
            btnStop.Enabled = false;

            new Thread(new ThreadStart(delegate
            {
                FormStop formStop = new FormStop();
                formStop.Show();
                Application.DoEvents();

                _iFormWebCrawler.StopCrawling();

                formStop.Close();
            })).Start();
        }

        private void UpdateGui()
        {
            lblLinksSavedCount.Text = String.Format("Links crawled: {0}", _iFormWebCrawler.GetLinksCrawledCount());

            IEnumerable<Tuple<Int32, Boolean, Int32>> crawlingInstanceInformation =
                _iFormWebCrawler.GetCrawlingInstanceInformation();

            DataTable dt = new DataTable();
            dt.Columns.Add("Status", typeof(Bitmap));
            dt.Columns.Add("Instance", typeof(String));
            dt.Columns.Add("Tasks", typeof(Int32));

            foreach (Tuple<Int32, Boolean, Int32> info in crawlingInstanceInformation)
            {
                DataRow row = dt.NewRow();

                row["Status"] = info.Item2 ? Resources.ball_green : Resources.ball_gray;
                row["Instance"] = "Instance " + info.Item1;
                row["Tasks"] = info.Item3;

                dt.Rows.Add(row);
            }

            dgvInstanceInfo.DataSource = dt;

            Boolean isCrawlerRunning = _iFormWebCrawler.IsCrawlerRunning();

            btnStart.Enabled = !isCrawlerRunning;
            btnStop.Enabled = isCrawlerRunning;
            _settingsControls.ForEach(x => x.Enabled = !isCrawlerRunning);

            if (!isCrawlerRunning && guiUpdateTimer.Enabled)
            {
                guiUpdateTimer.Enabled = false;
            }
            if (isCrawlerRunning && !guiUpdateTimer.Enabled)
            {
                guiUpdateTimer.Enabled = true;
            }
        }

        private void guiUpdateTimer_Tick(Object sender, EventArgs e)
        {
            UpdateGui();
        }

        private void FormWebCrawler_FormClosing(Object sender, FormClosingEventArgs e)
        {
            btnStop.PerformClick();
            Environment.Exit(0);
        }

        private void nudInterfaceUpdateInterval_ValueChanged(Object sender, EventArgs e)
        {
            guiUpdateTimer.Interval =
                Int32.Parse(nudInterfaceUpdateInterval.Value.ToString(CultureInfo.InvariantCulture));
        }
    }
}