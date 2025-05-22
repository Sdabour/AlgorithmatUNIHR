
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using SharpVision.SystemBase;
namespace AlgorithmatMN.MN.MNReport
{
    public partial class frmDisplayReport : Form
    {
        public frmDisplayReport()
        {
            InitializeComponent();
            //ReportViewer.ShowExportButton = SysData.UMSExportToExcelAuthorisd;

        }

        private void frmDisplayReport_Load(object sender, EventArgs e)
        {
            //ReportClass objRep = (ReportClass)ReportViewer.ReportSource;
            //PictureObject objPic =(PictureObject) objRep.ReportDefinition.ReportObjects["Picture1"];



        }
    }
}
