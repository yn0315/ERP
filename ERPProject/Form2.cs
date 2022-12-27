using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace ERPProject
{
    public partial class Form2 : Form
    {
        static Form frn;
        static DirectoryInfo dtif = new DirectoryInfo(Application.StartupPath + "../../../../" + "\\Database");
        string strdtif = dtif.FullName;
        static DirectoryInfo dp = new DirectoryInfo(dtif + "\\직원관리" + "\\인사팀"+"\\");
        static DirectoryInfo dp1 = new DirectoryInfo(dtif + "\\직원관리" + "\\재무팀"+"\\");
        static DirectoryInfo dp2 = new DirectoryInfo(dtif + "\\직원관리" + "\\재고팀" + "\\");
        static DirectoryInfo dp3 = new DirectoryInfo(dtif + "\\직원관리" + "\\서비스팀" + "\\");
        
        public Form2()
        {
            InitializeComponent();
            textBox77.Text = DateTime.Now.ToString("yy.MM.dd"); //포상 날짜
            textBox79.Text = DateTime.Now.ToString("yy.MM.dd"); //징계 날짜
            textBox95.Text = DateTime.Now.ToString("yy.MM.dd"); //평가관리 날짜
            string Years = DateTime.Now.ToString("yyyy");
            //grideShow();
        }

        

        private void textBox124_TextChanged(object sender, EventArgs e)
        {
            //사원관리 검색 텍스트
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //사원관리 검색 완료
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //사원관리
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //사원관리 선택버튼
            panel23.Visible= true;
            panel23.BringToFront();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox5.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox5.Text = strTemp;
            textBox5.Select(textBox5.Text.Length, 0); //offset 이동
            textBox5.Focus();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            panel23.Visible= false;
            //사원 개인정보 팝업 등록 버튼
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 사번
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 이름
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 직책
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 연락처
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 픽쳐박스
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible= false;
            //사원 개인정보 팝업 등록 버튼
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 이름
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 사원번호
        }
        private void textBox131_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 부서
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 1주차
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 2주차
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 3주차
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 4주차
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 종류
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 신청일
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 팝업 허가일
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //사원 개인정보 근무통계 버튼
            panel6.Visible= true;
            panel6.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel23.Visible= true;
            panel23.BringToFront();
            //사원개인정보 버튼
        }
        private void button39_Click(object sender, EventArgs e)
        {
            //사원등록 버튼
            panel58.Visible = true;
            panel58.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel6.Visible= true;
            panel6.BringToFront();
            //근무 통계 버튼
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frn.Visible = true;
            this.Close();
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox30.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox30.Text = strTemp;
            textBox30.Select(textBox30.Text.Length, 0); //offset 이동
            textBox30.Focus();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //사원관리 지급내역서 팝업 완료
            panel8.Visible= false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //지급내역서 버튼
            panel8.Visible = true;
            panel8.BringToFront();
        }

        private void textBox50_TextChanged(object sender, EventArgs e)
        {
            //지급내역서 팝업 사번
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            //지급내역서 팝업 이름
        }

        private void textBox48_TextChanged(object sender, EventArgs e)
        {
            //지급내역서 팝업 부서
        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            //지급내역서 팝업 직책
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //지급내역서 팝업 이번달급여
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //지급내역서 팝업 지급내역
        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {
            //인사발령통지서 팝업 사번
        }

        private void textBox53_TextChanged(object sender, EventArgs e)
        {
            //인사발령통지서 팝업 이름
        }

        private void textBox56_TextChanged(object sender, EventArgs e)
        {
            //인사발령통지서 팝업 부서
        }

        private void textBox46_TextChanged(object sender, EventArgs e)
        {
            //인사발령통지서 팝업 직책
        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            //인사발령통지서 팝업 발령이유 텍스트
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel11.Visible= false;
            //인사발령통지서 팝업 등록
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel11.Visible= true;
            panel11.BringToFront();
            //인사발령통지서 버튼
        }
        private void button38_Click(object sender, EventArgs e)
        {
            panel58.Visible = false;
            //사원등록 팝업 등록버튼
            string message = string.Empty;
            //message = string.Format($"{textBox138}{textBox145}{textBox137}{textBox134}{textBox142}{textBox141}");
            //TextGenerate(dp,textBox134.Text, textBox138.Text.ToString());
            //WriteText();
            textSave();
            
        }
       

        private void textBox138_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 사번

        }

        private void textBox145_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 생년월일 < 비밀번호역할
        }

        private void textBox137_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 이름
        }

        private void textBox134_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 부서
        }

        private void textBox142_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 직책
        }

        private void textBox141_TextChanged(object sender, EventArgs e)
        {
            //사원등록 팝업 연락처
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel14.BringToFront();
            //왼쪽 일용직관리 버튼
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //왼쪽 사원관리 버튼
            panel46.BringToFront();
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            //일용직관리 검색 텍스트
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //일용직관리 완료 버튼
        }

        private void button45_Click_1(object sender, EventArgs e)
        {
            //일용직관리 선택버튼
            panel17.Visible= true;
            panel17.BringToFront();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //일용직직원 고용 팝업 등록버튼
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel17.Visible = false;
            //일용직직원 고용 팝업 확인
        }

        private void button22_Click(object sender, EventArgs e)
        {
            panel21.BringToFront();
            //포상/징계 포상관리 버튼
        }

        private void textBox77_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox74_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 사번
        }

        private void textBox75_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 부서
        }

        private void textBox70_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 이름
        }

        private void textBox69_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 직책
        }

        private void textBox68_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 신청인 이름
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //포상/징계 포상관리 팝업 등록버튼
            panel25.Visible= false;
        }

        private void textBox64_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox64.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox64.Text = strTemp;
            textBox64.Select(textBox64.Text.Length, 0); //offset 이동
            textBox64.Focus();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel25.Visible= true;
            panel25.BringToFront();
            //포상관리 선택 버튼
        }

        private void button23_Click(object sender, EventArgs e)
        {
            panel31.BringToFront();
            //징계관리버튼
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //포상/징계 징계관리
            

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //포상/징계 포상관리 그리드뷰
        }

        private void button25_Click(object sender, EventArgs e)
        {
            panel28.BringToFront();
            panel28.Visible= true;
            //포상/징계 징계관리 선택버튼
        }

        private void textBox90_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 징계관리 팝업 사번
        }

        private void textBox86_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 징계관리 팝업 이름
        }

        private void textBox89_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 징계관리 팝업 부서
        }

        private void textBox85_TextChanged(object sender, EventArgs e)
        {
            //포상/징계 징계관리 팝업 직책
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //포상/징계 징계관리 팝업 등록버튼
            panel28.Visible = false;
        }

        private void textBox83_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox83.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox83.Text = strTemp;
            textBox83.Select(textBox83.Text.Length, 0); //offset 이동
            textBox83.Focus();
        }

        private void textBox79_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //평가 관리 그리드뷰
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel20.BringToFront();
            //왼쪽 포상/징계 관리
        }

        private void button16_Click(object sender, EventArgs e)
        {
            panel33.BringToFront();
            //왼쪽 평가관리 버튼
        }

        private void button26_Click(object sender, EventArgs e)
        {
            panel38.Visible= true;
            panel38.BringToFront();
            //평가관리 선택 버튼
        }

        private void textBox106_TextChanged(object sender, EventArgs e)
        {
            //평가관리 팝업 사번
        }

        private void textBox102_TextChanged(object sender, EventArgs e)
        {
            //평가관리 팝업 이름
        }

        private void textBox105_TextChanged(object sender, EventArgs e)
        {
            //평가관리 팝업 부서
        }

        private void textBox101_TextChanged(object sender, EventArgs e)
        {
            //평가관리 팝업 직책
        }

        private void textBox96_TextChanged(object sender, EventArgs e)
        {
            //평가관리 팝업 등록인
        }

        private void button27_Click(object sender, EventArgs e)
        {
            panel38.Visible= false;
            //평가관리 팝업 등록

        }

        private void textBox95_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox99_TextChanged(object sender, EventArgs e)
        {
            int a = 20;
            string strTemp = textBox99.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox99.Text = strTemp;
            textBox99.Select(textBox99.Text.Length, 0); //offset 이동
            textBox99.Focus();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            panel42.BringToFront();
            //왼쪽 급여명세서 등록 버튼
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //급여 명세서 그리드뷰
        }

        private void textBox122_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 사번
        }

        private void textBox118_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 이름
        }

        private void textBox121_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 부서
        }

        private void textBox117_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 직책
        }

        private void button30_Click(object sender, EventArgs e)
        {
            panel50.Visible= true;
            panel50.BringToFront();
            //급여명세서 선택버튼
        }

        private void textBox115_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 지금 공제내역 텍박
        }

        private void textBox111_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 지급일 텍ㄷ박
        }

        private void textBox112_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 신청일 이름
        }

        private void textBox129_TextChanged(object sender, EventArgs e)
        {
            //급여명세서 팝업 계좌번호
        }

        private void button33_Click(object sender, EventArgs e)
        {
            panel50.Visible= false;
            //등록버튼
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel53.BringToFront();
            //왼쪽 인사관리 버튼
        }


        
        //다이얼로그 기본 정보 정의
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //일용직 그리드뷰
        }

        private void dataGridView11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //사원관리 그리드뷰
          
        }
   
        private void button40_Click(object sender, EventArgs e)////////////////////텍스트박스 그리드뷰에 옴기는 버튼
        {
            //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 주소를 배열에 저장
            //인사관리 불러오기 버튼
            //grideShow();


        }

        /*
        private void grideShow() // 각 폴더안의 모든 텍스트파일 그리드뷰에 넣기
        {
            
            string[] allfiles = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "인사팀", "*.*", SearchOption.AllDirectories);
            string[] allfiles1 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "재무팀", "*.*", SearchOption.AllDirectories);
            string[] allfiles2 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "재고팀", "*.*", SearchOption.AllDirectories);
            string[] allfiles3 = Directory.GetFiles(dtif + "\\" + "직원관리" + "\\" + "서비스팀", "*.*", SearchOption.AllDirectories);

            //table 선언
            DataTable table = new DataTable();
            //가맹점별 현황 그리드뷰

            //그리드 뷰 table 헤드 추가
            table.Columns.Add("사원번호", typeof(string));
            table.Columns.Add("생년월일", typeof(string));
            table.Columns.Add("이 름", typeof(string));
            table.Columns.Add("부 서", typeof(string));
            table.Columns.Add("직급", typeof(string));
            table.Columns.Add("전화번호", typeof(string));

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복
            
            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    //조건 : 배열이 null이 아니면
                    if (line != null)
                    {
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        table.Rows.Add(line.Split('\t'));
                    }

                }
            }

            for (int i = 0; i < allfiles1.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles1[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    //조건 : 배열이 null이 아니면
                    if (line != null)
                    {
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        table.Rows.Add(line.Split('\t'));
                    }

                }
            }
            for (int i = 0; i < allfiles2.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles2[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    //조건 : 배열이 null이 아니면
                    if (line != null)
                    {
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        table.Rows.Add(line.Split('\t'));
                    }

                }
            }
            for (int i = 0; i < allfiles3.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles3[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    //조건 : 배열이 null이 아니면
                    if (line != null)
                    {
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        table.Rows.Add(line.Split('\t'));
                    }

                }
            }
            //table.Rows.Add로 추가한 내용을 띄우고 싶은 그리드 뷰에 뿌리기
            dataGridView11.DataSource = table;
        }
        */
        private void textSave() //직원생성 함수
        {
            StreamWriter writer_;
            string strFilePath =dp + textBox138.Text + ".txt"; // 저장할위치 + 저장할 텍스트이름
            string strFilePath1 = dp1 + textBox138.Text + ".txt";
            string strFilePath2 = dp2 +  textBox138.Text + ".txt";
            string strFilePath3 = dp3 +  textBox138.Text + ".txt";

            if (textBox134.Text == "인사팀")
            {
                writer_ = File.CreateText(strFilePath);
                writer_.Write(textBox138.Text + "\t" +
                    textBox145.Text + "\t" +
                    textBox137.Text + "\t" +
                    textBox134.Text + "\t" +
                    textBox142.Text + "\t" +
                    textBox141.Text );
                writer_.Close();
                writer_.Dispose();
            
            
            }
            else if (textBox134.Text == "재무팀")
            {
                writer_ = File.CreateText(strFilePath1);
                writer_.Write(textBox138.Text + "\t" +
                    textBox145.Text + "\t" +
                    textBox137.Text + "\t" +
                    textBox134.Text + "\t" +
                    textBox142.Text + "\t" +
                    textBox141.Text );
                writer_.Close();
                writer_.Dispose();

            }

            else if (textBox134.Text == "재고팀")
            {
                writer_ = File.CreateText(strFilePath2);
                writer_.Write(textBox138.Text + "\t" +
                    textBox145.Text + "\t" +
                    textBox137.Text + "\t" +
                    textBox134.Text + "\t" +
                    textBox142.Text + "\t" +
                    textBox141.Text );
                writer_.Close();
                writer_.Dispose();

            }

            else if (textBox134.Text == "서비스팀")
            {
                writer_ = File.CreateText(strFilePath3);
                writer_.Write(textBox138.Text + "\t" +
                    textBox145.Text + "\t" +
                    textBox137.Text + "\t" +
                    textBox134.Text + "\t" +
                    textBox142.Text + "\t" +
                    textBox141.Text );
                writer_.Close();
                writer_.Dispose();

            }
            else
            {

            }
        }
     
        private void button37_Click_1(object sender, EventArgs e)
        {
            //사원관리 삭제버튼
            TextFileDelete();
        }

        private void TextFileDelete() // 그리드뷰에서 선택 텍스트파일 삭제 함수
        {
            int rowindex = dataGridView11.CurrentRow.Index;

            string RowIndexSelectElementName = dataGridView11.Rows[rowindex].Cells[0].Value.ToString();
            string RowIndexSelectElement = dataGridView11.Rows[rowindex].Cells[3].Value.ToString();

            //textBox152.Text = RowIndexSelectElement;

            string dtif = dp + RowIndexSelectElementName + ".txt";
            string dtif1 = dp1 + RowIndexSelectElementName + ".txt";
            string dtif2 = dp2 + RowIndexSelectElementName + ".txt";
            string dtif3 = dp3 + RowIndexSelectElementName + ".txt";
            if (RowIndexSelectElement == "인사팀" )
            {
                //textBox147.Text = dtif;
                File.Delete(dtif);
                //grideShow();
            }
            else if (RowIndexSelectElement == "재무팀")
            {
                File.Delete(dtif1);
                //grideShow();
            }
            else if (RowIndexSelectElement == "재고팀")
            {
                File.Delete(dtif2);
                //grideShow();
            }
            else if (RowIndexSelectElement == "서비스팀")
            {
                File.Delete(dtif3);
                //grideShow();
            }
        }

    }
}
