using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPProject
{
    public partial class Form1 : Form
    {
        string department;
        
        static DirectoryInfo dtif = new DirectoryInfo(Application.StartupPath + "../../../../" + "\\Database");
        string strdtif = dtif.FullName;
        static DirectoryInfo dp = new DirectoryInfo(dtif + "\\직원관리" + "\\인사팀" + "\\");
        static DirectoryInfo dp1 = new DirectoryInfo(dtif + "\\직원관리" + "\\재무팀" + "\\");
        static DirectoryInfo dp2 = new DirectoryInfo(dtif + "\\직원관리" + "\\재고팀" + "\\");
        static DirectoryInfo dp3 = new DirectoryInfo(dtif + "\\직원관리" + "\\서비스팀" + "\\");

        public Form1()
        {
            DirectoryInfo dp = new DirectoryInfo(dtif + "\\직원관리");
            DirectoryInfo em = new DirectoryInfo(dp + "\\인사팀");
            DirectoryInfo fn = new DirectoryInfo(dp + "\\재무팀");
            DirectoryInfo st = new DirectoryInfo(dp + "\\재고팀");
            DirectoryInfo sv = new DirectoryInfo(dp + "\\서비스팀");

            InitializeComponent();

            
        }

        private void findText()
        {
           
            try
            {
                Form2 frm2 = new Form2();

                Form4 frm4 = new Form4();

                Form5 frm5 = new Form5();

                string[] allfiles = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "인사팀", "*.*", SearchOption.AllDirectories);
                string[] allfiles1 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "재무팀", "*.*", SearchOption.AllDirectories);
                string[] allfiles2 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "재고팀", "*.*", SearchOption.AllDirectories);
                string[] allfiles3 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "서비스팀", "*.*", SearchOption.AllDirectories);

                if (allfiles.Contains(textBox1.Text) == true)
                {
                    this.Visible = false;
                    frm2.Visible = true;

                }

                else if (allfiles1.Contains(textBox1.Text) == true)
                {
                    this.Visible = false;
                    frm2.Visible = true;

                }
                else if (allfiles2.Contains(textBox1.Text) == true)
                {
                    this.Visible = false;
                    frm4.Visible = true;

                }
                else if (allfiles3.Contains(textBox1.Text) == true)
                {
                    this.Visible = false;
                    frm5.Visible = true;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            
        }

        
        //부서확인함수
        

        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();

            Form4 frm4 = new Form4();

            Form5 frm5 = new Form5();

            frm4.Visible = true;
            this.Visible = false;
            //findText();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
