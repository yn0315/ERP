using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace ERPProject
{
    public partial class Form4 : Form
    {
        static DirectoryInfo dtif = new DirectoryInfo(Application.StartupPath + "../../../../" + "\\Database");
        string strdtif = dtif.FullName;
        string originalFileName;//수정시 원본 파일네임변수



        Form frn;
        Form1 frm1;

        //슬라이딩 메뉴의 최대, 최소 폭 크기
        const int MAX_SLIDING_WIDTH = 152;
        const int MIN_SLIDING_WIDTH = 10;
        //슬라이딩 메뉴가 보이는/접히는 속도 조절
        const int STEP_SLIDING = 1;
        //최초 슬라이딩 메뉴 크기
        int _posSliding = 152;
        int LineLimitSizea = 30;// 발주 텍스트박스 최대길이 

        public Form4()
        {
            DirectoryInfo dp = new DirectoryInfo(dtif + "\\직원관리");
            DirectoryInfo store = new DirectoryInfo(dp + "\\재고팀" + "\\가맹점");
            DirectoryInfo warehouse = new DirectoryInfo(dp + "\\재고팀" + "\\창고");
            DirectoryInfo orderFolder = new DirectoryInfo(dp + "\\재고팀" + "\\발주");
            DirectoryInfo stateMonth = new DirectoryInfo(dp + "\\재고팀" + "\\월별수불현황");
            DirectoryInfo orderGoods = new DirectoryInfo(dp + "\\재고팀" + "\\입고품목");
            DirectoryInfo repairGoods = new DirectoryInfo(dp + "\\재고팀" + "\\수리입고품목");
            store.Create();
            warehouse.Create();
            orderFolder.Create();
            orderGoods.Create();
            stateMonth.Create();
            repairGoods.Create();
            InitializeComponent();
            IniEvent();
            textBox45.Text = DateTime.Now.ToString("yy.MM.dd"); //발주등록
            textBox80.Text = DateTime.Now.ToString("yy.MM.dd"); //입고등록
            textBox99.Text = DateTime.Now.ToString("yy.MM.dd"); //지급관리 텍스트
            textBox133.Text = DateTime.Now.ToString("yy.MM.dd"); //수리등록

        }
        private void IniEvent()
        {
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Gradient);
            this.uiPanel_Main.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Gradient);
            //this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Gradient);
        }

        public void Form_Gradient(object sender, PaintEventArgs e)
        {
            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, Color.DarkTurquoise, Color.DarkTurquoise, 0, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }
        private void Panel_Gradient(object sender, PaintEventArgs e)
        {
            Color startColor = System.Drawing.ColorTranslator.FromHtml("#e0c3fc");
            Color middleColor = System.Drawing.ColorTranslator.FromHtml("#8ec5fc");
            Color endColor = Color.FromArgb(0, 0, 0);

            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, System.Drawing.Color.Black, System.Drawing.Color.Black, 0, false);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }
        private void panel_Gradient(object sender, PaintEventArgs e)
        {
            Color startColor = System.Drawing.ColorTranslator.FromHtml("#e0c3fc");
            Color middlecolor = System.Drawing.ColorTranslator.FromHtml("#8ec5fc");
            Color endColor = Color.FromArgb(0, 0, 0);

            LinearGradientBrush br = new LinearGradientBrush(this.ClientRectangle, System.Drawing.Color.Black, System.Drawing.Color.Black, 0, false);

            ColorBlend cb = new ColorBlend();
            cb.Positions = new[] { 0, 1 / 2f, 1 };
            cb.Colors = new[] { startColor, middlecolor, endColor };

            br.InterpolationColors = cb;
            br.RotateTransform(45);
            e.Graphics.FillRectangle(br, this.ClientRectangle);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frn.Visible = true;
            this.Close();
            //로그아웃버튼
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
            //가맹점별 현황 버튼
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //가맹점별 현황 그리드뷰
            
        }
        private void SearchinGrid1(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성
            
            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀\\가맹점" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\가맹점", "*.*", SearchOption.AllDirectories);

            gridShowStore();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복
            
            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == TextName)
                        {
                            dataGridView1.Rows.Add(arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                    }

                }
            
            }
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //가맹점별 현황 검색텍스트
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //가맹점별 현황 검색확인버튼
            SearchinGrid1(textBox2.Text.ToString());
        }
        //가맹점별 현황 컬럼 추가
        private void gridShowStore()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("매장명", "매장명");
            dataGridView1.Columns.Add("품목코드", "품목코드");
            dataGridView1.Columns.Add("품목명", "품목명");
            dataGridView1.Columns.Add("입고수량", "입고수량");
            dataGridView1.Columns.Add("출고수량", "출고수량");
            dataGridView1.Columns.Add("재고수량", "재고수량");
           
        }
        private void grideShow1(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //가맹점별 현황 그리드뷰

            //그리드 뷰 table 헤드 추가
            gridShowStore();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };
            

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
    
                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView1.Rows.Add(line.Split('\t'));
                        
                    }

                }
                //gridShowStore();
                dataGridView1.Rows.Add(result[1], result[2], result[3], result[4], result[5], result[6]);
                

            }

         
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //가맹점별 현황 확인버튼
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\가맹점", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowStore();
            }
            else
            {
                
                grideShow1("\\가맹점");
            }
        }
        public void TextGenerate(object Basedtif, string FolderName, string TextName)
        {
            FileInfo file = new FileInfo(Basedtif + "\\직원관리\\재고팀" + FolderName + "\\" + TextName + ".txt");
            //text 생성 
            FileStream stream = File.Create(file.FullName);

            if (!file.Exists)
            {
                file.Create();
            }
            stream.Close();
        }

        private void GridCutView1(string folderName)
        {
            //지금 폼의 그리드뷰가 비었으면 함수를 나간다
            if (this.dataGridView1.RowCount == 0)
            {
                return;
            }

            //주소와 매개변수로 준 폴더 이름 저장
            string fullName = dtif + "\\직원관리\\재고팀" + folderName;

            //반복문을 이용하여 그리드 뷰의 한개의 열의 내용을 가져온다
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                try
                {
                    //그리드 뷰의 끝 지점인지 판단
                    if (!row.IsNewRow == true)
                    {

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열로된 *.txt 문서 생성
                        TextGenerate(dtif, folderName, row.Cells[0].Value.ToString());

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열을 문자열로 저장
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + folderName + "\\" + row.Cells[0].Value.ToString() + ".txt";

                        //파일 주소 저장
                        FileInfo file = new FileInfo(Absoluteposition);

                        //파일에 쓰기 위해서 StreamWriter 로 파일주소 찾아가기
                        StreamWriter sw = new StreamWriter(file.FullName);

                        sw.Write(DateTime.Now.Month.ToString() + '\t');
                        
                        //반복목을 통하여 row컬랙션의 길이 만큼 반복
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //row 컬랙션이 문자열이라 숫자열로 변환
                            int a = Int32.Parse(row.Cells.Count.ToString());

                            //*.txt에 저장 할때 마지막 "\t"를 제거 하기 위한 조건식
                            //마지막 "\t"을 짜르기 위한 조건식
                            if (i == a - 1)
                            {
                                //조건이 맞으면 문자열만 *.txt 에 추가
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                //조건이 맞지 않으면 *.txt 에 "\t"를 붙여서 추가
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                        }
                        //열었던 파일 닫기
                        sw.Close();
                        //파일의 리소스 해제
                        sw.Dispose();
                    }
                    // else 문은 위의 if 문과 동일
                    else
                    {
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + folderName + "\\" + row.Cells[0].Value.ToString() + ".txt";
                        FileInfo file = new FileInfo(Absoluteposition);
                        StreamWriter sw = new StreamWriter(file.FullName);
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //sw.Write(DateTime.Now + "\t");
                            int a = Int32.Parse(row.Cells.Count.ToString());
                            if (i == a - 1)
                            {
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                            //sw.Write(row.Cells[i].Value+"\t");
                        }
                        sw.Close();
                        sw.Dispose();
                    }
                }
                catch
                {

                }
            }

        }
        private void button60_Click(object sender, EventArgs e)
        {
            //가맹점별 현황 저장버튼
            GridCutView1("\\가맹점");
        }


        private void button8_Click(object sender, EventArgs e)
        {
            //가맹점별 현황 삭제버튼


            int rowindex = dataGridView1.CurrentRow.Index;
            string RowIndexSelectElement = "";

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    RowIndexSelectElement= dataGridView1.Rows[i].Cells[0].Value.ToString();
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                }
            }

            //string RowIndexSelectElement = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            string dtif = strdtif + "\\직원관리\\재고팀\\가맹점" + "\\" + RowIndexSelectElement + ".txt";
            
            File.Delete(dtif);


        }

        private void gridShowStoreModify()
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Columns.Add("매장명", "매장명");
            dataGridView2.Columns.Add("품목코드", "품목코드");
            dataGridView2.Columns.Add("품목명", "품목명");
            dataGridView2.Columns.Add("입고수량", "입고수량");
            dataGridView2.Columns.Add("출고수량", "출고수량");
            dataGridView2.Columns.Add("재고수량", "재고수량");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected == true)
                {
                    originalFileName = dataGridView1.Rows[i].Cells[0].Value.ToString();//파일네임변수에 원본 데이터의 0번째 인덱스(품목코드)를 넣어준다.

                    dataGridView2.Rows.Add(
                        dataGridView1.Rows[i].Cells[0].Value,
                        dataGridView1.Rows[i].Cells[1].Value,
                        dataGridView1.Rows[i].Cells[2].Value,
                        dataGridView1.Rows[i].Cells[3].Value,
                        dataGridView1.Rows[i].Cells[4].Value,
                        dataGridView1.Rows[i].Cells[5].Value
                        );
                }
            }
            


        }

        
        private void button7_Click(object sender, EventArgs e)
        {
            //가맹점별 현황 수정버튼
            panel6.BringToFront();
            panel6.Visible = true;
            
            gridShowStoreModify();
            

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //가맹점별 현황 수정 그리드뷰
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
            panel6.Visible= false;

            //가맹점별 현황 그리드뷰 안에 수정 버튼
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                try
                {
                    //그리드 뷰의 끝 지점인지 판단
                    if (!row.IsNewRow == true)
                    {

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열을 문자열로 저장
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + "\\가맹점" + "\\" + row.Cells[0].Value.ToString() + ".txt";

                        //파일 주소 저장
                        FileInfo file = new FileInfo(Absoluteposition);

                        //파일에 쓰기 위해서 StreamWriter 로 파일주소 찾아가기
                        StreamWriter sw = new StreamWriter(file.FullName);

                        sw.Write(DateTime.Now.Month.ToString() + '\t');

                        //반복목을 통하여 row컬랙션의 길이 만큼 반복
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //row 컬랙션이 문자열이라 숫자열로 변환
                            int a = Int32.Parse(row.Cells.Count.ToString());

                            //*.txt에 저장 할때 마지막 "\t"를 제거 하기 위한 조건식
                            //마지막 "\t"을 짜르기 위한 조건식
                            if (i == a - 1)
                            {
                                //조건이 맞으면 문자열만 *.txt 에 추가
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                //조건이 맞지 않으면 *.txt 에 "\t"를 붙여서 추가
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                        }
                        //열었던 파일 닫기
                        sw.Close();
                        //파일의 리소스 해제
                        sw.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end foreach


            

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
          
        }
        private void SearchinGrid3(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀\\창고" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\창고", "*.*", SearchOption.AllDirectories);

            gridShowWarehouse();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] ==TextName)
                        {
                            dataGridView3.Rows.Add(arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                    }

                }

            }

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //창고별 현황 검색 텍스트 버튼
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //창고별 현황 검색 확인 버튼
            SearchinGrid3(textBox6.Text.ToString());
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //창고별 현황 그리드 뷰
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //창고별 현황 삭제 버튼


            int rowindex = dataGridView3.CurrentRow.Index;
            string RowIndexSelectElement = "";

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Selected == true)
                {
                    RowIndexSelectElement = dataGridView3.Rows[i].Cells[0].Value.ToString();
                    dataGridView3.Rows.Remove(dataGridView3.Rows[i]);
                }
            }

            //string RowIndexSelectElement = dataGridView1.Rows[rowindex].Cells[0].Value.ToString();

            string dtif = strdtif + "\\직원관리\\재고팀\\창고" + "\\" + RowIndexSelectElement + ".txt";

            File.Delete(dtif);
        }

        private void gridShowWarehouseModify()
        {
            dataGridView4.Columns.Clear();
            dataGridView4.Columns.Add("창고명", "창고명");
            dataGridView4.Columns.Add("품목코드", "품목코드");
            dataGridView4.Columns.Add("품목명", "품목명");
            dataGridView4.Columns.Add("입고수량", "입고수량");
            dataGridView4.Columns.Add("출고수량", "출고수량");
            dataGridView4.Columns.Add("재고수량", "재고수량");
            string RowIndexSelectElement = "";

            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                if (dataGridView3.Rows[i].Selected == true)
                {

                    dataGridView4.Rows.Add(
                        dataGridView3.Rows[i].Cells[0].Value,
                        dataGridView3.Rows[i].Cells[1].Value,
                        dataGridView3.Rows[i].Cells[2].Value,
                        dataGridView3.Rows[i].Cells[3].Value,
                        dataGridView3.Rows[i].Cells[4].Value,
                        dataGridView3.Rows[i].Cells[5].Value
                        );
                }
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //창고별 현황 수정 버튼
            panel11.BringToFront();
            panel11.Visible = true;
            gridShowWarehouseModify();
        }

        //창고별현황 컬럼명 추가
        private void gridShowWarehouse()
        {
            dataGridView3.Columns.Clear();
            dataGridView3.Columns.Add("창고명", "창고명");
            dataGridView3.Columns.Add("품목코드", "품목코드");
            dataGridView3.Columns.Add("품목명", "품목명");
            dataGridView3.Columns.Add("입고수량", "입고수량");
            dataGridView3.Columns.Add("출고수량", "출고수량");
            dataGridView3.Columns.Add("재고수량", "재고수량");

        }

        private void grideShow3(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowWarehouse();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }
                
                dataGridView3.Rows.Add(result[1], result[2], result[3], result[4], result[5], result[6]);


            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //창고별 현황 확인 버튼
            
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\창고", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowWarehouse();
            }
            else
            {
                gridShowWarehouse();
                grideShow3("\\창고");
            }

        }
        private void GridCutView3(string folderName)
        {
            //지금 폼의 그리드뷰가 비었으면 함수를 나간다
            if (this.dataGridView3.RowCount == 0)
            {
                return;
            }

            //주소와 매개변수로 준 폴더 이름 저장
            string fullName = dtif + "\\직원관리\\재고팀" + folderName;

            //반복문을 이용하여 그리드 뷰의 한개의 열의 내용을 가져온다
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                try
                {
                    //그리드 뷰의 끝 지점인지 판단
                    if (!row.IsNewRow == true)
                    {

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열로된 *.txt 문서 생성
                        TextGenerate(dtif, folderName, row.Cells[0].Value.ToString());

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열을 문자열로 저장
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + folderName + "\\" + row.Cells[0].Value.ToString() + ".txt";

                        //파일 주소 저장
                        FileInfo file = new FileInfo(Absoluteposition);

                        //파일에 쓰기 위해서 StreamWriter 로 파일주소 찾아가기
                        StreamWriter sw = new StreamWriter(file.FullName);
                        sw.Write(DateTime.Now.Month.ToString() + '\t');
                        //반복목을 통하여 row컬랙션의 길이 만큼 반복
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //row 컬랙션이 문자열이라 숫자열로 변환
                            int a = Int32.Parse(row.Cells.Count.ToString());

                            //*.txt에 저장 할때 마지막 "\t"를 제거 하기 위한 조건식
                            //마지막 "\t"을 짜르기 위한 조건식
                            if (i == a - 1)
                            {
                                //조건이 맞으면 문자열만 *.txt 에 추가
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                //조건이 맞지 않으면 *.txt 에 "\t"를 붙여서 추가
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                        }
                        //열었던 파일 닫기
                        sw.Close();
                        //파일의 리소스 해제
                        sw.Dispose();
                    }
                    // else 문은 위의 if 문과 동일
                    else
                    {
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + folderName + "\\" + row.Cells[0].Value.ToString() + ".txt";
                        FileInfo file = new FileInfo(Absoluteposition);
                        StreamWriter sw = new StreamWriter(file.FullName);
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //sw.Write(DateTime.Now + "\t");
                            int a = Int32.Parse(row.Cells.Count.ToString());
                            if (i == a - 1)
                            {
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                            //sw.Write(row.Cells[i].Value+"\t");
                        }
                        sw.Close();
                        sw.Dispose();
                    }
                }
                catch
                {

                }
            }

        }
        private void button56_Click(object sender, EventArgs e)
        {
            //창고별현황 저장버튼
            GridCutView3("\\창고");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel8.BringToFront();
            //왼쪽 창고별 현황 버튼
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //창고별현황 수정 팝업 안에 몇번창고인지 텍스트파일
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //창고별현황 수정 팝업 그리드뷰
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //창고별현황 수정 팝업 주소 텍스트박스
        }

        private void button14_Click(object sender, EventArgs e)
        {
            panel11.Visible= false;
            //창고별현황 수정 팝업 수정 버튼
            foreach (DataGridViewRow row in dataGridView4.Rows)
            {
                try
                {
                    //그리드 뷰의 끝 지점인지 판단
                    if (!row.IsNewRow == true)
                    {

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열을 문자열로 저장
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀" + "\\창고" + "\\" + row.Cells[0].Value.ToString() + ".txt";

                        //파일 주소 저장
                        FileInfo file = new FileInfo(Absoluteposition);

                        //파일에 쓰기 위해서 StreamWriter 로 파일주소 찾아가기
                        StreamWriter sw = new StreamWriter(file.FullName);

                        sw.Write(DateTime.Now.Month.ToString() + '\t');

                        //반복목을 통하여 row컬랙션의 길이 만큼 반복
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            //row 컬랙션이 문자열이라 숫자열로 변환
                            int a = Int32.Parse(row.Cells.Count.ToString());

                            //*.txt에 저장 할때 마지막 "\t"를 제거 하기 위한 조건식
                            //마지막 "\t"을 짜르기 위한 조건식
                            if (i == a - 1)
                            {
                                //조건이 맞으면 문자열만 *.txt 에 추가
                                sw.Write(row.Cells[i].Value);
                            }
                            else
                            {
                                //조건이 맞지 않으면 *.txt 에 "\t"를 붙여서 추가
                                sw.Write(row.Cells[i].Value + "\t");
                            }
                        }
                        //열었던 파일 닫기
                        sw.Close();
                        //파일의 리소스 해제
                        sw.Dispose();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end foreach
        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //월별수불현황 그리드뷰
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //월별 수불현황 검색 텍스트뷰
        }

        private void SearchinGrid5(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀\\월별수불현황" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\월별수불현황", "*.*", SearchOption.AllDirectories);

            gridShowMonth();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == TextName)
                        {
                            dataGridView5.Rows.Add(arr[0],arr[1], arr[2], arr[3], arr[4], arr[5]);
                        }
                    }

                }

            }

        }
        private void button18_Click(object sender, EventArgs e)
        {
            //월별수불현황 검색 확인 버튼
            SearchinGrid5(textBox11.Text.ToString());
        }

        private void gridShowMonthModify()
        {
            dataGridView6.Columns.Clear();
            dataGridView6.Columns.Add("월", "월");
            dataGridView6.Columns.Add("품목코드", "품목코드");
            dataGridView6.Columns.Add("품목명", "품목명");
            dataGridView6.Columns.Add("입고수량", "입고수량");
            dataGridView6.Columns.Add("출고수량", "출고수량");
            dataGridView6.Columns.Add("재고수량", "재고수량");

            for (int i = 0; i < dataGridView5.Rows.Count; i++)
            {
                if (dataGridView5.Rows[i].Selected == true)
                {

                    dataGridView6.Rows.Add(
                        dataGridView5.Rows[i].Cells[0].Value,
                        dataGridView5.Rows[i].Cells[1].Value,
                        dataGridView5.Rows[i].Cells[2].Value,
                        dataGridView5.Rows[i].Cells[3].Value,
                        dataGridView5.Rows[i].Cells[4].Value,
                        dataGridView5.Rows[i].Cells[5].Value
                        );
                }
            }

        }

        private void button17_Click(object sender, EventArgs e)
        {
            //월별 수불현황 수정 버튼
            panel16.BringToFront();
            panel16.Visible = true;
            gridShowMonthModify();
        }

        //월별수불현황 컬럼명 추가
        private void gridShowMonth()
        {
            dataGridView5.Columns.Clear();
            dataGridView5.Columns.Add("월","월");
            dataGridView5.Columns.Add("품목코드", "품목코드");
            dataGridView5.Columns.Add("품목명", "품목명");
            dataGridView5.Columns.Add("입고수량", "입고수량");
            dataGridView5.Columns.Add("출고수량", "출고수량");
            dataGridView5.Columns.Add("재고수량", "재고수량");

        }

        private void grideShow5(string filename)
        {
            string foldername = warehousetoText("창고");

            //월 정보 알아오는 함수필요


            
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + "\\" + filename + "\\" + foldername, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowMonth();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        dataGridView5.Rows.Add(line.Split('\t'));

                    }

                }
                //dataGridView5.Rows.Add(result.Length.ToString());
                //dataGridView5.Rows.Add(result[0],result[1], result[2], result[3], result[4], result[5]);


            }

        }
        private string warehousetoText(string filename )
        {///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" +"\\"+ filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowMonth();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string result = "";
 
            string[] warehouse = new string[] { };

            int warehouseInK = 0;//창고입고내역K
            int warehouseInB = 0;//창고입고내역B
            int warehouseOutK = 0;//창고출고내역K
            int warehouseOutB = 0;//창고출고내역B
            int warehouseTotalK = 0;//창고재고내역K
            int warehouseTotalB = 0;//창고재고내역B

            //gridShowStore();
            //dataGridView1.Rows.Add(result[0], result[1], result[2], result[3], result[4], result[5]);



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
                        warehouse = line.Split('\t');//warehouse 길이 7



                        for (int j = 0; j < warehouse.Length; j++)
                        {
                            if (j % 8 == 0)//j가 8의 배수일 때,
                            {
                                

                                //해당이름의 폴더가 존재하는지 확인

                                DirectoryInfo m = new DirectoryInfo(dtif + "\\직원관리\\재고팀\\월별수불현황\\" + warehouse[j]); //해당 월 폴더 생성

                                if (m.Exists == false) m.Create();


                                //폴더가 있으면 안에 품목코드명 맨 앞의 텍스트파일 생성 ex)K, B

                                if (!System.IO.File.Exists(dtif + "\\직원관리\\재고팀\\월별수불현황" + "\\" + warehouse[j] + "\\K" + ".txt"))
                                {
                                    FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황" + "\\" + warehouse[j] + "\\K" + ".txt", FileMode.Create);//로그인관련(사번, 비번) 텍스트
                                                                                                                                                        //K.Close();

                                }
                                if (!System.IO.File.Exists(dtif + "\\직원관리\\재고팀\\월별수불현황" + "\\" + warehouse[j] + "\\B" + ".txt"))
                                {
                                    FileStream B = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황" + "\\" + warehouse[j] + "\\B" + ".txt", FileMode.Create);//로그인관련(사번, 비번) 텍스트
                                                                                                                                                        //B.Close();

                                }

                                //해당 텍스트파일에 warehouse의 입고 출고 재고내역 int로 변환하고 임시변수에 저장, 각각 더해서 집어넣음


                                switch (warehouse[j])
                                {
                                    case "1":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\1" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                                
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\1" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                                
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "2":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\2" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\2" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "3":

                                        try
                                        {
                                           
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\3" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\3" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                              
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "4":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\4" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                             
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\4" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }


                                        result = warehouse[j];
                                        return result;
                                    case "5":
                                        try
                                        {
                                           
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\5" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\5" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                                
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "6":

                                        try
                                        {
                                           
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\6" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\6" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                                
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "7":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\7" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\7" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                             
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "8":

                                        try
                                        {
                                           
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\8" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                             
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\8" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                            
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "9":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\9" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                            
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\9" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                          
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "10":

                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\10" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                               
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\10" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                            
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;
                                    case "11":
                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {

                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\11" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                       
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\11" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);

                                              
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();

                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;

                                    case "12":
                                        try
                                        {
                                            
                                            if (warehouse[2].Contains("K"))
                                            {
                                                
                                                for (int k = 4; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalK += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);
                                
                                                
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("K0000\t");
                                                writer.Write("킥보드\t");
                                                writer.Write(warehouseInK + "\t");
                                                writer.Write(warehouseOutK + "\t");
                                                writer.Write(warehouseTotalK + "\n");
                                                
                                                writer.Close();
                                                writer.Dispose();
                                           
                                            }
                                            else if (warehouse[1].Contains("B"))
                                            {
                                                for (int k = 0; k < warehouse.Length; k++)
                                                {
                                                    if (k % 4 == 0)
                                                    {
                                                        warehouseInB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 5 == 0)
                                                    {
                                                        warehouseOutB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                    else if (k % 6 == 0)
                                                    {
                                                        warehouseTotalB += Convert.ToInt32(warehouse[k]);
                                                    }
                                                }

                                                string path = dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\B" + ".txt";
                                                //FileStream K = new FileStream(dtif + "\\직원관리\\재고팀\\월별수불현황\\12" + "\\K" + ".txt", FileMode.Open);
                                                StreamWriter writer = new StreamWriter(path);
                             
                                              
                                                writer.Write(warehouse[j] + "\t");
                                                writer.Write("B0000\t");
                                                writer.Write("자전거\t");
                                                writer.Write(warehouseInB + "\t");
                                                writer.Write(warehouseOutB + "\t");
                                                writer.Write(warehouseTotalB + "\n");

                                                writer.Close();
                                                writer.Dispose();
                          
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(ex.Message);
                                        }

                                        result = warehouse[j];
                                        return result;



                                }

                                //텍스트파일 내용을 그리드뷰에 출력


                            }

                        }

                    }

                }

            }

            return result;

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void button16_Click(object sender, EventArgs e)
        {
            //월별수불현황 확인버튼
            //컬럼추가
            //gridShowMonth();
            //grideShow5("월별수불현황");

            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\월별수불현황", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowMonth();
            }
            else
            {
                gridShowMonth();
                grideShow5("\\월별수불현황");
            }

        }
        
        private void button61_Click(object sender, EventArgs e)
        {
            //월별 수불현황 저장버튼
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel13.BringToFront();
            //왼쪽 월별수불현황 버튼
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //월별 수불현황 수정 팝업 그리드뷰
        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel16.Visible= false;
            //월별 수불현황 수정 팝업 수정버튼
            foreach (DataGridViewRow row in dataGridView6.Rows)
            {
                try
                {
                    //그리드 뷰의 끝 지점인지 판단
                    if (!row.IsNewRow == true)
                    {

                        //그리드 뷰의 첫번째 열,첫번째 행의 문자열을 문자열로 저장
                        string Absoluteposition = dtif.ToString() + "\\직원관리\\재고팀\\월별수불현황" + "\\" + row.Cells[0].Value.ToString() +"\\" + row.Cells[1].Value.ToString()[0] + ".txt";

                        //파일 주소 저장
                        FileInfo file = new FileInfo(Absoluteposition);

                        //파일에 쓰기 위해서 StreamWriter 로 파일주소 찾아가기
                        StreamWriter sw = new StreamWriter(file.FullName);



                        for (int j = 0; j < dataGridView6.Columns.Count ; j++)
                        {
                            string[] text = new string[6];
                            text[j] = Convert.ToString(dataGridView6.Rows[0].Cells[j].Value);
                            
                            if (j == dataGridView6.Columns.Count - 1)
                            {
                                sw.Write(text[j].ToString());
                            }
                            else
                            {
                                sw.Write(text[j].ToString() + '\t');
                            }
                        }
                        sw.Close();

                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }//end foreach
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //왼쪽발주신청버튼
            panel19.BringToFront();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            //발주신청 품목명 텍스트박스
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            //발주신청 품목번호 텍스트박스
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            //발주신청 담당자 텍스트박스
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            //발주신청 가맹점 텍스트박스
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //발주신청 등록 버튼 //
            try
            {
                string fileName = textBox21.Text.ToString();
                string filename = dtif + "\\직원관리\\재고팀\\발주" + "\\" + fileName + ".txt";

                FileStream fs = new FileStream(filename, FileMode.Create);//발주 신청 등록 텍스트

                //File.WriteAllText(filename, textBox57.Text);
                StreamWriter writer = new StreamWriter(fs);

                //writer = File.CreateText(filename);
                writer.Write(DateTime.Now.ToString() + "\t");
                writer.Write(textBox21.Text + "\t");//품목코드
                writer.Write(textBox19.Text + "\t");//품목명
                writer.Write(textBox22.Text + "\t");//가맹점
                writer.Write(textBox23.Text + "\t");//수량
                writer.Write(textBox20.Text + "\n");//담당자

                writer.Close();
                fs.Close();

                writer.Dispose();
                fs.Dispose();

                textBox21.Text = "";
                textBox19.Text = "";
                textBox22.Text = "";
                textBox23.Text = "";
                textBox20.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            //발주신청서 입력 텍스트박스
            string strTemp = textBox23.Text;

            string[] arrTemp = strTemp.Split('\r','\n');

            if (arrTemp[arrTemp.Length - 1].Length >= LineLimitSizea) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }
            
            textBox23.Text = strTemp;
            textBox23.Select(textBox23.Text.Length, 0); //offset 이동
            textBox23.Focus();

            
        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //발주 현황 그리드뷰
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            //발주현황 검색텍스트박스
        }

        private void SearchinGrid7(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀\\발주" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\발주", "*.*", SearchOption.AllDirectories);

            gridShowOrder();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == TextName)
                        {
                            dataGridView7.Rows.Add(arr[1], arr[2], arr[3], arr[4], arr[5]);
                        }
                    }

                }

            }

        }

        private void button27_Click(object sender, EventArgs e)
        {
            //발주현황 검색 확인버튼
            SearchinGrid7(textBox25.Text.ToString());
        }

        //발주현황 컬럼명 추가
        private void gridShowOrder()
        {
            dataGridView7.Columns.Clear();
            dataGridView7.Columns.Add("품목코드", "품목코드");
            dataGridView7.Columns.Add("품목명", "품목명");
            dataGridView7.Columns.Add("가맹점", "가맹점");
            dataGridView7.Columns.Add("수량", "수량");
            dataGridView7.Columns.Add("담당자", "담당자");

        }
        private void grideShow7(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowOrder();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }

                dataGridView7.Rows.Add(result[1], result[2], result[3], result[4], result[5]);


            }

        }
        private void button25_Click(object sender, EventArgs e)
        {
            //발주현황 확인버튼
            gridShowOrder();
            grideShow7("\\발주");

        }

        private void button28_Click(object sender, EventArgs e)
        {
            //발주 현황 수정버튼
            panel30.BringToFront();
            panel30.Visible = true;
            

            int rowindex = dataGridView7.CurrentRow.Index;
            string RowIndexSelectElement = "";

            
            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                if (dataGridView7.Rows[i].Selected == true)
                {
                    RowIndexSelectElement = dataGridView7.Rows[i].Cells[0].Value.ToString();
                    textBox37.Text = dataGridView7.Rows[i].Cells[1].Value.ToString();//품목명
                    textBox38.Text = dataGridView7.Rows[i].Cells[4].Value.ToString();//담당자
                    textBox40.Text = dataGridView7.Rows[i].Cells[0].Value.ToString();//품목번호
                    textBox41.Text = dataGridView7.Rows[i].Cells[2].Value.ToString();//가맹점
                    textBox43.Text = dataGridView7.Rows[i].Cells[3].Value.ToString();//내용(수량)
                   

                }
            }

            
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            panel23.BringToFront();
            //왼쪽 발주 현황 버튼
        }

        private void button31_Click(object sender, EventArgs e)
        {
            //발주현황 팝업창 안에 수정 버튼
            panel30.Visible = false;
           

            
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            //품목명 텍스트박스
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            //담당자 이름 텍스트박스
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            //거래회사 텍스트박스
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            //품목번호 텍스트박스
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            //신청가맹점 텍스트박스
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            //연락처 텍스트박스
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            //발주현황 팝업 안에 내용 텍스트박스
            int a = 25;
            string strTemp = textBox43.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox43.Text = strTemp;
            textBox43.Select(textBox43.Text.Length, 0); //offset 이동
            textBox43.Focus();
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            //발주현황 날짜 자동 텍스트 입력
            //textBox45.Text = DateTime.Now.ToString("yy.MM.dd");
            //DateTime.Now.ToString("yy.MM.dd");
            
        }

        private void textBox47_TextChanged(object sender, EventArgs e)
        {
            //발주현황 팝업 담당자 이름 텍스트박스
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel33.BringToFront();
        }

        private void textBox63_TextChanged(object sender, EventArgs e)
        {
            //입고등록 내용 텍스트박스
            int a = 35;
            string strTemp = textBox63.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox63.Text = strTemp;
            textBox63.Select(textBox63.Text.Length, 0); //offset 이동
            textBox63.Focus();
        }

        private void textBox57_TextChanged(object sender, EventArgs e)
        {
            //입고등록 품목코드 텍스트박스
        }

        private void textBox58_TextChanged(object sender, EventArgs e)
        {
            //입고등록 수량 텍박 
        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {
            //입고등록 창고명 텍박
        }

        private void textBox60_TextChanged(object sender, EventArgs e)
        {
            //입고등록 배송담당 텍박
        }

        private void textBox61_TextChanged(object sender, EventArgs e)
        {
            //입고등록 가맹점 품목명 텍박
        }

        private void textBox62_TextChanged(object sender, EventArgs e)
        {
            //입고등록 연락처 텍박
        }
        private void button32_Click(object sender, EventArgs e)
        {
            //입고등록 등록버튼
            try
            {
                string fileName = textBox57.Text.ToString();
                string filename = dtif + "\\직원관리\\재고팀\\입고품목" + "\\" + fileName + ".txt";

                FileStream fs = new FileStream(filename, FileMode.Create);//입고등록 텍스트

                //File.WriteAllText(filename, textBox57.Text);
                StreamWriter writer = new StreamWriter(fs);

                //writer = File.CreateText(filename);
                writer.Write(DateTime.Now.ToString() + "\t");
                writer.Write(textBox57.Text + "\t");
                writer.Write(textBox61.Text + "\t");
                writer.Write(textBox59.Text + "\t");
                writer.Write(textBox58.Text + "\t");
                writer.Write(textBox60.Text + "\t");
                writer.Write(textBox62.Text + "\t");
                writer.Write(textBox63.Text + "\n");


                writer.Close();
                fs.Close();

                writer.Dispose();
                fs.Dispose();

                textBox57.Text = "";
                textBox61.Text = "";
                textBox59.Text = "";
                textBox58.Text = "";
                textBox60.Text = "";
                textBox62.Text = "";
                textBox63.Text = "";
                ///////////////////////////////////////////////////////////////////



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }

        }

        private void button34_Click(object sender, EventArgs e)
        {
            //입고등록 확인버튼
        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //입고현황 그리드뷰
        }

        private void textBox65_TextChanged(object sender, EventArgs e)
        {
            //입고현황 검색 텍박
        }

        private void SearchinGrid10(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성
            gridShowWarehousing();

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\입고품목", "*.*", SearchOption.AllDirectories);

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == TextName)
                        {
                            dataGridView10.Rows.Add(arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
                        }
                    }

                }

            }

        }
        private void button35_Click(object sender, EventArgs e)
        {
            //입고현황 검색 확인버튼
            SearchinGrid10(textBox65.Text.ToString());
        }

        private void textBox88_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 품목코드 텍스트
        }

        private void textBox85_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 품목명 텍스트
        }

        private void textBox87_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 창고명 텍스트
        }

        private void textBox84_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 수량 텍스트
        }

        private void textBox86_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 배송담당
        }

        private void textBox83_TextChanged(object sender, EventArgs e)
        {
            //입고등록 팝업 연락처
        }
        private void textBox82_TextChanged(object sender, EventArgs e)
        {
            //입고현황 팝업 내용 텍스트박스
        }

        private void button33_Click(object sender, EventArgs e)
        {
            panel50.BringToFront();
            panel50.Visible = true;
            //입고현황 등록버튼

            
        }

        //발주현황 컬럼명 추가
        private void gridShowWarehousing()
        {
            dataGridView10.Columns.Clear();
            dataGridView10.Columns.Add("품목코드", "품목코드");
            dataGridView10.Columns.Add("품목명", "품목명");
            dataGridView10.Columns.Add("창고명", "창고명");
            dataGridView10.Columns.Add("수량", "수량");

        }

        private void grideShow10(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowWarehousing();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }

                dataGridView10.Rows.Add(result[1], result[3], result[2], result[4]);


            }

        }
        private void button36_Click(object sender, EventArgs e)
        {
            //입고현황 확인버튼
            
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\입고품목", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowWarehousing();
            }
            else
            {
                gridShowWarehousing();
                grideShow10("\\입고품목");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //입고등록 팝업 등록버튼
            panel50.Visible = false;
            

        }

        private void textBox80_TextChanged(object sender, EventArgs e)
        {
            //발주날짜
        }

        private void textBox78_TextChanged(object sender, EventArgs e)
        {
            //입고현황 팝업 담당자 이름
        }

        private void button23_Click(object sender, EventArgs e)
        {
            panel37.BringToFront();
            //왼쪽 입고현황 버튼
        }

        private void dataGridView16_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //지급관리 조회 그리드뷰
        }

        private void textBox116_TextChanged(object sender, EventArgs e)
        {
            //지급관리조회 검색텍스트박스
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //지급관리조회 검색 확인버튼
        }

        private void button44_Click(object sender, EventArgs e)
        {
            panel53.BringToFront();
            panel53.Visible = true;
            //지급관리조회 수정 버튼
            int rowindex = dataGridView16.CurrentRow.Index;
            string RowIndexSelectElement = "";


            for (int i = 0; i < dataGridView16.Rows.Count; i++)
            {
                if (dataGridView16.Rows[i].Selected == true)
                {
                    RowIndexSelectElement = dataGridView16.Rows[i].Cells[0].Value.ToString();
                    
                    textBox107.Text = dataGridView16.Rows[i].Cells[1].Value.ToString();//품목명
                    textBox104.Text = dataGridView16.Rows[i].Cells[0].Value.ToString();//품목번호
                    textBox106.Text = dataGridView16.Rows[i].Cells[2].Value.ToString();//담당자(수량)
                    textBox103.Text = dataGridView16.Rows[i].Cells[3].Value.ToString();//창고명
                    textBox105.Text = dataGridView16.Rows[i].Cells[4].Value.ToString();//배송담당
                    textBox102.Text = dataGridView16.Rows[i].Cells[5].Value.ToString();//연락처

                }
            }

            
        }

        private void gridShowPaymentManagement()
        {
            dataGridView16.Columns.Clear();
            dataGridView16.Columns.Add("품목코드", "품목코드");
            dataGridView16.Columns.Add("품목명", "품목명");
            dataGridView16.Columns.Add("수량", "수량");
            dataGridView16.Columns.Add("창고명", "창고명");
            dataGridView16.Columns.Add("배송담당", "배송담당");
            dataGridView16.Columns.Add("연락처", "연락처");

        }

        private void grideShow16(string filename)
        {//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowPaymentManagement();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }

                dataGridView16.Rows.Add(result[1], result[3], result[4], result[2], result[5], result[6]);


            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
        private void button46_Click(object sender, EventArgs e)
        {
            //지급관리조회 확인버튼
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\입고품목", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowPaymentManagement();
            }
            else
            {
                gridShowPaymentManagement();
                grideShow16("\\입고품목");
            }
        }
        private void button43_Click(object sender, EventArgs e)
        {
            panel53.Visible = false;
            //지급관리 팝업 수정 등록
        }

        private void textBox101_TextChanged(object sender, EventArgs e)
        {
            int a = 35;
            string strTemp = textBox101.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox101.Text = strTemp;
            textBox101.Select(textBox101.Text.Length, 0); //offset 이동
            textBox101.Focus();
        }

        private void textBox99_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox107_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 품목명
        }

        private void textBox104_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 품목번호
        }

        private void textBox106_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 담당자
        }

        private void textBox103_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 창고명
        }

        private void textBox105_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 배송담당
        }

        private void textBox102_TextChanged(object sender, EventArgs e)
        {
            //지급관리 팝업 연락처
        }

        private void button49_Click(object sender, EventArgs e)
        {
            panel60.BringToFront();
        }

        private void textBox122_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 품목명
        }

        private void textBox121_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 담당자
        }

        private void textBox120_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 품목번호
        }

        private void textBox119_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 가맹점
        }

        private void textBox118_TextChanged(object sender, EventArgs e)
        {
            int a = 35;
            string strTemp = textBox118.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox118.Text = strTemp;
            textBox118.Select(textBox118.Text.Length, 0); //offset 이동
            textBox118.Focus();
        }

        private void button50_Click(object sender, EventArgs e)
        {
            //수리입고등록 등록버튼
            try
            {
                string fileName = textBox120.Text.ToString();
                string filename = dtif + "\\직원관리\\재고팀\\수리입고품목" + "\\" + fileName + ".txt";

                FileStream fs = new FileStream(filename, FileMode.Create);//수리입고등록 텍스트

                //File.WriteAllText(filename, textBox57.Text);
                StreamWriter writer = new StreamWriter(fs);

                //writer = File.CreateText(filename);
                writer.Write(DateTime.Now.ToString() + "\t");
                writer.Write(textBox120.Text + "\t");//품목코드
                writer.Write(textBox122.Text + "\t");//품목명
                writer.Write(textBox119.Text + "\t");//가맹점
                writer.Write(textBox121.Text + "\t");//담당자
                writer.Write(textBox118.Text + "\n");//내용

                writer.Close();
                fs.Close();

                writer.Dispose();
                fs.Dispose();

                textBox120.Text = "";
                textBox122.Text = "";
                textBox119.Text = "";
                textBox121.Text = "";
                textBox118.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.ToString());
            }
        }

       
        private void button51_Click(object sender, EventArgs e)
        {
            //수리입고등록 확인버튼
            
        }

        private void button24_Click(object sender, EventArgs e)
        {
            panel56.BringToFront();
            //왼쪽 지급관리조회버튼
        }

        private void grideShow17(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowRepairWarehousing();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }

                dataGridView17.Rows.Add(result[1], result[2], result[3], result[4]);


            }

        }
        private void button48_Click(object sender, EventArgs e)
        {
            //수리입고현황 버튼
            panel64.BringToFront();
        }

        private void dataGridView17_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //수리입고현황 그리드뷰
        }

        private void textBox124_TextChanged(object sender, EventArgs e)
        {
            //수리입고현황 검색텍스트
        }

        private void SearchinGrid17(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성
            gridShowRepairWarehousing();

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\수리입고품목", "*.*", SearchOption.AllDirectories);

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j] == TextName)
                        {
                            dataGridView17.Rows.Add(arr[1], arr[2], arr[3], arr[4]);
                        }
                    }

                }

            }

        }
        private void button53_Click(object sender, EventArgs e)
        {
            //수리입고현황 검색 확인
            SearchinGrid17(textBox124.Text.ToString());
        }

        private void button52_Click(object sender, EventArgs e)
        {
            //수리입고현황 등록버튼
            panel67.Visible = true;
            panel67.BringToFront();
        }

        private void gridShowRepairWarehousing()
        {
            dataGridView17.Columns.Clear();
            dataGridView17.Columns.Add("품목코드", "품목코드");
            dataGridView17.Columns.Add("품목명", "품목명");
            dataGridView17.Columns.Add("가맹점", "가맹점");
            dataGridView17.Columns.Add("담당자", "담당자");

        }
        private void button54_Click(object sender, EventArgs e)
        {
            //수리입고현황 확인버튼
            
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\수리입고품목", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowRepairWarehousing();
            }
            else
            {
                gridShowRepairWarehousing();
                grideShow17("\\수리입고품목");
            }
        }

        private void textBox135_TextChanged(object sender, EventArgs e)
        {
            int a = 25;
            string strTemp = textBox135.Text;

            string[] arrTemp = strTemp.Split('\r', '\n');

            if (arrTemp[arrTemp.Length - 1].Length >= a) //전역변수 : 10 , 최대길이 10
            {
                strTemp += Environment.NewLine;
            }

            textBox135.Text = strTemp;
            textBox135.Select(textBox135.Text.Length, 0); //offset 이동
            textBox135.Focus();
        }

        private void textBox133_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox141_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 품목명
        }

        private void textBox140_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 담당자
        }

        private void textBox138_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 품목번호
        }

        private void textBox137_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 창고명
        }

        private void textBox139_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 거래회사
        }

        private void textBox136_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 연락처
        }

        private void textBox130_TextChanged(object sender, EventArgs e)
        {
            //수리입고등록 담당자이름
        }

        private void button55_Click(object sender, EventArgs e)
        {
            panel67.Visible = false;
            //수리입고등록 등록버튼
        }

        private void textBox150_TextChanged(object sender, EventArgs e)
        {
            //수리수불현황 검색 텍스트
        }
        private void SearchinGrid18(string TextName)
        {
            //그리드 뷰에 넣기 위한 테이블 생성
            gridShowRepair();

            //TextBox 입력된 문자열 string 으로 저장
            string SearchAddress = dtif + "\\직원관리\\재고팀" + "\\" + TextName + ".txt";
            //폴더안에 폴더안에 모든 *.txt 파일 이름 배열에 저장
            string[] allfiles = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\수리입고품목", "*.*", SearchOption.AllDirectories);

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            for (int i = 0; i < allfiles.Length; i++)
            {
                //폴더 안의 폴더 안의 존재 하는 모든 *.txt 파일의 각각의 내용 배열에 저장
                string[] arra = File.ReadAllLines(allfiles[i]);

                //반복문으로 저장된 배열의 내용을 처리
                foreach (string line in arra)
                {
                    string[] arr = line.Split('\t');
                    for (int j = 0; j < arr.Length; j++)
                    {
                        if (arr[j].Contains(TextName))
                        {
                            dataGridView18.Rows.Add(arr[1], arr[2], arr[5], arr[3], arr[4], "입고");
                        }
                    }

                }

            }

        }
        private void button57_Click(object sender, EventArgs e)
        {
            //수리수불현황 검색 확인
            SearchinGrid18(textBox150.Text.ToString());
        }

        private void dataGridView18_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //수리수불현황 그리드뷰
        }

        private void button47_Click(object sender, EventArgs e)
        {
            panel70.BringToFront();
            //수리수불현황 왼쪽 버튼
        }

        private void gridShowRepair()
        {
            dataGridView18.Columns.Clear();
            dataGridView18.Columns.Add("품목코드", "품목코드");
            dataGridView18.Columns.Add("품목명", "품목명");
            dataGridView18.Columns.Add("수리내역", "수리내역");
            dataGridView18.Columns.Add("가맹점", "가맹점");
            dataGridView18.Columns.Add("담당자", "담당자");
            dataGridView18.Columns.Add("입고내역", "입고내역");



        }

        private void grideShow18(string filename)
        {
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀" + filename, "*.*", SearchOption.AllDirectories);

            //그리드 뷰 table 헤드 추가
            gridShowRepair();

            //반복문을 이용해서 배열에 저장된 길이 만큼 반복

            string[] result = new string[] { };


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

                        result = line.Split('\t');
                        //배열의 문자열을 "\t"로 짜른 문자열을 그리드뷰의 행에 추가
                        //dataGridView3.Rows.Add(line.Split('\t'));

                    }

                }

                dataGridView18.Rows.Add(result[1], result[2], result[5], result[3], result[4], "입고");


            }

        }

        private void button58_Click(object sender, EventArgs e)
        {
            //수리수불현황 확인버튼
            gridShowRepair();
            string[] allfiles2 = Directory.GetFiles(dtif + "\\직원관리\\재고팀\\수리입고품목", "*.*", SearchOption.AllDirectories);
            if (allfiles2.Length == 0)
            {
                gridShowRepair();
            }
            else
            {
                gridShowRepair();
                grideShow18("\\수리입고품목");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            panel73.BringToFront();
            //왼쪽 재고 관리 버튼
        }

        
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        
    }
}
